using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.Collections.Generic;

/// <summary>
/// Ice Mage
/// Slow down the enemies and give them DOT
/// </summary>
public class IceMage : Mage {


    [Header("Ice Mage Fileds")]
    public float damageOverTime = 0f;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    public ParticleSystem particleEffect;
    public ParticleSystem iceEffect;
    protected Animator animator;


    void Start() {
        HeroPool.GetInstance().SetHero(this, CommonConfig.IceMage);
        LevelManager = new MageLeveling(this, IceMageConfig.Level);

        animator = GetComponent<Animator>();

        LoadAttr();

        particleEffect.Stop();
        iceEffect.Stop();

        LoadSkill();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("In IceMage");
    }


    protected override void Update() {
        //Skill
        if (PlayerStats.Energy < energyCostBySkill)
        {
            NotEnoughEnergy = true;
        }
        else
        {
            NotEnoughEnergy = false;
        }
        if (HasSkillUsed) {
            SkillTimer += Time.deltaTime;
            SkillCDImage.fillAmount = (SkillCooldownTime - SkillTimer) / SkillCooldownTime;
        }
        if (NotEnoughEnergy == true && prev <= 0)
        {
            SkillCDImage.fillAmount = 1f;
        }
        else
        {
            SkillCDImage.fillAmount = prev;
        }

        if (this.Target == null) { 
            if (lineRenderer.enabled) {
                animator.SetBool("CanAttack", false);
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();
        this.transform.LookAt(this.Target);

        Laser();
    }


    public override void ExSkill() {
        Debug.Log("Ice Mage uses skill");
        particleEffect.Play();
        iceEffect.Play();
        StartCoroutine("SkillDuration");
    }


    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(3f);
        Debug.Log("IceMage: Show time :)");
        particleEffect.Stop();
        iceEffect.Stop();
        animator.SetBool("Skill", false);
    }


    private void Laser() {
        this.TargetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        this.TargetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled) {
            animator.SetBool("CanAttack", true);
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, this.Target.position);

        Vector3 dir = transform.position - this.Target.position;

        impactEffect.transform.position = this.Target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }


    private void LoadSkill() {
        SkillTimer = 0f;
        SkillCooldownTime = IceMageConfig.SkillCooldownTime;
        SkillCDImage = GameObject.Find(CommonConfig.IceMageSkillCDImage).GetComponent<Image>();
        SkillCDImage.fillAmount = 0f;
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        HeroType = CommonConfig.IceMage;
        CharacterName = IceMageConfig.CharacterName;
        CharacterDescription = IceMageConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(IceMageConfig.MaxHPValue);
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(IceMageConfig.ATKValue);
        MATK = new CharacterAttribute(IceMageConfig.MATKValue);

        PDEF = new CharacterAttribute(IceMageConfig.PDEFValue);
        MDEF = new CharacterAttribute(IceMageConfig.MDEFValue);

        Crit = new CharacterAttribute(IceMageConfig.CritValue);
        CritDMG = new CharacterAttribute(IceMageConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(IceMageConfig.PernetrationValue);
        ACC = new CharacterAttribute(IceMageConfig.ACCValue);
        Dodge = new CharacterAttribute(IceMageConfig.DodgeValue);
        Block = new CharacterAttribute(IceMageConfig.BlockValue);
        CritResistance = new CharacterAttribute(IceMageConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(IceMageConfig.ATKSpeedValue);

        //special
        damageOverTime = 0.75f * MATKValue;
        slowAmount = IceMageConfig.SlowAmount;
        Range = new CharacterAttribute(IceMageConfig.Range);
        energyCostBySkill = IceMageConfig.energyCostValue;

        List<Equipment> equipments = EquipmentStorage.getEquippped()[CommonConfig.IceMage];
        foreach (Equipment equip in equipments) {
            equip.Equip(this);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Archer.
/// </summary>
public class Archer : BaseHero {
    public ArcherLeveling LevelManager;


    //Skill fields
    StatModifier ATKSpeedModifierBySkill;

    [Header("Archer Fileds")]
    public ParticleSystem particleEffect;
    public ParticleSystem arrowEffect;

    void Start() {
        LevelManager = new ArcherLeveling(this, ArcherConfig.Level);
        LoadAttr();
        LoadSkill();
        HeroPool.GetInstance().SetHero(this, CommonConfig.Archer);
        HeroAnimator = GetComponent<Animator>();
        particleEffect.Stop();
        arrowEffect.Stop();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    protected override void Attack() {
        if (HeroAnimator != null) {
            HeroAnimator.SetBool("CanAttack", true);
        }
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.ATK = 0.33f * ATKValue;
        bullet.ACC = ACCValue;
        bullet.criticalDamage = CritDMGValue;
        bullet.critical = CritValue;
        bullet.MATK = MATKValue;
        if (bullet != null) {
        	bullet.Seek(Target);
        }
    }


    public override void ExSkill() {
        //duration time
        Logger.Log("Attack Speed Up");
        if (HeroAnimator != null) {
            HeroAnimator.SetBool("Skill", true);
        }
        particleEffect.Play();
        arrowEffect.Play();
        ATKSpeed.AddModifier(ATKSpeedModifierBySkill);
        attackRate = ATKSpeedValue;
        StartCoroutine("SkillDuration");
    }


    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(3f);
        Logger.Log("Archer: Biu Biu Biu~~~~~~~!");

        ATKSpeed.RemoveModifier(ATKSpeedModifierBySkill);
        attackRate = ATKSpeedValue;  //3 attacks per second
        particleEffect.Stop();
        arrowEffect.Stop();
        HeroAnimator.SetBool("Skill", false);
    }


    private void LoadSkill() {
        ATKSpeedModifierBySkill = new StatModifier(ArcherConfig.ATKSpeedPercent, StatModType.PercentAdd);
        SkillTimer = 0f;
        SkillCooldownTime = ArcherConfig.SkillCooldownTime;
        SkillCDImage = GameObject.Find(CommonConfig.ArcherSkillCDImage).GetComponent<Image>();
        SkillCDImage.fillAmount = 0f;
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        //special
        HeroType = CommonConfig.Archer;
        Range = new CharacterAttribute(ArcherConfig.Range);

        CharacterName = ArcherConfig.CharacterName;
        CharacterDescription = ArcherConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(ArcherConfig.MaxHPValue);
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(ArcherConfig.ATKValue);
        MATK = new CharacterAttribute(ArcherConfig.MATKValue);

        PDEF = new CharacterAttribute(ArcherConfig.PDEFValue);
        MDEF = new CharacterAttribute(ArcherConfig.MDEFValue);

        Crit = new CharacterAttribute(ArcherConfig.CritValue);
        CritDMG = new CharacterAttribute(ArcherConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(ArcherConfig.PernetrationValue);
        ACC = new CharacterAttribute(ArcherConfig.ACCValue);
        Dodge = new CharacterAttribute(ArcherConfig.DodgeValue);
        Block = new CharacterAttribute(ArcherConfig.BlockValue);
        CritResistance = new CharacterAttribute(ArcherConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(ArcherConfig.ATKSpeedValue);
        attackRate = ATKSpeedValue;  //3 attacks per second
        energyCostBySkill = ArcherConfig.energyCostValue;
        List<Equipment> equipments = EquipmentStorage.getEquippped()[CommonConfig.Archer];
        foreach (Equipment equip in equipments) {
            equip.Equip(this);
        }
    }
}

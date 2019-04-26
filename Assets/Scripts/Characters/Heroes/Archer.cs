using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// Archer.
/// </summary>
public class Archer : BaseHero {
    public static Archer instance = null;
    public ArcherLeveling LevelManager;

    private static readonly object padlock = new object();

    //Skill fields
    StatModifier ATKSpeedModifierBySkill;

    new void Start() {
        if (instance == null) {
            lock (padlock) {
                if (instance == null) {
                    instance = new Archer();
                }
            }
        }

        instance = this;

        HeroPool.GetInstance().SetHero(this, CommonConfig.Archer);

        LevelManager = new ArcherLeveling(this, ArcherConfig.Level);

        HeroAnimator = GetComponent<Animator>();

        LoadAttr();

        LoadSkill();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    protected override void Attack() {
        if (HeroAnimator != null) {
            HeroAnimator.SetBool("CanAttack", true);
        }
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = 0.3f * ATKValue;
        bullet.ACC = ACCValue;
        bullet.criticalDamage = CritDMGValue;
        bullet.critical = CritValue;
        if (bullet != null) {
        	bullet.Seek(Target);
        }
    }


    public override void ExSkill() {
        //duration time
        Debug.Log("Attack Speed Up");

        ATKSpeed.AddModifier(ATKSpeedModifierBySkill);
        attackRate = ATKSpeedValue;
        StartCoroutine("SkillDuration");
    }


    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(3f);
        Debug.Log("Attack Speed back to normal");

        ATKSpeed.RemoveModifier(ATKSpeedModifierBySkill);
        attackRate = ATKSpeedValue;  //3 attacks per second
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
    }
}

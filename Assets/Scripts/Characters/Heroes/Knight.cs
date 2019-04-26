using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Knight : BaseHero {
    public static Knight instance;
    public KnightLeveling LevelManager;

    private static readonly object padlock = new object();

    //Skill fields
    StatModifier PDEFModifierBySkill;
    StatModifier MDEFModifierBySkill;
    StatModifier DodgeModifierBySkill;
    StatModifier BlockModifierBySkill;

    new void Start() {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Knight();
                }
            }
        }

        instance = this;

        HeroPool.GetInstance().SetHero(this, CommonConfig.Knight);

        LevelManager = new KnightLeveling(this, KnightConfig.Level);

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
        bullet.ATK = ATKValue;
        bullet.MATK = MATKValue;
        bullet.critical = CritValue;
        bullet.criticalDamage = CritDMGValue;
        bullet.ACC = ACCValue;
        if (bullet != null)
            bullet.Seek(Target);
    }


    public override void ExSkill() {
        //duration time
        Debug.Log("DEF up");
        PDEF.AddModifier(PDEFModifierBySkill);
        MDEF.AddModifier(MDEFModifierBySkill);
        Dodge.AddModifier(DodgeModifierBySkill);
        Block.AddModifier(BlockModifierBySkill);
        StartCoroutine("SkillDuration");
    }


    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(2f);
        PDEF.RemoveModifier(PDEFModifierBySkill);
        MDEF.RemoveModifier(MDEFModifierBySkill);
        Dodge.RemoveModifier(DodgeModifierBySkill);
        Block.RemoveModifier(BlockModifierBySkill);
        Debug.Log("DEF back to normal");
    }


    private void LoadSkill() {
        SkillTimer = 0f;
        SkillCooldownTime = KnightConfig.SkillCooldownTime;
        SkillCDImage = GameObject.Find(CommonConfig.KnightSkillCDImage).GetComponent<Image>();

        PDEFModifierBySkill = new StatModifier(KnightConfig.PDEFPercent, StatModType.PercentAdd);
        MDEFModifierBySkill = new StatModifier(KnightConfig.MDEFPercent, StatModType.PercentAdd);
        DodgeModifierBySkill = new StatModifier(KnightConfig.DodgeFlat, StatModType.Flat);
        BlockModifierBySkill = new StatModifier(KnightConfig.BlockFlat, StatModType.Flat);
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        //special
        Range = new CharacterAttribute(KnightConfig.Range);

        CharacterName = KnightConfig.CharacterName;
        CharacterDescription = KnightConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(KnightConfig.MaxHPValue);
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(KnightConfig.ATKValue);
        MATK = new CharacterAttribute(KnightConfig.MATKValue);

        PDEF = new CharacterAttribute(KnightConfig.PDEFValue);
        MDEF = new CharacterAttribute(KnightConfig.MDEFValue);

        Crit = new CharacterAttribute(KnightConfig.CritValue);
        CritDMG = new CharacterAttribute(KnightConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(KnightConfig.PernetrationValue);
        ACC = new CharacterAttribute(KnightConfig.ACCValue);
        Dodge = new CharacterAttribute(KnightConfig.DodgeValue);
        Block = new CharacterAttribute(KnightConfig.BlockValue);
        CritResistance = new CharacterAttribute(KnightConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(KnightConfig.ATKSpeedValue);
        attackRate = ATKSpeedValue;  //3 attacks per second
    }

}


using UnityEngine;
using System.Collections;

public class Knight : BaseHero {

    public KnightLeveling LevelManager;

    //Skill fields
    StatModifier PDEFModifierBySkill;
    StatModifier MDEFModifierBySkill;
    StatModifier DodgeModifierBySkill;
    StatModifier BlockModifierBySkill;

    new void Start() {
        LevelManager = new KnightLeveling(this, KnightConfig.Level);

        SkillIsReady = true;

        LoadAttr();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("In Knight");
    }

    protected override void Attack() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = ATKValue;

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


    public override IEnumerator SkillCooldown() {
        yield return new WaitForSeconds(PriestConfig.SkillCooldownTime);
        SkillIsReady = true;
    }


    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(2f);
        PDEF.RemoveModifier(PDEFModifierBySkill);
        MDEF.RemoveModifier(MDEFModifierBySkill);
        Dodge.RemoveModifier(DodgeModifierBySkill);
        Block.RemoveModifier(BlockModifierBySkill);
        Debug.Log("DEF back to normal");
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        //special
        Range = new CharacterAttribute(KnightConfig.Range);

        //skill
        PDEFModifierBySkill = new StatModifier(KnightConfig.PDEFPercent, StatModType.PercentAdd);
        MDEFModifierBySkill = new StatModifier(KnightConfig.MDEFPercent, StatModType.PercentAdd);
        DodgeModifierBySkill = new StatModifier(KnightConfig.DodgeFlat, StatModType.Flat);
        BlockModifierBySkill = new StatModifier(KnightConfig.BlockFlat, StatModType.Flat);

        CharacterName = KnightConfig.CharacterName;
        CharacterDescription = KnightConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(KnightConfig.MaxHPValue);
        CurHP = 10f; //TODO: change back to MaxHPValue;

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



using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Knight : BaseHero {

    public KnightLeveling LevelManager;

    //Skill fields
    StatModifier PDEFModifierBySkill;
    StatModifier MDEFModifierBySkill;
    StatModifier DodgeModifierBySkill;
    StatModifier BlockModifierBySkill;

    public SkillUI skillUI;
    //public GameObject skillCanvas;

    new void Start() {
        LevelManager = new KnightLeveling(this, KnightConfig.Level);

        SkillIsReady = true;
        HeroAnimator = GetComponent<Animator>();

        LoadAttr();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    //TODO: Create a HeroClicker script for listening click events? https://www.youtube.com/watch?v=0sFrDJKwsdM
    //Remeber to add box collider so to click this hero object
    void OnMouseDown() {
        Debug.Log("OnMouseDown, skillUI: " + skillUI.IsActive);

        if (!skillUI.IsActive) {
            skillUI.SetTarget(this);
            skillUI.Show();
        } else {
            skillUI.Hide();
        }
    }

    protected override void Attack() {
        if (HeroAnimator != null) {
            HeroAnimator.SetBool("CanAttack", true);
        }

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


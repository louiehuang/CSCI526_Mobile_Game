using UnityEngine;
using System.Collections;

public class Knight : BaseHero {

    public KnightLeveling LevelManager;

    new void Start() {
        LevelManager = new KnightLeveling(this, KnightConfig.Level);

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


    public override void UseSkill() {
        //hero on this node uses kill
        //TODO: consume energy

        //check CD
        if (SkillIsReady) {
            Debug.Log("use skill");
            SkillIsReady = false;
            ExSkill();
            StartCoroutine("SkillCooldown");
        } else {
            Debug.Log("skill not ready");
        }
    }

    void ExSkill() {
        Debug.Log("DEF up");
    }


    IEnumerator SkillCooldown() {
        yield return new WaitForSeconds(KnightConfig.SkillCooldownTime);
        SkillIsReady = true;
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
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

        //special
        Range = new CharacterAttribute(KnightConfig.Range);
    }
}



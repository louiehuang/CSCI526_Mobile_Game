using UnityEngine;

/// <summary>
/// Fire mage
/// Range attack
/// Low attack speed
/// </summary>
public class FireMage : Mage {

    //use large range bulletPrefab, missile
    public float radius = 0f;


    new void Start() {
        LevelManager = new MageLeveling(this, FireMageConfig.Level);

        LoadAttr();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("In fireMage");
    }

    protected override void Attack() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = 0.3f * MATKValue;

        if (bullet != null)
            bullet.Seek(Target);
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        CharacterName = FireMageConfig.CharacterName;
        CharacterDescription = FireMageConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(FireMageConfig.MaxHPValue);
        CurHP = 10;  //TODO: change back to MaxHPValue

        ATK = new CharacterAttribute(FireMageConfig.ATKValue);
        MATK = new CharacterAttribute(FireMageConfig.MATKValue);

        PDEF = new CharacterAttribute(FireMageConfig.PDEFValue);
        MDEF = new CharacterAttribute(FireMageConfig.MDEFValue);

        Crit = new CharacterAttribute(FireMageConfig.CritValue);
        CritDMG = new CharacterAttribute(FireMageConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(FireMageConfig.PernetrationValue);
        ACC = new CharacterAttribute(FireMageConfig.ACCValue);
        Dodge = new CharacterAttribute(FireMageConfig.DodgeValue);
        Block = new CharacterAttribute(FireMageConfig.BlockValue);
        CritResistance = new CharacterAttribute(FireMageConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(FireMageConfig.ATKSpeedValue);
        attackRate = ATKSpeedValue;  //3 attacks per second

        //special
        Range = new CharacterAttribute(FireMageConfig.Range);
        radius = FireMageConfig.Radius;
    }
}



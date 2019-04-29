using UnityEngine;
using UnityEngine.UI;

public class EnemyUsingBullet : BaseEnemy
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int index;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    void Start()
    {
        speed = MoveSpeedValue;
        CurHP = MaxHPValue;
        range = RangeValue;
        LoadAttr();
        //Debug.Log("Enemy initial: " + MoveSpeedValue + " CurHP " + CurHP + " Range " + range);
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackTarget == null)
        {
            return;
        }


        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }


    void Shoot() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.ATK = ATKValue;
        bullet.ACC = ACCValue;
        bullet.criticalDamage = CritDMGValue;
        bullet.critical = CritValue;
        bullet.MATK = MATKValue;
        //Debug.Log("attack damage" + bullet.damage);
        if (bullet != null)
            bullet.Seek(AttackTarget);
    }

    public void LoadAttr()
    {
        if (index == 0)
        {
            //special
            Range = new CharacterAttribute(EnermyUsingBulletConfig.Range);

            CharacterName = EnermyUsingBulletConfig.CharacterName;

            MaxHP = new CharacterAttribute(EnermyUsingBulletConfig.MaxHPValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            CurHP = MaxHPValue;

            ATK = new CharacterAttribute(EnermyUsingBulletConfig.ATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MATK = new CharacterAttribute(EnermyUsingBulletConfig.MATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            PDEF = new CharacterAttribute(EnermyUsingBulletConfig.PDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MDEF = new CharacterAttribute(EnermyUsingBulletConfig.MDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            Crit = new CharacterAttribute(EnermyUsingBulletConfig.CritValue);
            CritDMG = new CharacterAttribute(EnermyUsingBulletConfig.CritDMGValue);

            Pernetration = new CharacterAttribute(EnermyUsingBulletConfig.PernetrationValue);
            ACC = new CharacterAttribute(EnermyUsingBulletConfig.ACCValue);
            Dodge = new CharacterAttribute(EnermyUsingBulletConfig.DodgeValue);
            Block = new CharacterAttribute(EnermyUsingBulletConfig.BlockValue);
            CritResistance = new CharacterAttribute(EnermyUsingBulletConfig.CritResistanceValue);

            ATKSpeed = new CharacterAttribute(EnermyUsingBulletConfig.ATKSpeedValue);
            //attackRate = ATKSpeedValue;  //3 attacks per second
        }
        else if (index == 1)
        {
            //special
            Range = new CharacterAttribute(BossConfig.Range);

            CharacterName = BossConfig.CharacterName;

            MaxHP = new CharacterAttribute(BossConfig.MaxHPValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            CurHP = MaxHPValue;

            ATK = new CharacterAttribute(BossConfig.ATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MATK = new CharacterAttribute(BossConfig.MATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            PDEF = new CharacterAttribute(BossConfig.PDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MDEF = new CharacterAttribute(BossConfig.MDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            Crit = new CharacterAttribute(BossConfig.CritValue);
            CritDMG = new CharacterAttribute(BossConfig.CritDMGValue);

            Pernetration = new CharacterAttribute(BossConfig.PernetrationValue);
            ACC = new CharacterAttribute(BossConfig.ACCValue);
            Dodge = new CharacterAttribute(BossConfig.DodgeValue);
            Block = new CharacterAttribute(BossConfig.BlockValue);
            CritResistance = new CharacterAttribute(BossConfig.CritResistanceValue);

            ATKSpeed = new CharacterAttribute(BossConfig.ATKSpeedValue);
            //attackRate = ATKSpeedValue;  //3 attacks per second
        }
        else if (index == 2)
        {
            //special
            Range = new CharacterAttribute(TripodonteBullet.Range);

            CharacterName = TripodonteBullet.CharacterName;

            MaxHP = new CharacterAttribute(TripodonteBullet.MaxHPValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            CurHP = MaxHPValue;

            ATK = new CharacterAttribute(TripodonteBullet.ATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MATK = new CharacterAttribute(TripodonteBullet.MATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            PDEF = new CharacterAttribute(TripodonteBullet.PDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MDEF = new CharacterAttribute(TripodonteBullet.MDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            Crit = new CharacterAttribute(TripodonteBullet.CritValue);
            CritDMG = new CharacterAttribute(TripodonteBullet.CritDMGValue);

            Pernetration = new CharacterAttribute(TripodonteBullet.PernetrationValue);
            ACC = new CharacterAttribute(TripodonteBullet.ACCValue);
            Dodge = new CharacterAttribute(TripodonteBullet.DodgeValue);
            Block = new CharacterAttribute(TripodonteBullet.BlockValue);
            CritResistance = new CharacterAttribute(TripodonteBullet.CritResistanceValue);

            ATKSpeed = new CharacterAttribute(TripodonteBullet.ATKSpeedValue);
            //attackRate = ATKSpeedValue;  //3 attacks per second
        } else if (index == 3) {
            //special
            Range = new CharacterAttribute(OnePunchMan.Range);

            CharacterName = OnePunchMan.CharacterName;

            MaxHP = new CharacterAttribute(OnePunchMan.MaxHPValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            CurHP = MaxHPValue;

            ATK = new CharacterAttribute(OnePunchMan.ATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MATK = new CharacterAttribute(OnePunchMan.MATKValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            PDEF = new CharacterAttribute(OnePunchMan.PDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
            MDEF = new CharacterAttribute(OnePunchMan.MDEFValue * (float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));

            Crit = new CharacterAttribute(OnePunchMan.CritValue);
            CritDMG = new CharacterAttribute(OnePunchMan.CritDMGValue);

            Pernetration = new CharacterAttribute(OnePunchMan.PernetrationValue);
            ACC = new CharacterAttribute(OnePunchMan.ACCValue);
            Dodge = new CharacterAttribute(OnePunchMan.DodgeValue);
            Block = new CharacterAttribute(OnePunchMan.BlockValue);
            CritResistance = new CharacterAttribute(OnePunchMan.CritResistanceValue);

            ATKSpeed = new CharacterAttribute(OnePunchMan.ATKSpeedValue);
            //attackRate = ATKSpeedValue;  //3 attacks per second
        }
    }
}

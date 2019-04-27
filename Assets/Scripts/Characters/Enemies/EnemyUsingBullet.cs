using UnityEngine;
using UnityEngine.UI;

public class EnemyUsingBullet : BaseEnemy
{
    public GameObject bulletPrefab;
    public Transform firePoint;


    public float fireRate = 1f;
    private float fireCountdown = 0f;

    void Start()
    {
        speed = MoveSpeedValue;
        CurHP = MaxHPValue;
        range = RangeValue;
        LoadAttr();
        Debug.Log("Enemy initial: " + MoveSpeedValue + " CurHP " + CurHP + " Range " + range);
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
        bullet.damage = ATKValue;
        //Debug.Log("attack damage" + bullet.damage);
        if (bullet != null)
            bullet.Seek(AttackTarget);
    }

    public void LoadAttr()
    {
        //special
        Range = new CharacterAttribute(EnermyUsingBulletConfig.Range);

        CharacterName = EnermyUsingBulletConfig.CharacterName;

        MaxHP = new CharacterAttribute(EnermyUsingBulletConfig.MaxHPValue *(float)(1 + EnemyConfig.levelCount * 0.2) * (float)(1 + 0.05 * EnemyConfig.waveCount));
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(EnermyUsingBulletConfig.ATKValue * (float)(1+EnemyConfig.levelCount*0.2) * (float)(1+ 0.05 *EnemyConfig.waveCount));
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
}

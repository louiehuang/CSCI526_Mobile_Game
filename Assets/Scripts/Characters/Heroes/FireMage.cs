using UnityEngine;
using System.Collections;


/// <summary>
/// Fire mage
/// Feature: range attack
/// </summary>
public class FireMage : Mage {
    public static FireMage instance;

    private static readonly object padlock = new object();
    //use large range bulletPrefab, missile
    public float radius = 0f;

    new void Start() {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new FireMage();
                }
            }
        }
        instance = this;

        HeroPool.GetInstance().SetHero(this, "FIREMAGE");

        // Object.DontDestroyOnLoad(instance);
        LevelManager = new MageLeveling(this, FireMageConfig.Level);

        SkillIsReady = true;
        HeroAnimator = GetComponent<Animator>();

        LoadAttr();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected override void Attack() {
        if (HeroAnimator != null) {
            HeroAnimator.SetBool("CanAttack", true);
        }

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = 0.5f * MATKValue;

        if (bullet != null)
            bullet.Seek(Target);
    }


    public override void ExSkill() {
        //do damage on all enemies
        Debug.Log("Do damage on all enemies");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if (enemies != null && enemies.Length > 0) {
            float amount = 1.85f * MATKValue;
            foreach (GameObject enemy in enemies) {
                BaseEnemy te = enemy.GetComponent<BaseEnemy>();
                te.TakeDamage(amount);
            }
        }
    }


    public override IEnumerator SkillCooldown() {
        yield return new WaitForSeconds(FireMageConfig.SkillCooldownTime);
        SkillIsReady = true;
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        CharacterName = FireMageConfig.CharacterName;
        CharacterDescription = FireMageConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(FireMageConfig.MaxHPValue);
        CurHP = MaxHPValue;  //TODO: change back to MaxHPValue

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



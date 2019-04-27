using UnityEngine;
using UnityEngine.UI;
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

    [Header("FireMage Fileds")]
    public ParticleSystem particleEffect;
    public ParticleSystem fireEffect;

    new void Start() {
        if (instance == null) {
            lock (padlock) {
                if (instance == null) {
                    instance = new FireMage();
                }
            }
        }

        instance = this;

        HeroPool.GetInstance().SetHero(this, CommonConfig.FireMage);

        LevelManager = new MageLeveling(this, FireMageConfig.Level);

        HeroAnimator = GetComponent<Animator>();

        LoadAttr();

        particleEffect.Stop();
        fireEffect.Stop();

        LoadSkill();

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
        Debug.Log("Fire Mage do damage on all enemies");

        if (HeroAnimator != null) {
            HeroAnimator.SetBool("Skill", true);
        }
        particleEffect.Play();
        fireEffect.Play();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //Debug.Log("Number of enemies: " + enemies.Length);
        if (enemies != null && enemies.Length > 0) {
            float amount = 1.85f * MATKValue;
            foreach (GameObject enemy in enemies) {
                BaseEnemy te = enemy.GetComponent<BaseEnemy>();
                //Debug.Log(te.CurHP + ", " + amount);
                te.TakeDamage(amount);
            }
        }

        StartCoroutine("SkillDuration");
    }

    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(3f);
        Debug.Log("FireMage: Boom shakalaka = =");
        particleEffect.Stop();
        fireEffect.Stop();
        HeroAnimator.SetBool("Skill", false);
    }


    private void LoadSkill() {
        SkillTimer = 0f;
        SkillCooldownTime = FireMageConfig.SkillCooldownTime;
        SkillCDImage = GameObject.Find(CommonConfig.FireMageSkillCDImage).GetComponent<Image>();
        SkillCDImage.fillAmount = 0f;
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



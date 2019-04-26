using UnityEngine;

/// <summary>
/// Ice Mage
/// Slow down the enemies and give them DOT
/// </summary>
public class IceMage : Mage {
    public static IceMage instance;

    private static readonly object padlock = new object();

    [Header("Ice Mage Fileds")]
    public float damageOverTime = 0f;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    new void Start() {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new IceMage();
                }
            }
        }
        instance = this;

        HeroPool.GetInstance().SetHero(this, "IceMage");

        // Object.DontDestroyOnLoad(instance);
        LevelManager = new MageLeveling(this, IceMageConfig.Level);

        SkillIsReady = true;

        LoadAttr();

        //string json = JsonUtility.ToJson(ATK);

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("In IceMage");
    }

    protected override void Update() {
        if (this.Target == null) { 
            if (lineRenderer.enabled) {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        Laser();
    }


    public override void ExSkill() {
        Debug.Log("Ice Mage uses skill");
    }


    private void Laser() {
        this.TargetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        this.TargetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, this.Target.position);

        Vector3 dir = firePoint.position - this.Target.position;

        impactEffect.transform.position = this.Target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        CharacterName = IceMageConfig.CharacterName;
        CharacterDescription = IceMageConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(IceMageConfig.MaxHPValue);
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(IceMageConfig.ATKValue);
        MATK = new CharacterAttribute(IceMageConfig.MATKValue);

        PDEF = new CharacterAttribute(IceMageConfig.PDEFValue);
        MDEF = new CharacterAttribute(IceMageConfig.MDEFValue);

        Crit = new CharacterAttribute(IceMageConfig.CritValue);
        CritDMG = new CharacterAttribute(IceMageConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(IceMageConfig.PernetrationValue);
        ACC = new CharacterAttribute(IceMageConfig.ACCValue);
        Dodge = new CharacterAttribute(IceMageConfig.DodgeValue);
        Block = new CharacterAttribute(IceMageConfig.BlockValue);
        CritResistance = new CharacterAttribute(IceMageConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(IceMageConfig.ATKSpeedValue);

        //special
        damageOverTime = 0.75f * MATKValue;
        slowAmount = IceMageConfig.SlowAmount;
        Range = new CharacterAttribute(IceMageConfig.Range);
    }
}

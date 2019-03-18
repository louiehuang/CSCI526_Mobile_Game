using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Priest.
/// </summary>
public class Priest : BaseHero {
    public PriestLeveling LevelManager;
    private float healCountdown = 0f;

    private Transform targetHeroTransform;
    //public Transform Target { get; set; }

    private BaseHero targetHero;
    public BaseHero TargetHero { get; set; }

    new void Start() {
        LevelManager = new PriestLeveling(this, PriestConfig.Level);

        LoadAttr();

        InvokeRepeating("UpdateHeroTarget", 0f, 0.5f);
        Debug.Log("In Priest");
    }


    protected void UpdateHeroTarget() {
        //select hero based on current health
        //TODO: if mutiple heroes has same lowest health, give priority to DPS
        GameObject[] heroes = GameObject.FindGameObjectsWithTag(heroTag);
        float lowestHealth = Mathf.Infinity;
        GameObject heroToHeal = null;
        foreach (GameObject hero in heroes) {
            float heroHealth = hero.GetComponent<BaseHero>().CurHP;
            float distanceToHero = Vector3.Distance(transform.position, hero.transform.position);
            if (heroHealth < lowestHealth && distanceToHero <= RangeValue) {
                lowestHealth = heroHealth;
                heroToHeal = hero;
            }
        }

        if (heroToHeal != null) {
            targetHeroTransform = heroToHeal.transform;
            targetHero = heroToHeal.GetComponent<BaseHero>();
        } else {
            targetHeroTransform = null;
        }

        //update property
        this.Target = targetHeroTransform;
        this.TargetHero = targetHero;
    }


    protected override void Update() {
        if (this.Target == null) {
            return;
        }

        LockOnTarget();

        if (healCountdown <= 0f) {
            Heal();
            healCountdown = 1f / ATKSpeedValue;
        }

        healCountdown -= Time.deltaTime;
    }

    void Heal() {
        //float amount = 0.8f * MATKValue;
        //amount = TargetHero.CurHP + amount > TargetHero.MaxHPValue ? TargetHero.MaxHPValue - TargetHero.CurHP : amount;
        //TargetHero.TakeDamage(-amount); 
        //Debug.Log("heal: " + amount + ", current health: " + TargetHero.CurHP);
    }

    public override void UseSkill() {
        //hero on this node uses kill
        //TODO: consume energy, check CD
        ExSkill();
    }

    void ExSkill() {
        //heal heroes within a range
        float skillRange = 30f;

        GameObject[] heroes = GameObject.FindGameObjectsWithTag(heroTag);
        List<GameObject> heroesToHeal = new List<GameObject>();
        foreach (GameObject hero in heroes) {
            float distanceToHero = Vector3.Distance(transform.position, hero.transform.position);
            if (distanceToHero <= skillRange) {
                heroesToHeal.Add(hero);
            }
        }

        if (heroesToHeal.Count > 0) {
            float amount = 1.0f * MATKValue;
            foreach (GameObject hero in heroesToHeal) {
                BaseHero th = hero.GetComponent<BaseHero>();
                float realAmount = th.CurHP + amount > th.MaxHPValue ? th.MaxHPValue - th.CurHP : amount;
                th.TakeDamage(-realAmount);
                Debug.Log("Exskill, heal: " + realAmount + ", current health: " + TargetHero.CurHP);
            }
        }
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        CharacterName = PriestConfig.CharacterName;
        CharacterDescription = PriestConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(PriestConfig.MaxHPValue);
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(PriestConfig.ATKValue);
        MATK = new CharacterAttribute(PriestConfig.MATKValue);

        PDEF = new CharacterAttribute(PriestConfig.PDEFValue);
        MDEF = new CharacterAttribute(PriestConfig.MDEFValue);

        Crit = new CharacterAttribute(PriestConfig.CritValue);
        CritDMG = new CharacterAttribute(PriestConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(PriestConfig.PernetrationValue);
        ACC = new CharacterAttribute(PriestConfig.ACCValue);
        Dodge = new CharacterAttribute(PriestConfig.DodgeValue);
        Block = new CharacterAttribute(PriestConfig.BlockValue);
        CritResistance = new CharacterAttribute(PriestConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(PriestConfig.ATKSpeedValue);

        //special
        Range = new CharacterAttribute(PriestConfig.Range);
    }
}



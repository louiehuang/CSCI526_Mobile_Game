using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Priest.
/// </summary>
public class Priest : BaseHero {
    public PriestLeveling LevelManager;
    private float healCountdown = 0f;
    public string knightTag = "Knight";

    private Transform targetHeroTransform;
    //public Transform Target { get; set; }

    private BaseHero targetHero;
    public BaseHero TargetHero { get; set; }

    protected Animator animator;

    new void Start() {
        LevelManager = new PriestLeveling(this, PriestConfig.Level);

        SkillIsReady = true;
        animator = GetComponent<Animator>();

        LoadAttr();

        InvokeRepeating("UpdateHeroTarget", 0f, 0.5f);
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

        GameObject[] knights = GameObject.FindGameObjectsWithTag(knightTag);
        foreach (GameObject knight in knights) {
            float heroHealth = knight.GetComponent<BaseHero>().CurHP;
            float distanceToHero = Vector3.Distance(transform.position, knight.transform.position);
            if (heroHealth < lowestHealth && distanceToHero <= RangeValue) {
                lowestHealth = heroHealth;
                heroToHeal = knight;
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
            if (animator != null) {
                animator.SetBool("CanAttack", false);
            }
            return;
        }

        LockOnTarget();

        if (healCountdown <= 0f) {
            if (animator != null) {
                animator.SetBool("CanAttack", true);
            }
            Heal(TargetHero);
            healCountdown = 1f / ATKSpeedValue;
        }

        healCountdown -= Time.deltaTime;
    }

    void Heal(BaseHero hero) {
        float amount = 0.8f * MATKValue;
        float realAmount = hero.CurHP + amount > hero.MaxHPValue ? hero.MaxHPValue - hero.CurHP : amount;
        TargetHero.TakeDamage(-realAmount);
        //Debug.Log("heal: " + realAmount + ", current health: " + TargetHero.CurHP);
    }


    public override void ExSkill() {
        //TODO: consume energy
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

        GameObject[] knights = GameObject.FindGameObjectsWithTag(knightTag);
        foreach (GameObject knight in knights) {
            float distanceToHero = Vector3.Distance(transform.position, knight.transform.position);
            if (distanceToHero <= skillRange) {
                heroesToHeal.Add(knight);
            }
        }

        if (heroesToHeal.Count > 0) {
            float amount = 1.0f * MATKValue;
            foreach (GameObject hero in heroesToHeal) {
                Heal(hero.GetComponent<BaseHero>());
            }
        }
    }


    public override IEnumerator SkillCooldown() {
        yield return new WaitForSeconds(PriestConfig.SkillCooldownTime);
        SkillIsReady = true;
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



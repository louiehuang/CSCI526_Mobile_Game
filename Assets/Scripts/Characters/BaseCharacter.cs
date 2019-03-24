using UnityEngine;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour {
    //Stats Name Ref: http://www.kingsraid.wiki/index.php?title=Stats

    public string CharacterName { get; set; }
    public string CharacterDescription { get; set; }


    public CharacterAttribute MaxHP = new CharacterAttribute();
    public float MaxHPValue { get { return MaxHP.Value; } set { MaxHP.BaseValue = value; } }

    public float CurHP { get; set; }

    //attack range
    public CharacterAttribute Range;
    public float RangeValue { get { return Range.Value; } set { Range.BaseValue = value; } }

    //init attributes when needed
    public CharacterAttribute ATK;
    public float ATKValue { get { return ATK.Value; } set { ATK.BaseValue = value; } }

    public CharacterAttribute MATK;
    public float MATKValue { get { return MATK.Value; } set { MATK.BaseValue = value; } }

    public CharacterAttribute PDEF;
    public float PDEFValue { get { return PDEF.Value; } set { PDEF.BaseValue = value; } }

    public CharacterAttribute MDEF;
    public float MDEFValue { get { return MDEF.Value; } set { MDEF.BaseValue = value; } }

    public CharacterAttribute Crit;
    public float CritValue { get { return Crit.Value; } set { Crit.BaseValue = value; } }

    public CharacterAttribute CritDMG;
    public float CritDMGValue { get { return CritDMG.Value; } set { CritDMG.BaseValue = value; } }

    public CharacterAttribute Pernetration;
    public float PernetrationValue { get { return Pernetration.Value; } set { Pernetration.BaseValue = value; } }

    public CharacterAttribute ACC;
    public float ACCValue { get { return ACC.Value; } set { ACC.BaseValue = value; } }

    public CharacterAttribute Dodge;
    public float DodgeValue { get { return Dodge.Value; } set { Dodge.BaseValue = value; } }

    public CharacterAttribute Block;
    public float BlockValue { get { return Block.Value; } set { Block.BaseValue = value; } }

    public CharacterAttribute CritResistance;
    public float CritResistanceValue { get { return CritResistance.Value; } set { CritResistance.BaseValue = value; } }

    public CharacterAttribute ATKSpeed;
    public float ATKSpeedValue { get { return ATKSpeed.Value; } set { ATKSpeed.BaseValue = value; } }


    [Header("Unity Stuff")]
    public Image healthBar;
    public GameObject deathEffect;

    [Header("Other Attribute")]
    public int worth = 50;

    protected bool isDead;

    private void Awake() {
        CurHP = MaxHPValue;
    }

    protected virtual void Die() {
        isDead = true;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }


    //TODO: damage formula
    //need two object: hero and enemy
    public float CalculateDamageOnEnemy(BaseHero hero) {

        return 0f;
    }

    //TODO: take damage
    public void TakeDamage(float amount) {
        //Debug.Log(this.name+" damage "+CurHP +" - "+amount);
        CurHP -= amount;

        //still cause NullPointer Exception with following if-condition. So must be added a healthBar in the inspector
        if (healthBar != null) {
            healthBar.fillAmount = CurHP / MaxHPValue;
        }

        //Debug.Log(this.name + "CurHP " + CurHP + " amount = " + amount + " curHp is " + CurHP);
        if (CurHP <= 0 && !isDead) {
            Die();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour {
    //TODO: Inventory, Leveling

    private string characterName;
    private string characterDescription;


    //Stats Name Ref: http://www.kingsraid.wiki/index.php?title=Stats
    private CharacterAttribute maxHP;
    private CharacterAttribute aTK;
    private CharacterAttribute mATK;
    private CharacterAttribute pDEF;
    private CharacterAttribute mDEF;

    private CharacterAttribute crit;
    private CharacterAttribute critDMG;
    private CharacterAttribute pernetration;
    private CharacterAttribute aCC;
    private CharacterAttribute dodge;
    private CharacterAttribute block;
    private CharacterAttribute critResistance;

    private CharacterAttribute ATKSpeed;

    //public float startHealth = 100;
    //private float health;

    //public Image healthBar;

    //private bool isDead = false;

    public string CharacterName { get; set; }
    public string CharacterDescription { get; set; }

    public CharacterAttribute MaxHP { get; set; }
    public CharacterAttribute ATK { get; set; }
    public CharacterAttribute MATK { get; set; }
    public CharacterAttribute PDEF { get; set; }
    public CharacterAttribute MDEF { get; set; }

    public CharacterAttribute Crit { get; set; }
    public CharacterAttribute CritDMG { get; set; }
    public CharacterAttribute Pernetration { get; set; }
    public CharacterAttribute ACC { get; set; }
    public CharacterAttribute Dodge { get; set; }
    public CharacterAttribute Block { get; set; }
    public CharacterAttribute CritResistance { get; set; }
}

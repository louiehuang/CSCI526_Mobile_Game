using UnityEngine;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour {
    //Check whether it is OK to wear specific equipment

    //Inventory
    //Leveling
    //Items

    private string characterName;
    private string characterDescription;

    //Stats
    //https://home.gamer.com.tw/creationDetail.php?sn=1468884

    private float attack;  //ATK
    private float magicAttack;  //MAG
    private float attackSpeed;  //frequency
    private float range;  //attack range (distance)

    private float defense;
    private float magicDefense;
    private float resistance;
    private float magicResistance;

    private float hit;
    private float avoid;


    //public float startSpeed = 10f;
    //public float speed;

    //public float startHealth = 100;
    //private float health;

    //public Image healthBar;

    //private bool isDead = false;
    public string CharacterName { get; set; }
    public string CharacterDescription { get; set; }

    public float Attack { get; set; }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}

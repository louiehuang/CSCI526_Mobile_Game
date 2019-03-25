using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : BaseCharacter {

    public CharacterAttribute MoveSpeed;
    public float MoveSpeedValue { get { return MoveSpeed.Value; } set { MoveSpeed.BaseValue = value; } }
    [HideInInspector]
    public float speed;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Hero";
    public float range{get; set;}

    public GameObject canvas;

    private Transform target;
    private Transform attackTarget;

    public Transform Target { get; set; }
    public Transform AttackTarget { get; set; }

    void Start() {
        speed = MoveSpeedValue;
        CurHP = MaxHPValue;
        range = RangeValue;
        Debug.Log("Enemy initial: " + MoveSpeedValue + " CurHP " + CurHP + " Range " + range);
    }


    public void Slow(float pct) {
        speed = MoveSpeedValue * (1f - pct);
    }


    protected override void Die() {
        base.isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}

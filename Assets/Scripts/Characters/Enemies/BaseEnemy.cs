using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : BaseCharacter
{

    public CharacterAttribute MoveSpeed;
    public float MoveSpeedValue { get { return MoveSpeed.Value; } set { MoveSpeed.BaseValue = value; } }
    [HideInInspector]
    public float speed;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float range = 30f;

    private Transform target;

    public Transform Target { get; set; }

    void Start() {
        Debug.Log("Enemy initial: " + MoveSpeedValue);
        speed = MoveSpeedValue;
        CurHP = MaxHPValue;
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

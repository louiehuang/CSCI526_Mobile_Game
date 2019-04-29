using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BaseEnemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private BaseEnemy enemy;
    private Transform attackTarget;
    private Transform knightTarget;


    private string attackTag = "Hero";
    private float attackRange;

    private string stopTag = "Knight";
    private float stopRange = 8f;
    public float turnSpeed = 10f;

    void Start() {
        enemy = GetComponent<BaseEnemy>();

        this.attackTag = enemy.enemyTag;
        this.attackRange = enemy.RangeValue;

        Animation anim = GetComponent<Animation>();
        if(anim != null)
        {
            anim.wrapMode = WrapMode.Loop;
            anim.Play("Run");
        }

        target = Waypoints.points[0];

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        if (knightTarget != null)
        {
            dir = Vector3.zero;
        }
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= enemy.speed * Time.deltaTime + 0.2f) {
            GetNextWaypoint();
        }

        enemy.speed = enemy.MoveSpeedValue;
    }

    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
        LockOnTarget();
    }

    void EndPath() {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private Transform UpdateTarget(string tagName, float range) {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tagName);
        Transform curTransform = null;
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject heroTarget in targets) {
            float distanceToEnemy = Vector3.Distance(transform.position, heroTarget.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = heroTarget;
            }
        }
        if (nearestEnemy != null && shortestDistance < range) {
            curTransform = nearestEnemy.transform;
            //enemy.AttackTarget = targetTrans;
        } else {
            attackTarget = null;
        }
        return curTransform;
    }

    private Transform getNearesetTransform(Transform t1, Transform t2) {
        if (t1 == null && t2 == null) return null;
        if (t1 == null) return t2;
        if (t2 == null) return t1;
        float d1 = Vector3.Distance(transform.position, t1.position);
        float d2 = Vector3.Distance(transform.position, t2.position);
        if (d1 <= d2) return t1;
        return t2;
    }
    void UpdateTarget()
    {

        Transform attackTarget1 = UpdateTarget(attackTag, attackRange);
        Transform attackTarget2 = UpdateTarget(stopTag, attackRange);

        attackTarget = getNearesetTransform(attackTarget1, attackTarget2);
        enemy.AttackTarget = attackTarget;

        knightTarget = UpdateTarget(stopTag, stopRange);


    }

    protected void LockOnTarget() {
        Vector3 rtmp = enemy.canvas.transform.eulerAngles;
        Vector3 dir = target.position - transform.position;
        if (dir.Equals(Vector3.zero))
            return;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(enemy.transform.rotation, lookRotation, 1000f).eulerAngles;
        enemy.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        enemy.canvas.transform.eulerAngles = rtmp;
    }
}

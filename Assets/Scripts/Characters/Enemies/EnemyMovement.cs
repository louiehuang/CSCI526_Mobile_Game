using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BaseEnemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private BaseEnemy enemy;
    private Transform attackTarget;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Hero";
    public float range = 30f;

    void Start() {
        enemy = GetComponent<BaseEnemy>();
        Animation anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim.Play("Run");
        target = Waypoints.points[0];

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        if (attackTarget != null)
        {
            Debug.Log("see turret");
            dir = Vector3.zero;
        }
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
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
    }

    void EndPath() {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    void UpdateTarget()
    {
        GameObject[] heroTargets = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject heroTarget in heroTargets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, heroTarget.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = heroTarget;
            }
        }
        Debug.Log("shortestDistance  " + shortestDistance);
        if (nearestEnemy != null && shortestDistance < range)
        {
            Debug.Log("change attachTarget  " + shortestDistance);
            attackTarget = nearestEnemy.transform;
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            attackTarget = null;
        }
    }

}

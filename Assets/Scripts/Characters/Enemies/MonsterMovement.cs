using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BaseMonster))]
public class MonsterMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private BaseMonster enemy;

    void Start() {
        enemy = GetComponent<BaseMonster>();

        target = Waypoints.points[0];
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
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

}

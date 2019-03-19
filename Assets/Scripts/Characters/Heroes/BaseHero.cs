using UnityEngine;
using System.Collections;

public class BaseHero : BaseCharacter {

    private Transform target;
    public Transform Target { get; set; }

    private BaseEnemy targetEnemy; 
    public BaseEnemy TargetEnemy { get; set; }

    public bool SkillIsReady = true;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float attackRate = 1f;  //TODO: convert attackSpeed to attackRate
    private float attackCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string heroTag = "Hero";
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

    // Default initialization
    protected void Start() {
        Range = new CharacterAttribute(10f);  //default
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("Say something");
    }

    protected void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= RangeValue) {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<BaseEnemy>();
        } else {
            target = null;
        }

        //update property
        this.Target = target;
        this.TargetEnemy = targetEnemy;
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (target == null) {
            return;
        }

        LockOnTarget();

        if (attackCountdown <= 0f) {
            Attack();
            attackCountdown = 1f / attackRate;
        }

        attackCountdown -= Time.deltaTime;
    }

    protected void LockOnTarget() {
        Vector3 dir = Target.position - transform.position;
        if (dir.Equals(Vector3.zero))
            return;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    protected virtual void Attack() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    public void UseSkill() {
        if (SkillIsReady) {  // Check CD
            Debug.Log("use skill");
            SkillIsReady = false;
            ExSkill();  //TODO: for test
            StartCoroutine("SkillCooldown");
        } else {
            Debug.Log("skill not ready");
        }
    }

    public virtual void ExSkill() {
        //pass
    }

    public virtual IEnumerator SkillCooldown() {
        yield return new WaitForSeconds(15f);  //default cooldown time
        SkillIsReady = true;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeValue);
    }
}

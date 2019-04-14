using UnityEngine;
using System.Collections;

public class BaseHero : BaseCharacter {

    private Transform target;
    public Transform Target { get; set; }

    private BaseEnemy targetEnemy; 
    public BaseEnemy TargetEnemy { get; set; }

    public Animator HeroAnimator;

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

    // Skill bar
    public SkillUI skillUI;
    private Vector3 skillPos;  //used to fix skill ui position
    public static Vector3 positionOffset = new Vector3(0f, 5f, 0f);

    //[HideInInspector]
    //public HeroBlueprint heroBlueprint;
    //BuildManager buildManager;

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    // Default initialization
    protected void Start() {
        skillPos = skillUI.transform.eulerAngles;  
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("Say something");
    }


    //TODO: Create a HeroClicker script for listening click events? https://www.youtube.com/watch?v=0sFrDJKwsdM
    //Remeber to add box collider so to click this hero object
    void OnMouseDown() {
        if (!skillUI.IsActive) {
            skillUI.SetTarget(this);
            skillUI.Show();
        } else {
            skillUI.Hide();
        }
    }


    //public void SellSelf() {
    //    PlayerStats.Energy += heroBlueprint.GetSellAmount();

    //    GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
    //    Destroy(effect, 5f);

    //    Destroy(this);
    //    heroBlueprint = null;
    //}


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
            if (HeroAnimator != null) {
                HeroAnimator.SetBool("CanAttack", false);
            }
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
        skillUI.transform.eulerAngles = skillPos;  
    }


    protected virtual void Attack() {
        Debug.Log("1233");
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


    //TODO: damage formula
    public float CalculateHeroDamageOnEnemy(BaseEnemy enemy) {
        bool isCrit = (Random.Range(0f, 1f) > (CritValue - enemy.CritResistanceValue));
        bool isHit = (Random.Range(0f, 1f) > (ACCValue - enemy.DodgeValue));

        float damage = ((ATKValue - enemy.PDEFValue) + (MATKValue - enemy.MDEFValue)) * (isCrit ? 1.5f : 1.0f) * (isHit ? 1.0f : 0.0f);

        return damage;
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeValue);
    }
}

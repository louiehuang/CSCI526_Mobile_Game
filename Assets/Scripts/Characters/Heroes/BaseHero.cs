using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseHero : BaseCharacter {

    private Transform target;
    public Transform Target { get; set; }

    private BaseEnemy targetEnemy; 
    public BaseEnemy TargetEnemy { get; set; }

    public Animator HeroAnimator;

    protected bool SkillIsReady = true;

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

    // Skill CD
    public Image SkillCDImage;
    public float SkillTimer = 0f;
    public float SkillCooldownTime = 10f;  //default cooldown time
    protected bool HasSkillUsed = false;  //has the skill has ever been used?

    [HideInInspector]
    public GameObject hero;
    [HideInInspector]
    public HeroBlueprint heroBlueprint;

    //Hero Name and Health Bar
    private Vector3 heroCanvasPos;  //used to fix skill ui position


    // Default initialization
    void Start() {
        heroCanvasPos = HeroCanvas.transform.eulerAngles;

        //TODO: set skill image color

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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
        //Skill
        if (HasSkillUsed) {
            SkillTimer += Time.deltaTime;
            SkillCDImage.fillAmount = (SkillCooldownTime - SkillTimer) / SkillCooldownTime;
        }

        //Enemy
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

        HeroCanvas.transform.eulerAngles = heroCanvasPos;
    }


    protected virtual void Attack() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }


    public void UseSkill() {
        Debug.Log("skillCDImage: " + SkillCDImage);
        if (!HasSkillUsed || SkillTimer > SkillCooldownTime) {
            Debug.Log("Use skill");
            ExSkill();
            SkillTimer = 0;
        } else {
            Debug.Log("Skill not ready");
        }
        HasSkillUsed = true;
    }


    public virtual void ExSkill() {
        //pass
    }


    //TODO: damage formula
    public float CalculateHeroDamageOnEnemy(BaseEnemy enemy) {
        bool isCrit = (Random.Range(0f, 1f) > (CritValue - enemy.CritResistanceValue));
        bool isHit = (Random.Range(0f, 1f) > (ACCValue - enemy.DodgeValue));
        bool isBlock = (Random.Range(0f, 1f) > (enemy.BlockValue));

        if (!isHit) {
            return 0;
        }
        float damage = ((ATKValue > enemy.PDEFValue)? ATKValue - enemy.PDEFValue:0) + ((MATKValue > enemy.MDEFValue)? (MATKValue - enemy.MDEFValue):0) * (isCrit ? (1.0f+CritDMGValue) : 1.0f) * (isBlock ? 1.0f : 0.5f);
        return damage;
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeValue);
    }
}

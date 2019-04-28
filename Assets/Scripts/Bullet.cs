using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;

    public float critical = 0.0f;
    public float penertration = 0.0f;
    public float ACC = 0.0f;
    public float ATK = 20f;
    public float MATK = 0f;
    public float criticalDamage = 0f;

    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public float damage = 0f;

    public void Seek(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update() {

        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget() {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f) {
            Explode();
        } else {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {

        BaseCharacter e = enemy.GetComponent<BaseCharacter>();

        if (e != null) {
            damage = calculateDamage(e);
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


    private float calculateDamage(BaseCharacter e)
    {
        bool isCrit = (Random.Range(0f, 1f) > (critical - e.CritResistanceValue));
        bool isHit = (Random.Range(0f, 1f) < (ACC - e.DodgeValue));
        bool isBlock = (Random.Range(0f, 1f) > (e.BlockValue));

        if (!isHit)
        {
            return 0;
        }
        float res = ((ATK > e.PDEFValue) ? ATK - e.PDEFValue : 3f) + ((MATK > e.MDEFValue) ? (MATK - e.MDEFValue) : 3f) * (isCrit ? (1.0f + criticalDamage) : 1.0f) * (isBlock ? 1.0f : 0.5f);
        return res;
    }
}

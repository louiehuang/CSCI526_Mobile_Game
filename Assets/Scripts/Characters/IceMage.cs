using UnityEngine;

/// <summary>
/// Ice Mage
/// Slow down the enemies and give them DOT
/// </summary>
public class IceMage : Mage {

    [Header("Ice Mage Fileds")]
    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    new void Start() {
        range.BaseValue = 30f;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Debug.Log("In IceMage");
    }

    protected override void Update() {
        if (this.Target == null) { 
            if (lineRenderer.enabled) {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        Laser();
    }


    private void Laser() {
        this.TargetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        this.TargetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, this.Target.position);

        Vector3 dir = firePoint.position - this.Target.position;

        impactEffect.transform.position = this.Target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

}

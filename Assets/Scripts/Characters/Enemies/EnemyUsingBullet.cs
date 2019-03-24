using UnityEngine;
using UnityEngine.UI;

public class EnemyUsingBullet : BaseEnemy
{
    public GameObject bulletPrefab;
    public Transform firePoint;


    public float fireRate = 1f;
    private float fireCountdown = 0f;

        // Update is called once per frame
    void Update()
    {
        if(AttackTarget == null)
        {
            return;
        }


        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }


    void Shoot() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = ATKValue;
        //Debug.Log("attack damage" + bullet.damage);
        if (bullet != null)
            bullet.Seek(AttackTarget);
    }
}

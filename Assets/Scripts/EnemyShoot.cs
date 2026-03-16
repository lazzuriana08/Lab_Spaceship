using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    public float fireRate = 2f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, firePoint.position, Quaternion.identity);

        Bullet bulletScript = b.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.direction = -1;
        }
    }
}
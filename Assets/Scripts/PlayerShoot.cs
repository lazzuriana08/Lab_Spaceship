using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;     
    public Transform firePoint;    

    public float fireRate = 0.3f;  
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, firePoint.position, Quaternion.identity);

        Bullet bulletScript = b.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.direction = 1; 
        }
    }
}
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public int direction = 1;
    private bool hasHit = false;

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasHit) return;

        if (collision.CompareTag("Enemy") && direction == 1)
        {
            hasHit = true;
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
            }
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") && direction == -1)
        {
            hasHit = true;
            ScoreManager.instance.LoseLife();

            if (ScoreManager.instance.lives <= 0)
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
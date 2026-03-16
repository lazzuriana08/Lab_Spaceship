using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int pointsPenalty = -5;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -12f)
        {
            ScoreManager.instance.AddScore(pointsPenalty);
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        GameManager.instance.EnemyKilled(transform.position);
        Destroy(gameObject);
    }
}
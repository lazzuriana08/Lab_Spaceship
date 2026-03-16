using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    void Update()
    {
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveX, moveY, 0);


        transform.position += movement * speed * Time.unscaledDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.instance.LoseLife();
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            PowerUp power = collision.GetComponent<PowerUp>();
            if (power != null)
            {
                if (power.type == PowerUp.PowerUpType.Blue)
                {
                    ScoreManager.instance.AddLife(1);
                }
                else if (power.type == PowerUp.PowerUpType.Green)
                {

                    SlowMotion slow = FindFirstObjectByType<SlowMotion>();
                    if (slow != null) slow.ActivateSlow();
                }

                Destroy(collision.gameObject);
            }
        }
    }
}
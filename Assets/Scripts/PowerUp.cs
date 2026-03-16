using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { Blue, Green }
    public PowerUpType type;

    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -10)
            Destroy(gameObject);
    }
}
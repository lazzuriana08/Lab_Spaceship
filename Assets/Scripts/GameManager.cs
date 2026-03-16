using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int enemiesAlive = 0;
    private int enemiesKilledCounter = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartGame()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetForNewGame();
        }

        enemiesKilledCounter = 0;
        enemiesAlive = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void EnemySpawned()
    {
        enemiesAlive++;
    }

    public void EnemyKilled(Vector3 enemyPosition)
    {
        enemiesAlive--;
        ScoreManager.instance.AddScore(10);
        enemiesKilledCounter++;


        if (enemiesKilledCounter % 6 == 0)
            SpawnPowerUp(enemyPosition, PowerUp.PowerUpType.Green);
        else if (enemiesKilledCounter % 4 == 0)
            SpawnPowerUp(enemyPosition, PowerUp.PowerUpType.Blue);

        if (enemiesAlive <= 0)
            Victory();
    }

    void SpawnPowerUp(Vector3 position, PowerUp.PowerUpType type)
    {
        string prefabName = type == PowerUp.PowerUpType.Blue ? "PowerUpBlue" : "PowerUpGreen";
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        if (prefab != null)
            Instantiate(prefab, position, Quaternion.identity);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
}
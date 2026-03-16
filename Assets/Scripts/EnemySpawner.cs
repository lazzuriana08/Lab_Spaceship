using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 30;
    public float spawnRate = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(-4f, 4f);
        Vector3 spawnPos = new Vector3(10, randomY, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        GameManager.instance.EnemySpawned();
    }
}
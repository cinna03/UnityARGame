using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject meleeEnemyPrefab;
    public GameObject shooterEnemyPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;
    public float spawnDistance = 8f;

    private float nextSpawnTime;
    private Transform player;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.IsGamePlaying()) return;

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Random direction in front of player
        Vector3 randomOffset = new Vector3(
            Random.Range(-3f, 3f),
            0,
            Random.Range(0f, 3f)
        );

        Vector3 spawnPosition =
            player.position +
            player.forward * spawnDistance +
            randomOffset;

        spawnPosition.y = 1f;

        // Random enemy type
        GameObject enemyToSpawn =
            Random.value > 0.5f ? meleeEnemyPrefab : shooterEnemyPrefab;

        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }
}
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float initialSpawnRate = 5.0f;
    public float spawnRateMultiplier = 0.9f;
    public float minSpawnRate = 0.5f;
    public float spawnRadius = 5.0f;

    private float currentSpawnRate;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        InvokeRepeating("SpawnObject", currentSpawnRate, currentSpawnRate);
    }

    void SpawnObject()
    {
        Vector2 randomSpawnOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(transform.position.x + randomSpawnOffset.x, transform.position.y, transform.position.z + randomSpawnOffset.y);
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        currentSpawnRate *= spawnRateMultiplier;
        currentSpawnRate = Mathf.Max(currentSpawnRate, minSpawnRate);
        CancelInvoke();
        InvokeRepeating("SpawnObject", currentSpawnRate, currentSpawnRate);
    }
}
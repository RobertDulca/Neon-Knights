using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private void Awake()
    {
        instance = this;
    }
    public List<GameObject> prefabs;

    public List<Transform> spawnPoints;

    [SerializeField]
    private float initialSpawnInterval = 2f;

    [SerializeField]
    private float spawnIntervalDecrease = 0.1f;

    [SerializeField]
    private float spawnIntervalMin = 0.5f;

    [SerializeField]
    private float spawnIntervalChange = 60f;

    private float currentSpawnInterval;

    public void StartSpawning()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating(nameof(SpawnEnemy), 0f, currentSpawnInterval);
        Invoke(nameof(DecreaseSpawnInterval), spawnIntervalChange); // Decrease spawn interval after one minute
    }

    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);
    }

    void DecreaseSpawnInterval()
    {
        currentSpawnInterval -= spawnIntervalDecrease;
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, spawnIntervalMin);
    }
}

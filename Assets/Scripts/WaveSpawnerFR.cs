using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawnerFR : MonoBehaviour
{
    [Header("References")]
    public List<GameObject> prefabs;

    [Header("Attribute")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSeconds = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    public List<Transform> spawnPoints;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
        //Damit die nächste Wave starten kann muss jeder gegner destroyed werden
        //Gegner sind momentan nicht angreifbar und können ned destroyed werden
        //https://youtu.be/5j8A79-YUo0?t=1015
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        //Wenn eine gewisse Zeit vergangen ist und noch Gegner gespawnt werden sollen -> spawne Gegner
        if(timeSinceLastSpawn >= (1f / enemiesPerSeconds) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }
    private void SpawnEnemy()
    {
        Debug.Log("Enemy Spawned");
        //erstelle zufälligen Gegner -> prefabs.Count zählt Anzahl an Gegner die man einfügt
        int randomPrefabID = Random.Range(0, prefabs.Count);
        //entscheide durch Zufall auf welcher Seite der Gegner spawnt
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count); //0 oder 1
        //Den Gegner Spawnen
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}

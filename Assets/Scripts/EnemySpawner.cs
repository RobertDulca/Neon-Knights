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
    //Intervall f�r Gegner spawn (als Variable damit man sie bei Spielfortschritt erh�hen kann)
    public float spawnInterval = 2f;


    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());

        //StopAllCoroutines();
    }
    
    IEnumerator SpawnDelay()
    {
        //Spawnfunktion Aufrufen
        SpawnEnemy();
        //Intervall abwarten
        yield return new WaitForSeconds(spawnInterval);
        //Funktion nochmal aufrufen
        StartCoroutine(SpawnDelay());
    }
    

    //Spawnmechanik
    void SpawnEnemy()
    {
        //erstelle zuf�lligen Gegner -> prefabs.Count z�hlt Anzahl an Gegner die man einf�gt
        int randomPrefabID = Random.Range(0, prefabs.Count);
        //entscheide durch Zufall auf welcher Seite der Gegner spawnt
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count); //0 oder 1
        //Den Gegner Spawnen
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);
    }
}

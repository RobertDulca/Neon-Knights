using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay()
    {
        //Paar Skunden warten bevor Spawning beginnt
        //yield return new WaitForSeconds(5f);
        yield return new WaitForSeconds(1f);
        //Gegnerspawning aufrufen
        GetComponent<EnemySpawner>().StartSpawning();
    }
}

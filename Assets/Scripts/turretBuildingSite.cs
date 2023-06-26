using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turettBuildingSite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bf;
    public bool isInRange;
    public KeyCode interactKey;
    private bool wallMade;
    public GameObject constructedBuildingPrefab;
    private ScoreScript scoreScript;
    private GameObject newWall;

    [SerializeField] private int cost = 2;

    private void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
        wallMade = false;
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey) && !wallMade && scoreScript.GetCoinCount() >= cost)
            {
                bf.enabled ^= true;
                wallMade = true;
                Vector3 newPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
                newWall = Instantiate(constructedBuildingPrefab, newPosition, transform.rotation, transform); // Set the parent as the BuildField object
                scoreScript.SetCoinCount(scoreScript.GetCoinCount() - cost);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            isInRange = false;
        }
    }
}

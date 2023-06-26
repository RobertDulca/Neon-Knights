using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildField : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bf;
    public bool isInRange;
    public KeyCode interactKey;
    private bool wallMade;
    public GameObject constructedBuildingPrefab;
    private ScoreScript scoreScript;
    private GameObject newWall;

    [SerializeField] private int cost = 1;

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
                newWall = Instantiate(constructedBuildingPrefab, transform.position, transform.rotation, transform); // Set the parent as the BuildField object
                scoreScript.SetCoinCount(scoreScript.GetCoinCount() - cost);
            }
        }
        else if (!isInRange && wallMade && newWall != null && newWall.GetComponent<buildingHealth>() != null && newWall.GetComponent<buildingHealth>().health <= 0)
        {
            WallDestroyed();
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

    public void WallDestroyed()
    {
        wallMade = false;
        bf.enabled = true;
        newWall = null; // Reset the reference to allow building a new wall
    }
}

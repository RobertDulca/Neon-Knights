using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildField : MonoBehaviour
{
    /*[Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    
    private GameObject wall;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (wall != null) return;

        GameObject wallToBuild = BuildManager.main.GetSelectedWall();
        wall  = Instantiate(wallToBuild, transform.position, Quaternion.identity);
        sr.enabled ^= true;
    }*/

    [SerializeField] private SpriteRenderer bf;
    public bool isInRange;
    public KeyCode interactKey;
    private bool wallMade;
    public GameObject constructedBuildingPrefab;
    private ScoreScript scoreScript;
    private GameObject newWall;

    [SerializeField] private int cost=1;
    private void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
        wallMade = false;
    }
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey) && scoreScript.GetCoinCount()>=cost)//check if its is greater than one
            {
                
                bf.enabled ^= true;
                wallMade = true;
                newWall = Instantiate(constructedBuildingPrefab, transform.position, transform.rotation);
                scoreScript.SetCoinCount(scoreScript.GetCoinCount()-cost);
            }
        }
        if(newWall != null && newWall.GetComponent<buildingHealth>() != null && newWall.GetComponent<buildingHealth>().health <= 0 && wallMade){
            bf.enabled = true;
            wallMade = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            isInRange = true;
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                //Destroy(gameObject); // Destroy the destroyed 
                sr.enabled ^= true;
                Instantiate(constructedBuildingPrefab, transform.position, transform.rotation);
            }*/
        }
    }
}

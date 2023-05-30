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

    [SerializeField] private SpriteRenderer sr;
    public bool isInRange;
    public KeyCode interactKey;

    public GameObject constructedBuildingPrefab;

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                sr.enabled ^= true;
                Instantiate(constructedBuildingPrefab, transform.position, transform.rotation);
            }
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

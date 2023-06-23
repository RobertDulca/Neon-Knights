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
    private buildingHealth healthWall;

    private void Start() {
        healthWall = constructedBuildingPrefab.GetComponent<buildingHealth>();
        wallMade = false;
    }
    void Update()
    {
        healthWall = constructedBuildingPrefab.GetComponent<buildingHealth>();
        if (isInRange && !wallMade)
        {
            if (Input.GetKeyDown(interactKey))
            {
                bf.enabled ^= true;
                wallMade = true;
                Instantiate(constructedBuildingPrefab, transform.position, transform.rotation);
            }
        }

        if(!healthWall.healthState && wallMade){
            constructedBuildingPrefab.SetActive(false);
            bf.enabled = true;
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
}

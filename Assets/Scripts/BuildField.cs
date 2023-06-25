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
    private GameObject newWall;

    private void Start() {
        wallMade = false;
    }
    void Update()
    {
        if (isInRange && !wallMade)
        {
            if (Input.GetKeyDown(interactKey))
            {
                bf.enabled ^= true;
                wallMade = true;
                newWall = Instantiate(constructedBuildingPrefab, transform.position, transform.rotation);
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
        }
    }
}

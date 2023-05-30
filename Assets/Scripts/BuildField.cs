using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildField : MonoBehaviour
{
    [Header("References")]
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public bool healthState;
    public SpriteRenderer wallDamage;
    private BuildField buildField;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        wallDamage.enabled = false;
        healthState = true;
        buildField = GetComponentInParent<BuildField>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Wall is destroyed
            Destroy(gameObject);

            // Notify BuildField that the wall is destroyed
            if (buildField != null)
            {
                buildField.WallDestroyed();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy"); // Set the layer name of the enemy layer

        if (collision.gameObject.layer == enemyLayer)
        {
            // Damage the wall
            TakeDamage(2);
        }
    }

    void Update()
    {
        if (health < maxHealth * 0.8)
        {
            wallDamage.enabled = true;
        }
    }
}

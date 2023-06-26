using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public bool healthState;
    public SpriteRenderer wallDamage;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        wallDamage.enabled ^= true;
        healthState = true;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy"); // Set the layer name of the enemy layer

        if (collision.gameObject.layer == enemyLayer)
        {
            // Damage the player
            TakeDamage(2);
        }
    }

    void Update(){
        if(health < maxHealth*0.8){
            wallDamage.enabled = true;        
        }
    }
}

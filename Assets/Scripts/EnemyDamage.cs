using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public buildingHealth playerHealth;
    public int damage = 2;

    // Called when the enemy collides with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Damage the player
            playerHealth.TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turettBulletManager : MonoBehaviour
{
    public float speed = 10f; // Adjust the bullet speed as needed

    private Transform target;

   private int turretDamage = 1; //DAMGE HIER

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        
        // Move the bullet towards the target enemy
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle bullet collision with the enemy or other objects if needed
        if (collision.CompareTag("Enemy"))
        {
            // Apply damage or destroy the enemy
            //Destroy(collision.gameObject);
            collision.GetComponent<Health>().TakeDamge(turretDamage);
            Destroy(this.gameObject);
        }
    }
}

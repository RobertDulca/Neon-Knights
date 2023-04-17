using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private int MAX_HEALTH = 100;

    void Start()
    {
        Debug.Log("Health script start");
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
        }

        bool maxHealthCap = health + amount > MAX_HEALTH;

        if (maxHealthCap)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class playerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("You died");
            RestartScene();
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}

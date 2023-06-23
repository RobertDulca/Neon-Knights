using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public TimerUI timerUI;
    private float startTime;
    private ScoreScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        scoreScript = FindObjectOfType<ScoreScript>();
        Initialize();
    }

    private void Initialize()
    {
        if (timerUI != null)
        {
            timerUI.ResetTimer();
            Debug.Log("Timer Initialized");
            startTime = Time.time;
        }
        else
        {
            //Debug.LogWarning("TimerUI reference is null");
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("You died");
            float survivalTime = Time.time - startTime;
            int coinCount = scoreScript.GetCoinCount();
            Debug.Log("Survived for: " + survivalTime.ToString("F2") + " seconds");
            Debug.Log("Coins collected: " + coinCount);
            RestartScene();
        }
    }

    private void ResetTimer()
    {
        if (timerUI != null)
        {
            timerUI.ResetTimer();
            Debug.Log("Timer Reset");
        }
        else
        {
            //Debug.LogWarning("TimerUI reference is null");
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
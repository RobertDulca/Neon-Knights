using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Leben, Angriffsst�rke, Geschwindigkeit
    public int health, attackPower;
    public float moveSpeed;
    public GameObject coinPrefab;

    void Update()
    {
        Move();
    }
    //Bewegen zum Turm
    void Move()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }
    //Leben verlieren
    void LoseHealth()
    {
        //Leben abziehen
        health--;
        //Hurt animation abspielen/Spritefarbe kurz auf rot setzen
        StartCoroutine(BlinkRed());
        //Checken ob Leben = 0, wenn ja Objekt zerst�ren
        if (health <= 0)
        {
            DropCoin();
            Destroy(gameObject);
        }
    }
    IEnumerator BlinkRed()
    {
        //Die Farbe vom Sprite auf Rot �ndern
        GetComponent<SpriteRenderer>().color = Color.red;
        //Kurze Zeit warten
        yield return new WaitForSeconds(0.2f);
        //Farbe auf Wei� zur�ck setzen --> Sprite wird normal
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void DropCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}

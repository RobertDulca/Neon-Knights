using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private Animator anim;
    public bool dead=false;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    public GameObject coinPrefab;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();        
    }
    public void TakeDamge(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if( currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
        }
        else 
        {
            if (!dead) 
            {
                gameObject.layer = 16;
                anim.SetTrigger("die");
                
                /*if(GetComponent<playerMovement>() != null) 
                { 
                    GetComponent<playerMovement>().enabled= false;
                }

                if(GetComponent<MeleeEnemy>() != null) 
                { 
                    GetComponent<MeleeEnemy>().enabled= false;
                }*/
                DropCoin();
                foreach(Behaviour component in components) 
                {
                    component.enabled = false;
                }

                dead = true;
            }
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void DropCoin()
    {
        GameObject spawnedCoin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}

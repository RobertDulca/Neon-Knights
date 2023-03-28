using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed; //[SerializeField] macht, dass man die Variable im Objekt ändern kann
    [SerializeField] private float jump;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake() //Awake Funktion wird immer aufgerufen wenn das Player script aufgerufen wird
    {
        body = GetComponent<Rigidbody2D>(); //GetComponent durchsucht das Objekt auf dem das script ist nach Rigidbody2D component
        anim = GetComponent<Animator>();
    }

    private void Update() //Update-Funktionen werden jeden Frame aufgerufen
    {
        // größer 0 = Player geht nach rechts und kleiner 0 = Player geht nach links
        float horizontalInput = Input.GetAxis("Horizontal");

        //Input.GetAxis("Horizontal") nimmt 'a' and 'd' als Input und bewegt den Player in die entsprechende Richtung
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player model wenn man nach links geht
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
        //Rechts ist eine Abfrage die entweder True oder False ist und je nach dem wird die Variable "run" verändert
        //horizontalInput == 0 bedeutet man steht still
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        anim.SetTrigger("jump");
        grounded = false;
    }

    //OnCollisionEnter2D wird immer aufgerufen wenn 2 Objekte mit BoxColliders zusammenstoßen
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}

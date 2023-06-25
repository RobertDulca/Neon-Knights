using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed; //[SerializeField] macht, dass man die Variable im Objekt �ndern kann
    [SerializeField] private float jump;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    private void Awake() //Awake Funktion wird immer aufgerufen wenn das Player script aufgerufen wird
    {
        body = GetComponent<Rigidbody2D>(); //GetComponent durchsucht das Objekt auf dem das script ist nach Rigidbody2D component
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update() //Update-Funktionen werden jeden Frame aufgerufen
    {
        // gr��er 0 = Player geht nach rechts und kleiner 0 = Player geht nach links
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

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("pullgun", true);
        }
        else
        {
            anim.SetBool("pullgun", false);
        }
        //Rechts ist eine Abfrage die entweder True oder False ist und je nach dem wird die Variable "run" ver�ndert
        //horizontalInput == 0 bedeutet man steht still
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        anim.SetTrigger("jump");
    }
    //raycast �berpr�ft ob die Hitbox des Spielers Ground unter sich hat, wenn nicht return es null
    //Die Funktion gibt also true zur�ck wenn Ground unter dem Spieler ist und False wenn das nicht der Fall ist
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }
}

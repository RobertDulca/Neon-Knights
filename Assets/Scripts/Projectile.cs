using UnityEditor;
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;
    private float maxLifetime = 0.5f; //LifetimeHier

    private Animator anim;
    private BoxCollider2D boxCollider;

    private int bulletDamage = 1; //DAMAGE HIER

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > maxLifetime && !hit)
        {
            hit = true; // Prevent this block from running repeatedly
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
            StartCoroutine(DeactivateAfterAnimation());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamge(bulletDamage); 
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private IEnumerator DeactivateAfterAnimation()
    {
        // Assumes the animation length is 1 second; change this to your actual animation length
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}

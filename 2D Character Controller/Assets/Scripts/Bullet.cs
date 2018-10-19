using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;

    public Rigidbody2D rb2d;

    public Animator animator;

    bool direction = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (direction) 
        {
            rb2d.velocity = transform.right * speed;
        } else
        {
            rb2d.velocity = transform.up * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Impact", true);
        rb2d.velocity = new Vector2(0, 0);
        Invoke("DestroyBullet", 0.5f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void SetDirection(bool newDirection)
    {
        direction = newDirection;
    }
}

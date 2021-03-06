using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;

    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();

        if (bounceForce <= 0)
        {
            bounceForce = 20.0F;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "squish")
        {
            if (!pm.isGrounded)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                GameManager.instance.score++;
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);
             }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyProjectile")
        {
            GameManager.instance.lives--;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.lives--;
            Destroy(gameObject);
            
        }    
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyTurret : MonoBehaviour
{
    public Transform projectileSpawnPointRight;
    public Transform projectileSpawnPointLeft;
    public Projectile projectilePrefab;
    SpriteRenderer sr;

    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public int health;

    Animator anim;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 turretTransform;
        Vector2 playerTransform;
        turretTransform = transform.position;
        playerTransform = player.position;
        if (Vector2.Distance(playerTransform, turretTransform) <= 10)
        {
            Debug.Log("close");
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                if (playerTransform.x >= turretTransform.x)
                {
                    sr.flipX = false;
                    anim.SetBool("Fire", true);
                    ;
                    
                }
                else
                {
                    sr.flipX = true;
                    anim.SetBool("Fire", true);
                    
                    
                }
                timeSinceLastFire = Time.time;
            }

        }


        
    }

    public void Fire()
    {
        if (sr.flipX)
        {
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            temp.speed = -projectileForce;
        }
        else
        {
            
                Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
                temp.speed = projectileForce;
           }
        
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0){
                Destroy(gameObject);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES,
        KEY
    }

    public CollectibleType currentCollectible;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player")
        {
            
            switch (currentCollectible)
            {
                case CollectibleType.POWERUP:
                    Destroy(gameObject);
                    coll.GetComponent<PlayerMovement>().StartJumpForceChange();
                    
                    Destroy(gameObject);
                    break;
                case CollectibleType.LIVES:
                        Destroy(gameObject);
                    coll.GetComponent<PlayerMovement>().lives++;
                    Destroy(gameObject);
                     break;
                case CollectibleType.COLLECTIBLE:
                    Destroy(gameObject);
                    coll.GetComponent<PlayerMovement>().score++;
                     
                    break;
            }
            
        }
        else if (coll.gameObject.layer == 6)
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}

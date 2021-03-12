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
                    
                    coll.GetComponent<PlayerMovement>().StartJumpForceChange();
                    
                    Destroy(gameObject);
                    break;
                case CollectibleType.LIVES:

                    GameManager.instance.lives++;
                    Destroy(gameObject);
                     break;
                case CollectibleType.COLLECTIBLE:

                    GameManager.instance.score++;
                    Destroy(gameObject);
                    break;
            }
            
        }
        else if (coll.gameObject.layer == 6)
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}

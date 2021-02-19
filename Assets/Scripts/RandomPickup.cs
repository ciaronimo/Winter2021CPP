using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickup : MonoBehaviour
{

    public PowerUp[] pickupList;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pickupList[Random.Range(0, pickupList.Length)].gameObject, transform.position, Quaternion.identity);
    }

    // Update is called once per frame

}

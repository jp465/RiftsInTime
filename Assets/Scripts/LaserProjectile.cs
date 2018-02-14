using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            Debug.Log("Destroy laser");
            Destroy(gameObject);
        }
    }
}

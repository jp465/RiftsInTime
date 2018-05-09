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

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Destroy laser");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

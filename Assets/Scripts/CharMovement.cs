using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {
    public Vector3 velocity;
    public bool isGrounded;
    public LayerMask groundLayer;
    // Use this for initialization
    void Start () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
            isGrounded = true;
        Vector3 dir = collision.contacts[0].point - (Vector2)transform.position;
        if (dir.x != 0)
        {
            transform.position -= new Vector3(2* velocity.x * Time.deltaTime, 0);
            velocity.x = 0;
        }
        if (dir.y != 0)
        {
            transform.position -= new Vector3(0, 2* velocity.y * Time.deltaTime);
            velocity.y = 0;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
            isGrounded = true;
        Vector3 dir = collision.contacts[0].point - (Vector2)transform.position;
        if (dir.x != 0)
        {
            transform.position -= new Vector3(velocity.x * Time.deltaTime, 0);
            velocity.x = 0;
        }
        if (dir.y != 0)
        {
            transform.position -= new Vector3(0, velocity.y * Time.deltaTime);
            velocity.y = 0;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
            isGrounded = false;
    }
        // Update is called once per frame
        void Update () {

        if (!isGrounded)
        {
            velocity += Physics.gravity * Time.deltaTime;
        }
       
        transform.position += velocity * Time.deltaTime;
	}

    

}

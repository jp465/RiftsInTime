using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewindable : MonoBehaviour {
    LevelManager LM;
    List<PointInTime> pointsInTime;
    Rigidbody2D rb2d;
    SpriteRenderer sprRen;
    int dir;
    public bool usesSprRen;
    // Use this for initialization
    void Start () {
        LM = FindObjectOfType<LevelManager>();
        rb2d = GetComponent<Rigidbody2D>();
        pointsInTime = new List<PointInTime>();
        sprRen = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(LM.timeRewind)
        {
            rb2d.isKinematic = true;
            Rewind();
        }
        else if(!LM.timeRewind)
        {
            rb2d.isKinematic = false;
            Record();
        }
	}

    void Record()
    {
        if(pointsInTime.Count > Mathf.Round(5f / Time.fixedDeltaTime))
        {
            //pointsInTime.RemoveLast();
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        
        if (rb2d.velocity.x > 0)
        {
            dir = 1;
        }
        else if (rb2d.velocity.x < 0)
        {
            dir = -1;
        }else
        {
            dir = 0;
        }
        pointsInTime.Insert(0, new PointInTime(transform.position,transform.rotation,dir));
       // pointsInTime.AddFirst(new PointInTime(transform.position, transform.rotation));
    }

    void Rewind()
    {
        
        if(pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            //PointInTime pointInTime = pointsInTime.First;
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            if (usesSprRen)
            {
                if (pointInTime.direction == 1)
                {
                    sprRen.flipX = false;
                }
                else if (pointInTime.direction == -1)
                {
                    sprRen.flipX = true;
                }
            }
            else
            {
                if (pointInTime.direction == 1)
                {
                    transform.localScale = new Vector3(1f,1f,1f);
                }
                else if (pointInTime.direction == -1)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
            pointsInTime.RemoveAt(0);
            //pointsInTime.RemoveFirst();
            
        }
        else
        {
            Debug.Log("Rewind Test1");
            LM.timeRewind = false;
        }
       
    }
}

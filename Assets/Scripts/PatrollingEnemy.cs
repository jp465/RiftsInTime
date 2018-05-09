using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour {

    public float walkSpeed;
    Rigidbody2D RB2D;
    SpriteRenderer sprRen;
    LevelManager LM;
    public Animator anim;
    
    [SerializeField]
    Transform startPos, endPos;
    bool isColliding;

    void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        sprRen = GetComponent<SpriteRenderer>();
        LM = FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();
    }

    void Start () {
	
	}
	
	void FixedUpdate () {
        Move();
        ChangeDirection();
        
        if (LM.timeStopped == true)
        {
            anim.speed = 0;
        }
        else
        {
            anim.speed = 1f;
        }
        
    }

    void Move()
    {
        RB2D.velocity = new Vector3(transform.localScale.x,0f,0f)* walkSpeed *LM.stoppedMod;
    }

    void ChangeDirection()
    {
        isColliding = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPos.position,endPos.position,Color.red);
        if (!isColliding)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
    }
}

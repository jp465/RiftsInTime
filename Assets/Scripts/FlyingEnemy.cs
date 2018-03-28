﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    public Transform startPos;
    public Transform endPos;
    public float moveSpeed;
    public Vector3 currentTarget;
    LevelManager LM;
    public Animator anim;

    // Use this for initialization
    void Start () {
        currentTarget = endPos.position;
        LM = FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (LM.timeSlowed == true)
        {
            anim.speed = LM.slowMod;
        }
        else
        {
            anim.speed = 1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime*LM.slowMod);
        if (transform.position == endPos.position)
        {
            currentTarget = startPos.position;
        }
        else if (transform.position == startPos.position)
        {
            currentTarget = endPos.position;
        }


    }
}

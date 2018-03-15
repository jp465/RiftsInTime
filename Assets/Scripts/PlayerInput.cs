using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerController player;
    private bool isJumping;
    private float dir;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }


    private void Update()
    {
        if (!isJumping)
        {
            // Read the jump input in Update so button presses aren't missed.
            isJumping = Input.GetKeyDown(LevelManager.LM.jump);
            Debug.Log("isJumping = " + isJumping);
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.

        if (Input.GetKey(LevelManager.LM.right))
            dir = 1;
        else if (Input.GetKey(LevelManager.LM.left))
            dir = -1;
        else
            dir = 0;
        
        
        Debug.Log("dir = " + dir);

        // Pass all parameters to the character control script.
        player.playerMovementController(dir, isJumping);
        isJumping = false;
    }
}

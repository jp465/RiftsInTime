using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerController player;
    private bool isJumping;
    private float dir;
    LevelManager LM;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        LM = FindObjectOfType<LevelManager>();
    }


    private void Update()
    {
        if (!isJumping)
        {
            // Read the jump input in Update so button presses aren't missed.
            isJumping = Input.GetKeyDown(InputManager.IM.jump);
            
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.

        if (Input.GetKey(InputManager.IM.right) && !LM.timeRewind)
            dir = 1;
        else if (Input.GetKey(InputManager.IM.left) && !LM.timeRewind)
            dir = -1;
        else
            dir = 0;
        
        

        // Pass all parameters to the character control script.
        player.playerMovementController(dir, isJumping);
        isJumping = false;
    }
}

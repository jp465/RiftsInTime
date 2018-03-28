using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatScript : MonoBehaviour {

    public InputField input;
    public Text tmtext;
    PlayerController player;
	// Use this for initialization
	void Start () {
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitCheat);
        input.onEndEdit = se;
        tmtext.text = "";
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
      
	}

    public void SubmitCheat(string cheatText)
    {
        input.text = "";
        
        if (cheatText == "unlocklevel100")
        {
            Debug.Log("cheat success");
            tmtext.text = "All Skill Points Awarded!";
            player.playerSkillPoints = 100;
            Debug.Log("Player Skill points = " + player.playerSkillPoints);
        }
        else
        {
            Debug.Log("cheat fail");
            tmtext.text = "Invalid Cheat Code";

        }
    }


}

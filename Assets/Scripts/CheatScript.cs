using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatScript : MonoBehaviour {

    public InputField input;
    
    
	// Use this for initialization
	void Start () {
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitCheat);
        input.onEndEdit = se;
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    public void SubmitCheat(string cheatText)
    {
        input.text = "";
        
        if (cheatText == "test")
        {
            Debug.Log("tester");
        }
        else
        {
            Debug.Log("fail");
        }
        
    }


}

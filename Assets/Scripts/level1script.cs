using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1script : MonoBehaviour {

   
    // Use this for initialization
    void Start () {
		PlayerPrefs.SetString("nextScene","level2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

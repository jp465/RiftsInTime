using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillsManager : MonoBehaviour {

    PlayerController player;
    public static skillsManager SM;

    private void Awake()
    {

        if (SM == null)
        {
            DontDestroyOnLoad(gameObject);
            SM = this;
        }
        else if (SM != this)
        {
            Destroy(gameObject);
        }
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

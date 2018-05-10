using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSign : MonoBehaviour {

    public GameObject signMenu;
    public void CloseMenu()
    {
        signMenu.gameObject.SetActive(false);
       
    }

   
}

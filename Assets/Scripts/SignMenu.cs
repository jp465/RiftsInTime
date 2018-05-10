using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignMenu : MonoBehaviour {

    public GameObject signMenu;
    public bool open = false;
    public string inputSignText;
    public Text SignText;
    Animator anim;

    private void Awake()
    {
        anim = signMenu.GetComponent<Animator>();
        signMenu.SetActive(false);
    }
    // Use this for initialization
    void Start () {


        
    }
	
	// Update is called once per frame
	void Update () {
        
     
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(InputManager.IM.interact)&& open==false)
        {
            SignText.text = inputSignText;


            signMenu.gameObject.SetActive(true);
            open = true;
            
            anim.SetBool("open",false);

            

        }
       
        
    }
    
    public void CheckForPauseTime()
    {
        if (open == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Close()
    {


        open = false;
        

        anim.SetBool("close", true);
        
    }
 

}

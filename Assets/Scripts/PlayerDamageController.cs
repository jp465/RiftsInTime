using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour {

	private PlayerController player;
	public int damageToPlayer;
	public AudioClip damage;
    public float waitTimeToDealDamageAgain;
    float timeRemaining;
    bool canCauseDamage=true;
    // Use this for initialization
    void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
        }
	}
    
	void OnTriggerStay2D(Collider2D other){
		if(other.tag=="Player"&&timeRemaining<0){
            player.playerDamage(damageToPlayer);
            player.updateUI();
			if(player.currentHealth<=0){
                LevelManager.LM.Respawn();
			}
            
            timeRemaining = waitTimeToDealDamageAgain;
		}
	} 
}

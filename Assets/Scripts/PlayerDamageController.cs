using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour {

	private PlayerController player;
	public int damageToPlayer;
	public AudioClip damage;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
            player.playerDamage(damageToPlayer);
            player.updateUI();
			if(player.currentHealth<=0){
                LevelManager.LM.Respawn();
			}
		}
	}
}

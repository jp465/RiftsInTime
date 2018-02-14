using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour {

	private LevelManager levMan;
	public int damageToPlayer;
	public AudioClip damage;
	// Use this for initialization
	void Start () {
		levMan = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			//AudioSource.PlayClipAtPoint(damage,transform.position);
			levMan.playerDamage(damageToPlayer);
			levMan.updateUI();
			if(levMan.currentHealth<=0){
				levMan.Respawn();
			}
		}
	}
}

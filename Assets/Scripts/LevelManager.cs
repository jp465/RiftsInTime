using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public PlayerController player;

	//Respawn
	public float respawnDelay;
	public GameObject deathParticles;

	//Coins
	public Text coinCounterText;

	//Health
	public int maxHealth;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		coinCounterText.text = "Coins: "+0;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Respawn(){
		currentHealth = 0;
		updateUI();
		StartCoroutine("RespawnDelayCo");
        currentHealth = 0;
        updateUI();
    }

	public IEnumerator RespawnDelayCo(){
        Instantiate(deathParticles,player.transform.position,player.transform.rotation);
		player.gameObject.SetActive(false);
		yield return new WaitForSeconds(respawnDelay);
		player.transform.position = player.respawnLocation;
		player.gameObject.SetActive(true);
		currentHealth=maxHealth;
		updateUI();
	}

	public void updateUI(){
		coinCounterText.text = "Coins: "+PlayerPrefs.GetInt("coins");
	}

	public void playerDamage(int damage){
		currentHealth-=damage;
	}
/*
	public void updateHearts(){
		switch(currentHealth){
			case 8: heart1.sprite=fullHeart;
					heart2.sprite=fullHeart;
					heart3.sprite=fullHeart;
					heart4.sprite=fullHeart;
					return;

			case 7: heart1.sprite=fullHeart;
					heart2.sprite=fullHeart;
					heart3.sprite=fullHeart;
					heart4.sprite=halfHeart;
					return;

			case 6: heart1.sprite=fullHeart;
					heart2.sprite=fullHeart;
					heart3.sprite=fullHeart;
					heart4.sprite=emptyHeart;
					return;

			case 5: heart1.sprite=fullHeart;
					heart2.sprite=fullHeart;
					heart3.sprite=halfHeart;
					heart4.sprite=emptyHeart;
					return;

			case 4: heart1.sprite=fullHeart;
					heart2.sprite=fullHeart;
					heart3.sprite=emptyHeart;
					heart4.sprite=emptyHeart;
					return;

			case 3: heart1.sprite=fullHeart;
					heart2.sprite=halfHeart;
					heart3.sprite=emptyHeart;
					heart4.sprite=emptyHeart;
					return;

			case 2: heart1.sprite=fullHeart;
					heart2.sprite=emptyHeart;
					heart3.sprite=emptyHeart;
					heart4.sprite=emptyHeart;
					return;

			case 1: heart1.sprite=halfHeart;
					heart2.sprite=emptyHeart;
					heart3.sprite=emptyHeart;
					heart4.sprite=emptyHeart;
					return;

			case 0: heart1.sprite=emptyHeart;
					heart2.sprite=emptyHeart;
					heart3.sprite=emptyHeart;
					heart4.sprite=emptyHeart;
					return;

			default:heart1.sprite=emptyHeart;
					heart2.sprite=emptyHeart;
					heart3.sprite=emptyHeart;
					heart4.sprite=emptyHeart;
					return;
		}
	}
*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private LevelManager levMan;
	public int coinValue;
	private int testcoins;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			player.addCoin(coinValue);
			Destroy(gameObject);
			testcoins=player.wallet;
			Debug.Log(testcoins);
		}
	}
}

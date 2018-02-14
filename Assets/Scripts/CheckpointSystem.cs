using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour {

	public Sprite deactivatedCheckpoint; 
	private SpriteRenderer sprRen;
	public bool isCheckpointActive;
	private Animator checkpointAnim;

	void Start () {
		sprRen = GetComponent<SpriteRenderer>();
		sprRen.sprite = deactivatedCheckpoint;
		isCheckpointActive = false;

		checkpointAnim = GetComponent<Animator>();
		checkpointAnim.enabled=false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			isCheckpointActive = true;
			checkpointAnim.enabled=true;
		}
	}
}

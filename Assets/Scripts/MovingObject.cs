using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	public GameObject movingObject;
	public Transform startPos;
	public Transform endPos;
	public float moveSpeed;
	public Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		currentTarget = endPos.position;
	}
	
	// Update is called once per frame
	void Update () {
		movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position,currentTarget,moveSpeed*Time.deltaTime);
		if(movingObject.transform.position==endPos.position){
			currentTarget=startPos.position;
		}else if(movingObject.transform.position==startPos.position){
			currentTarget=endPos.position;
		}
	}
}

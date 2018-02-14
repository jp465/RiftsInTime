using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float followAhead;
	private Vector3 targetPosition;
	public float cameraSmoothing;
	public float cameraYLock;


	// Update is called once per frame
	void Update () {
		if(target.transform.position.y<0){
			targetPosition = new Vector3(target.transform.position.x,cameraYLock,transform.position.z);
		}else if(target.transform.position.y>=0){
			targetPosition = new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z);
		}

		//follow ahead
		if(target.transform.localScale.x>0f){
			targetPosition = new Vector3(targetPosition.x+followAhead, targetPosition.y, targetPosition.z);
		}else{
			targetPosition = new Vector3(targetPosition.x-followAhead, targetPosition.y, targetPosition.z);
		}

		//smoothing
		transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing*Time.deltaTime);
	}
}

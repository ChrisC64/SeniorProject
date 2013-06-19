/************************************************
 * This will be our trigger for sending messages to our switches. 
 * Any object that has interaction, switches, doors, puzzles, etc.
 * will be given a message sent here. All "actions" are managed here.
 * Version 0.2.0a 
 * Date Modified: 
 * 06/16/2013
 * **********************************************/
using UnityEngine;
using System.Collections;

public class ActivateTrigger : MonoBehaviour {
  //public Vector3 rayDir = transform.TransformDirection(Vector3.forward);
	public RaycastHit hitInfo = new RaycastHit();
	public float f_rayLength = 4.0f;
	//public float fTargetTime = 2.0f;
	
	private float fCurrentTime = 0.0f;
	
	GameObject switchCollision; 
	
	//private float dTime = Time.deltaTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//update time
		fCurrentTime = Time.deltaTime + fCurrentTime;
		//Debug 
		
		Debug.DrawRay(transform.position, transform.forward * f_rayLength);
		if(Input.GetButtonDown ("Action"))	{
			if(Physics.Raycast(transform.position, transform.forward, out hitInfo, f_rayLength))
			{
				Debug.Log("Hit object!");
				
				if(hitInfo.collider.gameObject.tag == "Switch")	{
					// Send message to switchTrigger and initiate "switch"
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("TriggerSwitch");
				}
			}
		}
		//save current time and time passed since
		if(fCurrentTime > 2.0f)	{
			fCurrentTime = 0.0f;
			}
	}
}

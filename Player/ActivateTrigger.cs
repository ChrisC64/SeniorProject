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
	private bool b_ObjectCollision;
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
		
		Debug.DrawRay(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward) * f_rayLength);
		if(Physics.Raycast(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward), out hitInfo, f_rayLength)) {
			/*if(hitInfo.collider.gameObject.tag == "Switch")	{
				b_ObjectCollision = true;
				Debug.Log("Hit object!");
				if(Input.GetButtonDown ("Action"))	{
					// Send message to switchTrigger and initiate "switch"
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("TriggerSwitch");
				}
			}
			else if(hitInfo.collider.gameObject.tag == "Trap") {
				if(Input.GetButtonDown("Action")) {
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("Activate");
				}
			}*/
			
			switch(hitInfo.collider.gameObject.tag.ToString()) {
			case("Switch"):
				b_ObjectCollision = true;
				Debug.Log("This is a switch!");
				if(Input.GetButtonDown ("Action"))	{
					// Send message to switchTrigger and initiate "switch"
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("TriggerSwitch");
				}
				break;
			case("Trap"):
				b_ObjectCollision = true;
				Debug.Log("Trap! Watch out!");
				if(Input.GetButtonDown("Action")) {
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("Activate");
				}
				break;
			default:
				Debug.Log ("Nothing special here...");
				break;
			}
		} else {
			b_ObjectCollision = false;
		}
		//save current time and time passed since
		if(fCurrentTime > 2.0f)	{
			fCurrentTime = 0.0f;
			}
	}
	
	
	
	void OnGUI() {
		if(b_ObjectCollision) {
			GUI.BeginGroup(new Rect(Screen.width * 0.5f, Screen.height * 0.65f,  Screen.width * 0.70f, Screen.height * 0.80f));
			GUI.Box(new Rect(0, 0, 175, 30), "");
			GUI.Label(new Rect(5, 5, Screen.width * 0.90f, Screen.height * 0.90f), "Press E to Activate " 
				+ hitInfo.collider.gameObject.tag.ToString());	
			GUI.EndGroup();
		} else if(!b_ObjectCollision) {
			// Nothin
		}
	}
}

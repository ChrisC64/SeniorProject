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
	public Texture2D cursor;
	public Texture2D greenCursor;
	public LayerMask hitLayer;
	//public float fTargetTime = 2.0f;
	
	private float fCurrentTime = 0.0f;
	
	GameObject switchCollision; 
	
	//private float dTime = Time.deltaTime;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//update time
		fCurrentTime = Time.deltaTime + fCurrentTime;
		//Debug 
		
		Debug.DrawRay(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward) * f_rayLength);
		if(Physics.Raycast(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward), out hitInfo, f_rayLength, hitLayer)) 
		{
			switch(hitInfo.collider.gameObject.tag.ToString()) 
			{
			case("Switch"):
				b_ObjectCollision = true;
				Debug.Log("This is a switch!");
				if(Input.GetButtonDown ("Action"))	
				{
					// Send message to switchTrigger and initiate "switch"
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("TriggerSwitch");
				}
				break;
			case("Item"):
				b_ObjectCollision = true;
				Debug.Log("Item in sight!");
				if(Input.GetButtonDown("Action"))
				{
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("Activate");
				}
				break;
			case("Order"):
				b_ObjectCollision = true;
				Debug.Log ("Order switch!");
				if(Input.GetButtonDown ("Action")) 
				{
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("Activate");
				}
				break;
			case("Door"):
				b_ObjectCollision = true;
				Debug.Log ("Door in sight!");
				if(Input.GetButtonDown ("Action")) 
				{
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("OpenDoor");
				}
				break;
			case("MoveSwitch"):
				b_ObjectCollision = true;
				Debug.Log ("Door in sight!");
				if(Input.GetButtonDown ("Action"))
				{
					switchCollision = hitInfo.collider.gameObject;
					switchCollision.SendMessage("TriggerSwitch");
				}
				break;
			default:
				b_ObjectCollision = false;
				break;
			}
		} 
		else
		{
			b_ObjectCollision = false;
		}
		//save current time and time passed since
		if(fCurrentTime > 2.0f)	
		{
			fCurrentTime = 0.0f;
		}
	}
	
	
	
	void OnGUI() 
	{
		if(b_ObjectCollision) 
		{
			GUI.BeginGroup(new Rect(Screen.width * 0.5f, Screen.height * 0.65f,  Screen.width * 0.70f, Screen.height * 0.80f));
			GUI.Box(new Rect(0, 0, 175, 30), "");
			switch(hitInfo.collider.gameObject.tag.ToString()) 
			{
			case("Switch"):
			GUI.Label(new Rect(5, 5, Screen.width * 0.90f, Screen.height * 0.90f), "Press E to Activate " 
				+ hitInfo.collider.gameObject.tag.ToString());
				break;
			case("Item"):
				GUI.Label (new Rect(5, 5, Screen.width * 0.90f, Screen.height * 0.90f), "Press E to Collect "
					+ hitInfo.collider.gameObject.tag.ToString());
				break;
			case("Order"):
				GUI.Label (new Rect(5, 5, Screen.width * 0.90f, Screen.height * 0.90f), "Press E to Flip " + switchCollision.gameObject.name);
				break;
			case("Door"):
				GUI.Label (new Rect(5, 5, Screen.width * 0.90f, Screen.height * 0.90f), "Press E to Open Door");
				break;
			case("MoveSwitch"):
				GUI.Label (new Rect(5, 5, Screen.width * 0.90f, Screen.height * 0.90f), "Press E to flip the switch");
				break;
			}
			GUI.EndGroup();
		} 
		else if(!b_ObjectCollision) 
		{
			// Nothing
		}
		if(b_ObjectCollision)
		{
			GUI.DrawTexture(new Rect( Screen.width / 2, Screen.height / 2, 32, 32), greenCursor);
		}
		else
		{
			GUI.DrawTexture(new Rect( Screen.width / 2, Screen.height / 2, 32, 32), cursor);
		}
	}
}

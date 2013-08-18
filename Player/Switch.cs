using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Switch : MonoBehaviour {
	public bool bIsSwitchedOn;
	public float targetTime = 2.0f;
	public List<GameObject> connectedObjects = new List<GameObject>();
	public bool bIsInvisible;
	public bool bSwitchOnce; //If true, will only be able to switch once
	private bool bCanSwitch; //Condition check for insuring we only switch once
	//public GameObject switchObject;
	//private float fCurrentTime = Time.deltaTime;
	// Use this for initialization
	void Start ()
	{
		
		if(bIsSwitchedOn) 
		{	
			this.light.enabled = true;
		}
		else if(!bIsSwitchedOn) 
		{
			this.light.enabled = false;
		}
		if(bIsInvisible) 
		{
			//8 = invisible layer (doesn't appear on camera) and 9 = trigger
			this.gameObject.layer = 8;
			this.gameObject.collider.isTrigger = true;
			Debug.Log("Goodbye!");
		}
		bCanSwitch = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TriggerSwitch() 
	{
		if(bCanSwitch) 
		{
			//Toggle state of switch
			if(bIsSwitchedOn)
			{
				Debug.Log ("Switch OFF!");
				bIsSwitchedOn = false;
				this.light.enabled = false;
			}//Else if the switch is false AND the time passed is greater than targetTime, switch On
			else if(!bIsSwitchedOn)
			{
				Debug.Log ("Switch ON");
				bIsSwitchedOn = true;
				this.light.enabled = true;
			}
			//Loop through contents and send message to connected objects
			int count = 0;
		switch(this.tag)
			{
			case("Door"):
				foreach(GameObject objects in connectedObjects)
				{
					connectedObjects[count].SendMessage("OpenDoor");
					count++;
				}
			break;
			case("MoveSwitch"):
			foreach(GameObject objects in connectedObjects)
			{
				connectedObjects[count].SendMessage("OpenDoor");
				count++;
			}
			break;
			default:
				foreach(GameObject objects in connectedObjects)
				{
					connectedObjects[count].SendMessage("Activate");
					count++;
				}
				break;
			}
		}
		if(bSwitchOnce)
		{
			bCanSwitch = false;
		}
	} // End TriggerSwitch
	
	public bool GetIsSwitchedOn () { return bIsSwitchedOn; }
	
	public void SetIsSwtichedOn (bool setSwitch ) { bIsSwitchedOn = setSwitch; }
	
	public void Activate() 
	{
		if(bIsInvisible)
		{
			//disappear object and make a trigger to avoide collsion
			//8 = invisible layer (doesn't appear on camera) and 9 = trigger
			bIsInvisible = false;
			this.gameObject.layer = 9;
			this.gameObject.collider.isTrigger = false;
			this.light.enabled = false;
		}
		else if (!bIsInvisible)
		{
			//reappear object and set collision back on
			bIsInvisible = true;
			this.gameObject.layer = 8;
			this.gameObject.collider.isTrigger = true;
			this.light.enabled = false;
		}
	}
}

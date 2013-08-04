using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Switch : MonoBehaviour {
	public bool bIsSwitchedOn;
	public float targetTime = 2.0f;
	public List<GameObject> connectedObjects = new List<GameObject>();
	public bool bIsInvisible;
	//public GameObject switchObject;
	//private float fCurrentTime = Time.deltaTime;
	// Use this for initialization
	void Start () {
		if(bIsSwitchedOn) {
			this.renderer.material.color = Color.green;	
		}
		else if(!bIsSwitchedOn) {
			this.renderer.material.color = Color.red;
		}
		if(bIsInvisible) {
			//8 = invisible layer (doesn't appear on camera) and 9 = trigger
			this.gameObject.layer = 8;
			this.gameObject.collider.isTrigger = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TriggerSwitch() {
		//Toggle state of switch
		if(bIsSwitchedOn)
		{
			Debug.Log ("Switch OFF!");
			bIsSwitchedOn = false;
			this.renderer.material.color = Color.red;
		}//Else if the switch if false AND the time passed is greater than targetTime, switch On
		else if(!bIsSwitchedOn)
		{
			Debug.Log ("Switch ON");
			bIsSwitchedOn = true;
			this.renderer.material.color = Color.green;
		}
		//Loop through contents and send message to connected objects
		int count = 0;
		foreach(GameObject objects in connectedObjects)
		{
			connectedObjects[count].SendMessage("Activate");
			count++;
		}
	} // End TriggerSwitch
	
	public bool GetIsSwitchedOn () { return bIsSwitchedOn; }
	
	public void SetIsSwtichedOn (bool setSwitch ) { bIsSwitchedOn = setSwitch; }
	
	public void Activate() {
		if(bIsInvisible) {
			//disappear object and make a trigger to avoide collsion
			//8 = invisible layer (doesn't appear on camera) and 9 = trigger
			bIsInvisible = false;
			this.gameObject.layer = 9;
			this.gameObject.collider.isTrigger = false;
		}
		else if (!bIsInvisible) {
			//reappear object and set collision back on
			bIsInvisible = true;
			this.gameObject.layer = 8;
			this.gameObject.collider.isTrigger = true;
		}
	}
}

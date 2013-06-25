using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Switch : MonoBehaviour {
	private bool bIsSwitchedOn = true;
	public float targetTime = 2.0f;
	public List<GameObject> connectedObjects = new List<GameObject>();
	
	//private float fCurrentTime = Time.deltaTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TriggerSwitch() {
		//If switch is true AND time passed is greater than targetTime, switch off
		if(bIsSwitchedOn)
		{
			Debug.Log ("Switch OFF!");
			bIsSwitchedOn = false;
			//Loop through contents
			int count = 0;
			foreach(GameObject objects in connectedObjects)
			{
				connectedObjects[count].renderer.enabled = false;
				connectedObjects[count].collider.enabled = false;
				count++;
			}
		}//Else if the switch if false AND the time passed is greater than targetTime, switch On
		else if(!bIsSwitchedOn)
		{
			Debug.Log ("Switch ON");
			bIsSwitchedOn = true;
			//Loop through contents
			int count = 0;
			foreach(GameObject objects in connectedObjects)
			{
				connectedObjects[count].renderer.enabled = true;
				connectedObjects[count].collider.enabled = true;
				count++;
			}
		}
	} // End TriggerSwitch
	
	void Activate() { 
		Debug.Log("Watch Out Traps!");
		int count = 0; 
		foreach(GameObject objects in connectedObjects)
		{
			connectedObjects[count].SendMessage("Toggle");
			count++;
		}
	}
}

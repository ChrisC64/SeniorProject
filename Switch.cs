using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Switch : MonoBehaviour {
  private bool bIsSwitchedOn = false;
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
				connectedObjects[count].gameObject.renderer.material.color = Color.red;
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
				connectedObjects[count].gameObject.renderer.material.color = Color.green;
				count++;
			}
		}
	} // End TriggerSwitch
}

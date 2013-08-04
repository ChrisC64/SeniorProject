using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MultiKeyDoor : MonoBehaviour {
  // Variables
	public Switch switchKey;
	public Switch switchKey2;
	public Switch switchKey3;
	public GameObject door;
	private bool bIsUnlocked; 
	// Use this for initialization
	void Awake() {	
	}
	void Start () {
		//Set state of object
		bIsUnlocked = false;
		if(bIsUnlocked) {
			this.renderer.material.color = Color.green;
		}
		else if (!bIsUnlocked) {
			this.renderer.material.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// Name: Activate
	// Parameters: None
	// Activate (responds to switch trigger), and thus checks if conditions are met, 
	// so that the door may be open. Keys must all be activated either in/out of order, so
	// that the door will open. 
	void Activate() {
		//check if keys are all
		if(!bIsUnlocked)
		{
			if(switchKey.GetIsSwitchedOn() && switchKey2.GetIsSwitchedOn() && switchKey3.GetIsSwitchedOn()) {
				Debug.Log ("switchKey: " + switchKey.GetIsSwitchedOn() + " switchKey2: " + switchKey2.GetIsSwitchedOn() 
					+ " switchKey3: " + switchKey3.GetIsSwitchedOn() );
				Debug.Log ("Door unlocked!");
				gameObject.renderer.material.color = Color.green;
				bIsUnlocked = true;
			}
			else {
				Debug.Log ("switchKey: " + switchKey.GetIsSwitchedOn() + " switchKey2: " + switchKey2.GetIsSwitchedOn() 
					+ " switchKey3: " + switchKey3.GetIsSwitchedOn() );
				gameObject.renderer.material.color = Color.red;	
			}
		}
		//if all keys are true, we can unlock the door
		if(bIsUnlocked) {
			Debug.Log("Door is unlocked!");	
		}
	}
	
	public bool GetIsOpen() { return bIsUnlocked; }
}

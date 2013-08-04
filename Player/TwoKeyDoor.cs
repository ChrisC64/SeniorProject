using UnityEngine;
using System.Collections;

public class TwoKeyDoor : MonoBehaviour {
  // Variables
	public Switch switchKey;
	public Switch switchKey2;
	public GameObject door;
	private bool bIsUnlocked; 
	// Use this for initialization
	void Start () {
		//Set state of object
		bIsUnlocked = false;
		switchKey = GameObject.FindWithTag("Switch").GetComponent<Switch>();
		switchKey2 = GameObject.FindWithTag("Switch").GetComponent<Switch>();
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
			if(switchKey.GetIsSwitchedOn() && switchKey2.GetIsSwitchedOn() ) {
				gameObject.renderer.material.color = Color.green;
				bIsUnlocked = true;
			}
			else {
				gameObject.renderer.material.color = Color.red;	
			}
		}
		//if all keys are true, we can unlock the door
		if(bIsUnlocked) {
			Debug.Log("Door is unlocked!");	
		}
	}
}

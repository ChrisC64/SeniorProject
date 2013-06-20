using UnityEngine;
using System.Collections;

public class LightGem : MonoBehaviour {
  //variable declaration
	protected RaycastHit hitInfo; 
	public float f_RayLength;
	protected bool b_IsOn;
	private GameObject lightObject;
	// Use this for initialization
	void Start () {
		f_RayLength = 5.0f;
		b_IsOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			if(b_IsOn) {
				b_IsOn = false;
			} else if(!b_IsOn) {
				b_IsOn = true;
			}
			Debug.Log("Sun b_IsOn: " + b_IsOn);
		}
		//check if the light is on
		if(b_IsOn) {
			Debug.DrawRay (transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward) * f_RayLength);
			//Turn on light
			
			//If Object collides with other object that is lightObject, send message
			if(Physics.Raycast(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward), out hitInfo, f_RayLength)) {
				//f_Distance = hitInfo.distance;	
				if(hitInfo.collider.gameObject.tag == "LightObject") {
					//send a message to switch states
					lightObject = hitInfo.collider.gameObject;
					lightObject.SendMessage("ActivateLight");
					Debug.Log ("Light Gem object....");
				}// End IF block
			} // End Raycast
		}else if(!b_IsOn){
			//turn off light
		}// End IF block
	}// End Update
	
	public bool GetIsOn() {return b_IsOn;}
}

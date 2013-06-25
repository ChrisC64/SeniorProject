using UnityEngine;
using System.Collections;

public class LightGem : MonoBehaviour {
	//variable declaration
	protected RaycastHit hitInfo; 
	public float f_RayLength;
	protected bool b_IsOn;
	public GameObject lightObject;
	public GameObject sunGem;
	private PlayerStates player;
	// Use this for initialization
	void Start () {
		f_RayLength = 5.0f;
		b_IsOn = true;
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.getSunGem() == true) {
			sunGem.renderer.enabled = true;
			
			if(Input.GetKeyDown(KeyCode.Mouse0)) {
				/*if(b_IsOn) {
					b_IsOn = false;
				} else if(!b_IsOn) {
					b_IsOn = true;
				}*/
				b_IsOn = b_IsOn == true ? false : true;
				Debug.Log("SunGem b_IsOn is: " + b_IsOn);
			}//End of Input Block
			
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
				}// End of "b_IsOn block"
			}// End of player.getSunGem() == true block
			else if(!b_IsOn){
				//turn off light
			}// End NOT b_IsOn block
		else if(player.getSunGem() == false) {
			sunGem.renderer.enabled = false;
			}//end of Player.getSunGem() condition
	}// End Update
	
	public bool GetIsOn() {return b_IsOn;}
}

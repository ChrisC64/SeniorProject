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
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
		b_IsOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.getSunGem() == true) {
			sunGem.renderer.enabled = true;
			b_IsOn = true;
			//sunLight.light.enabled = true;
			Debug.DrawRay (transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward) * f_RayLength);
			//If Object collides with other object that is lightObject, send message
			if(Physics.Raycast(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward), out hitInfo, f_RayLength)) {
				if(hitInfo.collider.gameObject.tag == "LightObject") {
						//send a message to switch states
						lightObject = hitInfo.collider.gameObject;
						lightObject.SendMessage("ActivateLight");
				}// End IF block
			} // End Raycast
		}// End of player.getSunGem() == true block
		else if(player.getSunGem() == false) {
			sunGem.renderer.enabled = false;
		}//end of Player.getSunGem() condition
	}// End Update
	
	public bool GetIsOn() {return b_IsOn;}
}

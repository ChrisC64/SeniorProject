using UnityEngine;
using System.Collections;

public class DarkGem : MonoBehaviour {
	//variable declaration
	protected RaycastHit hitInfo; 
	public float f_RayLength;
	protected bool b_IsOn;
	private GameObject lightObject;
	public GameObject moonGem;
	private PlayerStates player;
	// Use this for initialization
	void Start () {
		f_RayLength = 5.0f;
		b_IsOn = false;
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.getMoonGem() == true)
		{
			moonGem.renderer.enabled = true;
			b_IsOn = true;
			//check if the light is on
			Debug.DrawRay (transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward) * f_RayLength);
			//If Object collides with other object that is lightObject, send message
			if(Physics.Raycast(transform.position, Camera.mainCamera.transform.TransformDirection(Vector3.forward), out hitInfo, f_RayLength)) {
				if(hitInfo.collider.gameObject.tag == "LightObject") {
					//send a message to switch states
					lightObject = hitInfo.collider.gameObject;
					lightObject.SendMessage("ActivateDark");
				}// End IF block
			} // End Raycast
		}//End player.getMoonGem
		else if(player.getMoonGem() == false) {
			moonGem.renderer.enabled = false;
		}
	}// End Update
	public bool GetIsOn() {return b_IsOn;}
}// End Class

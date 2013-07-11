using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
  //Variables
	private PlayerStates playerStates;
	//private PlayerPrefs save; 
	void Awake() {
		playerStates = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();

	}
	// Use this for initialization
	void Start () {
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//on Trigger Enter
	void OnTriggerEnter(Collider other) {
		//Player Enters Checkpoint
		if(other.tag == "Player")
		{
			Debug.Log ("Player Hits Checkpoint!");
			Save();
			
		}
		else {
				
		}
	}
	
	void Save() {
		PlayerPrefs.SetFloat ("x", transform.position.x);
		PlayerPrefs.SetFloat ("y", transform.position.y);
		PlayerPrefs.SetFloat ("z", transform.position.z);
		PlayerPrefs.SetFloat ("hp", playerStates.getCurrHP());
		Debug.Log ("Saving..." + transform.position.x + " " + transform.position.y + " " + transform.position.z);
	}
	
	void Load() {
		PlayerPrefs.GetFloat ("x");
		PlayerPrefs.GetFloat ("y");
		PlayerPrefs.GetFloat ("z");
		PlayerPrefs.GetFloat ("hp");
		print (transform.position.x);
	}
}

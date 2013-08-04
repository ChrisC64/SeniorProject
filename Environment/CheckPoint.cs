using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	//Variables
	private PlayerStates playerStates;
	private SaveSystem saveManager;
	//private PlayerPrefs save; 
	void Awake() {
		playerStates = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
		saveManager = GameObject.Find ("GameManager").GetComponent<SaveSystem>();
	}
	// Use this for initialization
	void Start () {
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
			Save ();
			
		}
		else {
				
		}
	}
	
	void Save() {
		saveManager.Save(playerStates.getCurrHP(), playerStates.getPlayerPosX (), playerStates.getPlayerPosY (), playerStates.getPlayerPosZ (), playerStates.getCanteenUses());
		Debug.Log("Saving... Player Pos: " + playerStates.getPlayerPosX() + " / " + playerStates.getPlayerPosY () + " / " + playerStates.getPlayerPosZ() + " HP: " + playerStates.getCurrHP());

	}
	
	void Load() {
		saveManager.Load ();
	}
}

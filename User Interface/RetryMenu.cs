/// <summary>
/// Retry menu.cs
/// This menu is for when the player dies,
/// and is asked to retry the level (currently loads up the entire level again)
/// or quit the game and return to the main menu. 
/// </summary>
using UnityEngine;
using System.Collections;

public class RetryMenu : MonoBehaviour {
  //Player States variable
	PlayerStates player;
	void Awake() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() { 
		if(player.getIsAlive() == false) {
			GUI.BeginGroup(new Rect(Screen.width * 0.50f - 50.0f, Screen.height * 0.50f - 50.0f, 150.0f, 100.0f));
				GUI.Box(new Rect(0.0f, 0.0f, 150.0f, 150.0f), "Would like to retry?");
				//GUI.Label(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.20f, Screen.height * 0.20f),"Would you like to retry?");
				if(GUI.Button(new Rect(20.0f, 20.0f, 50.0f, 40.0f), "Retry")){
					Debug.Log("Reloading level...");
				}
				if(GUI.Button(new Rect(80.0f, 20.0f, 50.0f, 40.0f), "Quit")) {
					Debug.Log("Quitting game...");
				}
			GUI.EndGroup();
		}
	}
}

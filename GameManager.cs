/// <summary>
/// Game manager.
/// This class is responsible for managing the game and knowing
/// what states our player is in. Its purpose is designed to
/// call on specific updates or scenes, and primarily guide us through these scenes
/// when we're playing. 
/// Version 0.2.0a
/// Date Modified:
/// 06/16/2013
/// </summary>
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  PlayerStates player;
	bool bIsRunning = true;
	bool bGameComplete = false;
	GameState stateID;
	// Use this for initialization
	void Awake() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();	
	}
	
	void Start () {
		bIsRunning = true;
		stateID = GameState.GAME;
	}
	
	// Update is called once per frame
	void Update () {
		if(bIsRunning == true) {
			// If the Player is alive then perform operations
			switch(stateID)	{
				case(GameState.INTRO):
					Debug.Log ("You're in the Intro");
					//Display splash screen scene
					//If player input detected, skip to next state; MENU
					break;
				case(GameState.MENU): //Display MENU GUI
					Debug.Log ("You're playing the GAME!");
					// Call GUI Menu from GUI class
					break;
				case(GameState.GAME): //Here we see if our game is playing. Load level scene based upon save file.
					Debug.Log ("Playing game now!");
					break;
				case(GameState.CREDITS): //If user selects this scene, or we end the game, display CREDITS
					Debug.Log("Credits displaying...");
					break;
				case(GameState.QUIT): // Shutdown game; clear memory
					Debug.Log("Quitting game....");
					bIsRunning = false;
					break;
				default: // Error catch; close game
					Debug.Log ("Invalid!");
					bIsRunning = false;
					break;
			} // End of Switch Statement
		} // End of IF (bIsRunning) condition
	}//End of Update()
	
	enum GameState {
		INTRO,
		MENU,
		GAME,
		CREDITS,
		QUIT
	};
} // End of Game Manager

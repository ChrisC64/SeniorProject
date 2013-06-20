/// <summary>
/// This manager is responsible for our Player's condition. 
/// If the player is dead, we'll give the player the option to
/// reload from past checkpoint or quit the game and return to the main menu.
/// The player's inputs are managed here, but the individual scripts for actions like
/// "Action" and Displaying the "Map" GUI are separate. 
/// Player's items are also handled via their own scripts, but the call to which weapon
/// should be displayed and shown is here. 
/// 
/// Version 0.2.0a
/// 
/// Date Modified: 
/// 06/16/2013
/// </summary>

using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour {
	
	/****************************
	 * BEGIN VARIABLE DECLARATION
	 * ***************************/
	enum PlayerEnum
	{
		GAME,
		MENU,
		MAP,
		DEAD
	};
	
	//Player variables
	protected float f_MaxHP;
	protected float f_currentHP;
	private bool b_IsAlive;
	private bool b_InMenu;
	private bool b_Flashlight;
	private bool b_Canteen;
	private bool b_SunGem;
	private bool b_MoonGem;
	
	//Uses left for Canteen item
	public int i_MaxUse; 
	public int i_CurrUse;
	public float f_HealAmount;
	private float posX, posY, posZ;
	
	// Class objects
	public hpBarScript hpHUD;
	PlayerEnum currentState;
	
	// CLASS CONSTRUCTOR
	public PlayerStates() {
		//Player variables
		f_MaxHP = 100.0f;
		f_currentHP = f_MaxHP;
		b_IsAlive = true;
		b_InMenu = false;
		
		//Uses left for Canteen item
		i_MaxUse = 4; 
		i_CurrUse = 4;
		f_HealAmount = 50.0f;
		
	}
	
	void Awake() {
		//Get State
		currentState = PlayerEnum.GAME;

	}
	
	// Use this for initialization
	void Start () {
		b_IsAlive = true;
		b_InMenu = false;
		
	}
	/***************************
	 * END VARAIBLE DECLARATION
	 * *************************/
	
	// Update is called once per frame
	void Update () {
			switch(currentState) {
				case(PlayerEnum.GAME): // GAME State
			#region GAME
					Debug.Log ("currentState: " + currentState.ToString());
					//mouse.SendMessage("LockMouse");
					//Player Input when playing game
					if(Input.GetButtonDown("Map")) {
						Debug.Log("Opening Map");
						currentState = PlayerEnum.MAP; // Open map
					}
					if(Input.GetKeyDown("h") && f_currentHP < f_MaxHP) {
						heal ();
						Debug.Log ("Player's Current HP: " + f_currentHP);
					}
					if(Input.GetKeyDown ("j") && f_currentHP >= 0) {
						takeDamage(10);
						Debug.Log ("Player's Current HP: " + f_currentHP);
						//If player's health is 0, switch states
						if(f_currentHP <= 0)
						{currentState = PlayerEnum.DEAD;}
					}
					if(Input.GetKeyDown ("1")) {
						//set equipped item to flashlight to true
						b_Flashlight = true;
						b_Canteen = false;
						b_SunGem = false;
						b_MoonGem = false;
						Debug.Log ("Equipped Flashlight");
					}
					if(Input.GetKeyDown ("2")) {
						//set equipped item to canteen
						b_Flashlight = false;
						b_Canteen = true;
						b_SunGem = false;
						b_MoonGem = false;
						Debug.Log ("Equipped Canteen");
					}
					if(Input.GetKeyDown("3")) {
						//set equipped item to sun gemstone
						b_Flashlight = false;
						b_Canteen = false;
						b_SunGem = true;
						b_MoonGem = false;
						Debug.Log ("Equipped Sun Gem");
					}
					if(Input.GetKeyDown("4")) {
						//set equipped item to moon gemstone
						b_Flashlight = false;
						b_Canteen = false;
						b_SunGem = false;
						b_MoonGem = true;
						Debug.Log ("Equipped Moon Gem");
					}
						//Display GUI HUD for Gameplay
						//Hide and Lock mouse (display cursor for game)
			#endregion GAME
						break;
				case(PlayerEnum.MENU): // MENU State
			#region MENU
					Debug.Log ("currentState: " + currentState.ToString ());
					//Unlock mouse
					//Display Menu
					//Player Input for Menu controls
			#endregion MENU
					break;
				case(PlayerEnum.MAP): // MAP State
			#region MAP
					Debug.Log ("currentState: " + currentState.ToString ());
					//Unlock Mouse
					//mouse.SendMessage("UnlockMouse");
					Debug.Log("Displaying Map");
					//Display Map Overlay
					if(Input.GetButtonDown("Map")) {
						Debug.Log ("Closing Map");
						currentState = PlayerEnum.GAME;
					}
					//If TAB is hit, return to Game and hide Map Overlay
			#endregion MAP
					break;
				case(PlayerEnum.DEAD):
			#region DEAD
					//Display screen to retry or quit game
					b_IsAlive = false;
					Debug.Log ("Current State: " + currentState.ToString());
			#endregion DEAD
					break;
				default:
			#region DEFAULT
					Debug.Log ("Error! Invalid State!");
					//Load Retry/EndGame Menu options
			#endregion DEFAULT
					break;
			} // End of Switch
	} // End of Update
	
	//return methods used for our GameState Manager to retrieve when needed
	public bool getIsAlive() {return b_IsAlive;}
	public bool getInMenu() {return b_InMenu;}
	public bool getFlashlight() {return b_Flashlight;}
	public bool getCanteen() {return b_Canteen;}
	public bool getSunGem() {return b_SunGem;}
	public bool getMoonGem() {return b_MoonGem;}
	public float getMaxHP() {return f_MaxHP;}
	public float getCurrHP() {return f_currentHP;}
	
	//set methods to set variables (if called from another class, like GameManager)
	public void setIsAlive(bool alive) {b_IsAlive = alive;}
	public void setInMenu (bool menu) {b_InMenu = menu;}
	public void setCurrHP (float currHP) {f_currentHP = currHP;}
	
	//Functions
	public void takeDamage(float damage) {f_currentHP = f_currentHP - damage;}
	public float heal() {return f_currentHP += f_currentHP + 50.0f > f_MaxHP ? 
		f_HealAmount = f_MaxHP - f_currentHP : (f_HealAmount < 50.0f ? f_HealAmount = 50.0f : f_HealAmount = 50.0f);}
}

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
	public float f_currentHP;
	private bool b_IsAlive;
	private bool b_InMenu;

	//Uses left for Canteen item
	public int i_MaxUse;
	public int i_CurrUse;
	public float f_HealAmount;

	//Weapon booleans
	public bool b_Flashlight;
	public bool b_Canteen;
	public bool b_SunGem;
	public bool b_MoonGem;

	//Vector3
	private Vector3 playerPos;
	

	// Class objects
	public hpBarScript hpHUD;
	PlayerEnum currentState;
	SaveSystem saveManager;
	GameObject playerObj;

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
		//set equipped item to flashlight to true
		b_Flashlight = true;
		b_Canteen = false;
		b_SunGem = false;
		b_MoonGem = false;

	}

	void Awake() {
		//Get State
		currentState = PlayerEnum.GAME;
		saveManager = GameObject.Find("GameManager").GetComponent<SaveSystem>();
		playerObj = GameObject.FindWithTag("Player");

	}

	// Use this for initialization
	void Start () {
		b_IsAlive = true;
		b_InMenu = false;
		playerPos = gameObject.transform.position;;

	}
	/***************************
	 * END VARAIBLE DECLARATION
	 * *************************/

	// Update is called once per frame
	void Update () {
		playerPos = gameObject.transform.position;
		switch(currentState) 
		{
			case(PlayerEnum.GAME):
				// GAME State
				#region GAME
					if(f_currentHP <= 0)
					{
						currentState = PlayerEnum.DEAD;
					}
					Debug.Log ("currentState: " + currentState.ToString());
					//mouse.SendMessage("LockMouse");
					playerInput();
						//Display GUI HUD for Gameplay
						//Hide and Lock mouse (display cursor for game)
				break;
				#endregion GAME
			case(PlayerEnum.MENU): 	// MENU State
				#region MENU
				Debug.Log ("currentState: " + currentState.ToString ());
				//Unlock mouse
				//Display Menu
				//Player Input for Menu controls
				break;
				#endregion MENU
			case(PlayerEnum.MAP): // MAP State
				#region MAP
				Debug.Log ("currentState: " + currentState.ToString ());
				//Unlock Mouse
				//mouse.SendMessage("UnlockMouse");
				Debug.Log("Displaying Map");
				//Display Map Overlay
				if(Input.GetButtonDown("Map"))
				{
					Debug.Log ("Closing Map");
					currentState = PlayerEnum.GAME;
				}
				//If TAB is hit, return to Game and hide Map Overlay
				break;
				#endregion MAP
			case(PlayerEnum.DEAD):
				#region DEAD
				//Display screen to retry or quit game
				b_IsAlive = false;
				saveManager.Load();
				b_IsAlive = true;
				currentState = PlayerEnum.GAME;
				Debug.Log ("Current State: " + currentState.ToString());
				break;
				#endregion DEAD
			default:
				#region DEFAULT
				Debug.Log ("Error! Invalid State!");
				//Load Retry/EndGame Menu options
			
				break;
				#endregion DEFAULT
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
	public Vector3 getPlayerPos() {return playerPos;}
	public float getPlayerPosX() {return playerPos.x;}
	public float getPlayerPosY() {return playerPos.y;}
	public float getPlayerPosZ() {return playerPos.z;}
	public int getCanteenUses() {return i_CurrUse;}

	//set methods to set variables (if called from another class, like GameManager)
	public void setIsAlive(bool alive) {b_IsAlive = alive;}
	public void setInMenu (bool menu) {b_InMenu = menu;}
	public void setCurrHP (float currHP) {f_currentHP = currHP;}
	public void setCanteenUses(int fill) {i_CurrUse = fill;}
	public void refillCanteen() {i_CurrUse = i_MaxUse;}
	public void setPlayerPos(Vector3 pos) {playerPos = pos;}
	public void setPlayerPos (float x, float y, float z) {playerPos = new Vector3(x, y, z);}
	public void setPlayerObjPos () {playerObj.transform.position = playerPos;}

	//Functions
	public void takeDamage(float damage) {f_currentHP = f_currentHP - damage;}
	public float heal() {return f_currentHP += f_currentHP + 50.0f > f_MaxHP ?
		f_HealAmount = f_MaxHP - f_currentHP : (f_HealAmount < 50.0f ? f_HealAmount = 50.0f : f_HealAmount = 50.0f);}

	private void playerInput() {
		//Player Input when playing game
		if(Input.GetButtonDown("Map")) {
			Debug.Log("Opening Map");
			currentState = PlayerEnum.MAP; // Open map
		}
		if(Input.GetKeyDown("h") && f_currentHP < f_MaxHP) {
			heal ();
		}
		if(Input.GetKeyDown ("j") && f_currentHP >= 0) {
			takeDamage(10);
			//If player's health is 0, switch states
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
		if(Input.GetKeyDown("l")) {
			playerPos = new Vector3(0, 0, 0);	
		}
	}
}

using UnityEngine;
using System.Collections;

public class SaveSystem : MonoBehaviour {

	private PlayerStates player;
	private int currentLevel;
	private bool bIsSaving;
	void Awake() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();	
	}
	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	//Save game
	public void Save(int level, float playerHP, float playerX, float playerY, float playerZ, int canteenUse, int sunGem, int moonGem) 
	{
		//Save data: Level, HP, PlayerPosition(X,Y,Z), Canteen Uses
		PlayerPrefs.SetInt	 ("level", level);
		PlayerPrefs.SetFloat ("hp", playerHP);
		PlayerPrefs.SetFloat ("x", playerX);
		PlayerPrefs.SetFloat ("y", playerY);
		PlayerPrefs.SetFloat ("z", playerZ);
		PlayerPrefs.SetInt	 ("canteen", canteenUse);
		PlayerPrefs.SetInt	 ("sun", sunGem);
		PlayerPrefs.SetInt	 ("moon", moonGem);
		PlayerPrefs.Save();
		//bIsSaving = false;
		Debug.Log ("SAVE HP: " + PlayerPrefs.GetFloat("hp") + " X/Y/Z: " + PlayerPrefs.GetFloat("x") + ", " + PlayerPrefs.GetFloat("y") + 
			", " + PlayerPrefs.GetFloat("z"));
		Debug.Log ("Level: " + PlayerPrefs.GetInt ("level") + " Canteen Uses: " + PlayerPrefs.GetInt ("canteen") + " SunGem Collected: " + PlayerPrefs.GetInt ("sun")
			+ " MoonGem Collected: " + PlayerPrefs.GetInt ("moon"));
	}
	//Use for loading checkpoint
	public void Load() 
	{
		Vector3 pos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
		//Load the player position
		player.setPlayerPos(pos);
		//Set the player's HP
		player.setCurrHP(PlayerPrefs.GetFloat("hp"));
		//Set the Canteen Uses available
		player.setCanteenUses(PlayerPrefs.GetInt("canteen"));
		player.setUnlockSun(PlayerPrefs.GetInt("sun"));
		player.setUnlockMoon (PlayerPrefs.GetInt ("moon"));
		player.setPlayerObjPos();
		Debug.Log("**LOAD** Player Pos: " + player.getPlayerPosX() + " / " + player.getPlayerPosY () + " / " + player.getPlayerPosZ() + " HP: " + player.getCurrHP());
		
	}
	//Use for loading level
	public void LoadGame()
	{
		//Load Level
		Application.LoadLevel(PlayerPrefs.GetInt("level"));
		//Load the player position
		player.setPlayerPos(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
		//Set the player's HP
		player.setCurrHP(PlayerPrefs.GetFloat("hp"));
		//Set the Canteen Uses available
		player.setCanteenUses(PlayerPrefs.GetInt("canteen"));
		player.setUnlockSun(PlayerPrefs.GetInt("sun"));
		player.setUnlockMoon (PlayerPrefs.GetInt ("moon"));
		player.setPlayerObjPos();
		Debug.Log("**LOAD** Player Pos: " + player.getPlayerPosX() + " / " + player.getPlayerPosY () + " / " + player.getPlayerPosZ() + " HP: " + player.getCurrHP());
		Debug.Log ("**LOAD** Level: " + PlayerPrefs.GetInt ("level") + " Canteen Uses: " + PlayerPrefs.GetInt ("canteen") + " SunGem Collected: " + PlayerPrefs.GetInt ("sun")
			+ " MoonGem Collected: " + PlayerPrefs.GetInt ("moon"));
	}
	
	void OnGUI() 
	{
		switch(bIsSaving) 
		{
		case(true):
			Debug.Log ("Saving...");
			GUI.BeginGroup(new Rect(Screen.width * 0.2f, Screen.height * 0.7f, 125, 20));
			GUI.Box (new Rect(0, 0, 100, 20), "");
			GUI.Label(new Rect(5, 5, 90, 18), "Saving...");
			GUI.EndGroup();
			break;
		case(false):
			break;
		}
	}
}

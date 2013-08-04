using UnityEngine;
using System.Collections;

public class SaveSystem : MonoBehaviour {

  private PlayerStates player;
	
	void Awake() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();	
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Save game
	public void Save(float playerHP, float playerX, float playerY, float playerZ, int canteenUse) {
		//Save data: Level, HP, PlayerPosition(X,Y,Z), Canteen Uses
		//PlayerPrefs.SetInt	 ("level", level);
		PlayerPrefs.SetFloat ("hp", playerHP);
		PlayerPrefs.SetFloat ("x", playerX);
		PlayerPrefs.SetFloat ("y", playerY);
		PlayerPrefs.SetFloat ("z", playerZ);
		PlayerPrefs.SetInt	 ("canteen", canteenUse);
		PlayerPrefs.Save();
		
		Debug.Log ("SAVE HP: " + PlayerPrefs.GetFloat("hp") + " X/Y/Z: " + PlayerPrefs.GetFloat("x") + ", " + PlayerPrefs.GetFloat("y") + 
			", " + PlayerPrefs.GetFloat("z"));
	}
	//Use for loading checkpoint
	public void Load() {
		Vector3 pos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
		//Load the player position
		player.setPlayerPos(pos);
		//Set the player's HP
		player.setCurrHP(PlayerPrefs.GetFloat("hp"));
		//Set the Canteen Uses available
		player.setCanteenUses(PlayerPrefs.GetInt("canteen"));
		player.setPlayerObjPos();
		Debug.Log("Loading... Player Pos: " + player.getPlayerPosX() + " / " + player.getPlayerPosY () + " / " + player.getPlayerPosZ() + " HP: " + player.getCurrHP());
	}
	//Use for loading level
	public void LoadGame() {
		//Load Level
		Application.LoadLevel(PlayerPrefs.GetInt("level"));
		//Load the player position
		player.setPlayerPos(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
		//Set the player's HP
		player.setCurrHP(PlayerPrefs.GetFloat("hp"));
		//Set the Canteen Uses available
		player.setCanteenUses(PlayerPrefs.GetInt("canteen"));
		player.setPlayerObjPos();
		Debug.Log("Loading... Player Pos: " + player.getPlayerPosX() + " / " + player.getPlayerPosY () + " / " + player.getPlayerPosZ() + " HP: " + player.getCurrHP());
	}
}

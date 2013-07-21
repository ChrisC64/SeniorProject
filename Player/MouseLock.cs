using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {
  public PlayerStates player;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true; 
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.getInMenu() == false && player.getIsAlive() == true) {
			LockMouse();	
		}
		else{
			UnlockMouse();	
		}
	
	}
	void LockMouse()
	{
		Screen.lockCursor = true;	
	}
	void UnlockMouse()
	{
		Screen.lockCursor = false;	
	}
}

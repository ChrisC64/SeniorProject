using UnityEngine;
using System.Collections;

public class ItemUnlockMoon : MonoBehaviour {

  public GameObject item;
	private PlayerStates playerState;
	void Awake() {
		playerState = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Activate() {
		//when player activates this object, we set the value to TRUE for the item and destroy the object
		playerState.setUnlockMoon(1);
		playerState.equipItem (3);
		item.SetActive(false);
	}
}

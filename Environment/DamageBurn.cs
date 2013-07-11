/// <summary>
/// Damage burn.cs
/// This will be our "fire damage" which will cause damage over time for the
/// player when they run into fire. 
/// It can also be used for other types like poison smog or other hazards
/// that deal damage over time. 
/// 
/// Version: 0.1a
/// Mod Date: 6/18/2013
/// Notes:
/// v0.1a: Created Script: NullReferenceObject with Class PlayerStates fixed; use GetComponent vs AddComponent
/// </summary>

using UnityEngine;
using System.Collections;

public class DamageBurn : MonoBehaviour {
	
	public float fixedDamage; //Damage over time
	public float dTime; //Timer
	public float waitTime;
	public bool b_IsActive;
	private PlayerStates playerStates; //Player Class
	
	void Awake() {
		playerStates = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	
	// Use this for initialization
	void Start () {
		//set up parameters
		//fixedDamage = 1.0f;
		//dTime = 0.0f;
		waitTime = 0.001f;
	} // End of Start()
	
	// Update is called once per frame
	void Update () {
		if(b_IsActive) { dTime = Time.deltaTime + dTime; } 
		else if(!b_IsActive)
		{ Debug.Log("No timer is needed!"); }

	} // End of Update
	
	//Damage Over Time
	void DamageOverTime(float time, float damage) {
		//if passed time is greater than current time
		if(playerStates.getIsAlive() == true && time > waitTime) {
			//set damage
			playerStates.takeDamage(damage);
			//reset timer
			dTime = 0.0f;
		}
		else {	} // Do nothing
	} // End of Damage Over Time
	
	void OnTriggerStay(Collider other) {
		if(b_IsActive)
		{
			if(other.gameObject.tag == "Player") {
				Debug.Log ("Object Player is staying in the pit!");
				DamageOverTime(dTime, fixedDamage);	
			}
			else {
			}
		} else if(!b_IsActive) {
			Debug.Log ("Trap is off!");	
		}
	} //End of OnTriggerStay 
	
	//Toggle Active state of object
	void Toggle() { 
		if(b_IsActive) { b_IsActive = false; } 
		else if (!b_IsActive) { b_IsActive = true;}
	}
	
} // End of DamageBurn

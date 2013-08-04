using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {
	
	//variables
	public Light Spot; 
	private PlayerStates Player; 
	private bool bIsEnabled;

	// Use this for initialization
	void Awake () {
		Player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	
	void Start() {
		if(Player.getSunGem()) {
			LightOn();
			SunLight();
		} else if(Player.getMoonGem() ) {
			LightOn ();
			DarkLight();
			
		} else if (Player.getFlashlight() ) {
			LightOn ();
			FlashLight();
			
		} else if (Player.getCanteen() ) {
			LightOff ();
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.getSunGem() ) {
			LightOn();
			SunLight();
		} else if(Player.getMoonGem() ) {
			LightOn ();
			DarkLight();
			
		} else if (Player.getFlashlight() ) {
			LightOn ();
			FlashLight();
			
		} else if (Player.getCanteen() ) {
			LightOff ();
		}	
	}
	//these functions will be called to set each specific light's properties
	//They are kept separate so that we can change each specific behavior if we need to; SpotAngle, intensity, color, etc. 
	void SunLight() {
		//Set properties
		Spot.spotAngle = 30;
		Spot.range = 10;
		Spot.intensity = 1;
		//Set color
		Spot.color = Color.yellow;
	
	}
	
	void DarkLight() {
		//Set properties
		Spot.spotAngle = 30;
		Spot.range = 10;
		Spot.intensity = 1;
		//Set color
		Spot.color = Color.magenta;

	}
	
	void FlashLight() {
		//Set properties
		Spot.spotAngle = 50;
		Spot.range = 10;
		Spot.intensity = 1.15f;
		//Set Color
		Spot.color = new Color(0.58f, 0.48f, 0.03f, 1.0f);
	
	}
	//Disable/Enable light
	void LightOff() {
		Spot.enabled = false;
		bIsEnabled = false;
	}
	
	void LightOn() {
		Spot.enabled = true;
		bIsEnabled = true;
	}
}

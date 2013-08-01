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
	//these functions will be called to set each specific light's properties
	//They are kept separate so that we can change each specific behavior if we need to; SpotAngle, intensity, color, etc. 
	void SunLight() {
		//Set properties
		Spot.spotAngle = 30;
		Spot.range = 10;
		Spot.intensity = 1;
		//Set color
		Spot.color = Color.yellow;
		//Spot.color.r = 239;
		//Spot.color.g = 244;
		//Spot.color.b = 65;
		//Spot.color.a = 255;
	}
	
	void DarkLight() {
		//Set properties
		Spot.spotAngle = 30;
		Spot.range = 10;
		Spot.intensity = 1;
		//Set color
		Spot.color = Color.magenta;
		//Spot.color.r = 167;
		//Spot.color.g = 47;
		//Spot.color.b = 132;
		//Spot.color.a = 255;
	}
	
	void FlashLight() {
		//Set properties
		Spot.spotAngle = 90;
		Spot.range = 10;
		Spot.intensity = 7.3f;
		//Set Color
		Spot.color = Color.white;
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

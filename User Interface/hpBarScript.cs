/****************************************
 * This is a temporary script!
 * We'll combine our scripts together for HUD
 * in our game, but for now this script manages the
 * HP bar in our game. It may be combined in future versions.
 * 
 * Version 0.2.0a
 * 
 * Date Modified: 
 * 06/16/2013
 * 
 * Last Author: Christopher Carlos
 * ***************************************/
using UnityEngine;
using System.Collections;

public class hpBarScript : MonoBehaviour {

	
	private PlayerStates playerStates;
	// current and max Hp set at a float value of 300
	public static float f_currentHp;
	public static float f_maxHp;
	
	// creates slots for hpBar background, foreground, and frame
	public Texture2D t_hpBarBG;
	public Texture2D t_hpBarFG;
	public Texture2D t_hpBarFrame;
	
	// defines the bar's length
	public float f_hpBarLength;
	// value for hp percentage
	public float f_hpPercentage;
	
	//Constructor
	public hpBarScript() {
		f_currentHp = 0;
		f_maxHp = 0;
		
		t_hpBarBG = null;
		t_hpBarFG = null;
		t_hpBarFrame = null; 
		
		f_hpBarLength = 0;
		f_hpPercentage = 0;
	}
	
	void OnGUI()
	{
		//We'll need to develop some standards for various aspect ratios for our game, so the GUI is visible in all scenes
		// draws the hp bar with the three texture images: background, foreground, frame
		GUI.BeginGroup(new Rect(Screen.width * 0.70f, Screen.height * 0.75f, 300, 300));
		
			if(f_currentHp > 0)
			{
				// GUI.DrawTexture(new Rect((Screen.width/2) - 100, 50, 100, 50), t_hpBarFrame);	
				GUI.DrawTexture(new Rect(10, 0, 100, 50), t_hpBarFrame);
				GUI.DrawTexture(new Rect(10, 0, 100, 50), t_hpBarBG);
				GUI.DrawTexture(new Rect(10, 0, f_hpBarLength, 50), t_hpBarFG);
				// displays current hp under hp bar
				GUI.Label(new Rect(20, 50, 100, 50), "Current hp: " + f_currentHp); 
			}	
			if(f_currentHp <= 0)
			{
					GUI.Label(new Rect(10, 20, 100, 50), "You have lost consciousness."); 
			}
		GUI.EndGroup();
	}
	
	void Awake() {
		playerStates = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	
	// Use this for initialization
	void Start () 
	{
		f_currentHp = playerStates.getCurrHP();
		f_maxHp = playerStates.getMaxHP();
	}
	
	// Update is called once per frame
	void Update () 
	{
		f_currentHp = playerStates.getCurrHP();
		// calculates the percentage of hp left
		f_hpPercentage = f_currentHp / f_maxHp;
		// sets the bar length dependant upon hp 
		f_hpBarLength = f_hpPercentage * 100;

	}// End Update
}

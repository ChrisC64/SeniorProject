/*
*/
/*  Manages Inventory HUD
*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class inventoryScript : MonoBehaviour 
{	
//	public flashlightScript renderer;
//	public canteenScript renderer;
//	public sunGemstoneScript renderer;
//	public moonGemstoneScript remderer;
	
	// PlayerItems tag for game objects
//	public GameObject[] PlayerItems = new GameObject[4];
	
	// creates game objects
//	public GameObject flashlight;
//	public GameObject canteen;
//	public GameObject sun_Gemstone;
//	public GameObject moon_Gemstone;
	
	// images for item icons
	public Texture2D t_flashlightIcon;
//	public Texture2D t_flashlightIconEquip;
	public Texture2D t_canteenIcon;
//	public Texture2D t_canteenIconEquip;
	public Texture2D t_sunGemstoneIcon;
//	public Texture2D t_sunGemstoneIconEquip;
	public Texture2D t_moonGemstoneIcon;
//	public Texture2D t_moonGemstoneIconEquip;

	// Use this for initialization
	void Start () 
	{
	
		// fill array with items?
//		PlayerItems[0] = flashlight;
//		PlayerItems[1] = canteen;
//		PlayerItems[2] = sun_Gemstone;
//		PlayerItems[3] = moon_Gemstone;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//GUI.TextArea(new Rect(10, 200, 500, 100), "Items");
		
		// displays text for items
//		inventoryText.guiText.text = "Flashlight " + "Canteen " + "Sun Gemstone " + "Moon Gemstone";
		
//		if(equippedItem = PlayerItems[0])
//		{
//			gameObject.GetComponent(renderer.enable) = true;
//			//renderer.enabled = true;
//		}
	
		// allows player to click 1, 2, 3, or 4 to select item
		// Debug.Log displays what item is equipped for now
//		if(Input.GetKeyDown("1"))
//		{
//			Debug.Log ("Equipped: " + PlayerItems[0].name);
//			GameObject equippedItem = PlayerItems[0];
//			flashlight.renderer.enabled = true;
			


//		}
//		if(Input.GetKeyDown("2"))
//		{			
//			Debug.Log ("Equipped: " + PlayerItems[1].name);

//			GameObject canteen.SetActive(true);

			
//		}
//		if(Input.GetKeyDown("3"))
//		{
//			Debug.Log ("Equipped: " + PlayerItems[2].name);


//		}
//		if(Input.GetKeyDown("4"))
//		{
//			Debug.Log ("Equipped: " + PlayerItems[3].name);


//		}
		
	}
	
	void OnGUI()
	{
		// group that draws the item icons on the lower left portion of the screen
		GUI.BeginGroup(new Rect(Screen.width/2 - 500, Screen.height/2 + 200, 250, 150));
		
		//	GUI.Box(new Rect(0,0,300,160), "Items");
			GUI.Box(new Rect(10, 0, 50, 50), t_flashlightIcon);
			GUI.Box(new Rect(70, 0, 50, 50), t_canteenIcon);
			GUI.Box(new Rect(130, 0, 50, 50), t_sunGemstoneIcon);
			GUI.Box(new Rect(190, 0, 50, 50), t_moonGemstoneIcon);
		// set icon to change depending on if the selected item is equipped
	
		GUI.EndGroup();	
	}	
}
	



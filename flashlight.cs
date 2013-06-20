/*Script for the flashlight PlayerItem
*Still needs fix for item to toggle visibility
I somehow messed that up again...
*/

using UnityEngine;
using System.Collections;

public class flashlightScript : MonoBehaviour 
{


  public GameObject flashlight;
	
	
	
	// Use this for initialization
	void Start () 
	{
//		renderer.enabled = false;
		
	
		//flashlight.SetActive(false);
	
		
		flashlight.renderer.enabled = false;
		
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown("1") && flashlight.renderer.enabled == false)
		{
//			renderer.enabled = true;
//			Debug.Log ("Equipped" + PlayerItems[0].name);
			
			flashlight.renderer.enabled = true;
			//flashlight.SetActive(true);
			
//			inventoryScript equippedItem = gameObject.GetComponent<inventoryScript>();
//			equippedItem.
			
//			equippedItem = flashlight;
			
		}
		else if(Input.GetKeyDown("1") && flashlight.renderer.enabled == true)
		{
			Debug.Log ("Flashlight Disappeared!");
			
			flashlight.renderer.enabled = false;
			//flashlight.SetActive(false);
			
		}
//		if(equippedItem!=flashlight)
//		{
//			renderer.enabled = false;
//		}
	
	}
}

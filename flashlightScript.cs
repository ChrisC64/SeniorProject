/* Script for the flashlight PlayerItem
 * Make sure to drag the game object from the hierachy 
 * and not the project panel or select from the 
 * drop-down tab
 * The same applies for the other items
 * Don't make the same mistake I did!
 */

using UnityEngine;
using System.Collections;

public class flashlightScript : MonoBehaviour 
{
	public GameObject flashlight;
	public PlayerStates player;
	


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
		flashlight.renderer.enabled = false;
	} // End Start
	
	// Update is called once per frame
	void Update () 
	{
		if(player.getFlashlight() == true)
		{
			Debug.Log ("I haz flashlight");	
			flashlight.renderer.enabled = true;
		}
		else if(player.getFlashlight() == false)
		{
			Debug.Log ("Flashlight Disappeared!");			
			flashlight.renderer.enabled = false;		
		}// End Update	
	}
	//make true and show item - Message from Item manager
}

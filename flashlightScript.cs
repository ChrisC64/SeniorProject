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

	// Use this for initialization
	void Start () 
	{
		flashlight.renderer.enabled = false;
	} // End Start
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("1") && flashlight.renderer.enabled == false)
		{
			Debug.Log ("I haz flashlight");	
			flashlight.renderer.enabled = true;
		}
		else if(Input.GetKeyDown("1") && flashlight.renderer.enabled == true)
		{
			Debug.Log ("Flashlight Disappeared!");			
			flashlight.renderer.enabled = false;		
		}// End Update	
	}
}


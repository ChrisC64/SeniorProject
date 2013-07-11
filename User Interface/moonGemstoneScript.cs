/*  Script for the moonstone PlayerItem?
*/


using UnityEngine;
using System.Collections;

public class moonGemstoneScript : MonoBehaviour 
{
  
//	public inventoryScript moon_Gemstone;
	
	public GameObject moonStone;
	
//	public GameObject[] PlayerItems;
	
	// Use this for initialization
	void Start () 
	{
//		moonStone.SetActive(false);
		
//		PlayerItems[3] = moonStone;
		
		moonStone.renderer.enabled = false;	
	}	
  
	// Update is called once per frame
	void Update () 
	{
//		if(Input.GetKeyDown ("4") && moonStone.activeSelf == false)
		if(Input.GetKeyDown ("4") && moonStone.renderer.enabled == false)
		{
//			moonStone.SetActive(true);
			
			moonStone.renderer.enabled = true;
			Debug.Log ("Power of the moon!!!");			
		}
//		else if(Input.GetKeyDown("4") && moonStone.activeSelf == true)
		else if(Input.GetKeyDown ("4") && moonStone.renderer.enabled == true)
		{
		
//			moonStone.SetActive(false);
			
			moonStone.renderer.enabled = false;
			Debug.Log("Moon power down");
		}
	}
}

/* Script for the sunstone PlayerItem
*/

using UnityEngine;
using System.Collections;

public class sunGemstoneScript : MonoBehaviour 
{
//	public inventoryScript sun_Gemstone;
	
	public GameObject sunStone;
	
//	public GameObject[] PlayerItems;
	
	// Use this for initialization
	void Start () 
	{
//		sunStone.SetActive(false);
		
//		PlayerItems[2] = sunStone;
		
		sunStone.renderer.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(Input.GetKeyDown ("3") && sunStone.activeSelf == false)
		if(Input.GetKeyDown ("3") && sunStone.renderer.enabled == false)
		{
//			sunStone.SetActive(true);
			
			sunStone.renderer.enabled = true;
			Debug.Log ("Power of the sun!!!");			
		}
//		else if(Input.GetKeyDown("3") && sunStone.activeSelf == true)
		else if(Input.GetKeyDown ("3") && sunStone.renderer.enabled == true)
		{		
//			sunStone.SetActive(false);			
			sunStone.renderer.enabled = false;
			Debug.Log("Sun power down");
		}

	}
}

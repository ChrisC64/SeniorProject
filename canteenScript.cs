/*Script for the canteen PlayerItem
*/

using UnityEngine;
using System.Collections;

public class canteenScript : MonoBehaviour 
{
	public GameObject canteen;
	
//	public GameObject[] PlayerItems;
	
	// Use this for initialization
	void Start () 
	{
		canteen.renderer.enabled = false;
	} // End Start
	
	// Update is called once per frame
	void Update () 
	{	
		if(Input.GetKeyDown("2") && canteen.renderer.enabled == false)
		{
			Debug.Log("Equipped canteen");					
			canteen.renderer.enabled = true;	
		}				
		else if(Input.GetKeyDown("2") && canteen.renderer.enabled == true)
		{
			Debug.Log("Canteen is gone?!");
			canteen.renderer.enabled = false;
		}	
	} // End Update
}


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
//	canteen.SetActive(false);
		
		canteen.renderer.enabled = false;
		
//		PlayerItems[1] = canteen;		
	}	
	// Update is called once per frame
	void Update () 
	{	
		if(Input.GetKeyDown("2") && canteen.renderer.enabled == false)
		{
//		canteen.SetActive(true);
			Debug.Log("Equipped canteen");
			
			canteen.renderer.enabled = true;			
		}
//		else
//		{
//			renderer.enabled = false;
//		}			
		else if(Input.GetKeyDown("2") && canteen.renderer.enabled == true)
		{
			Debug.Log("Canteen is gone?!");
			canteen.renderer.enabled = false;
		}			
	}
}

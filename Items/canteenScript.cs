/*Script for the canteen PlayerItem
*/

using UnityEngine;
using System.Collections;

public class canteenScript : MonoBehaviour 
{
	public GameObject canteen;
	public PlayerStates player;
	
//	public GameObject[] PlayerItems;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
		canteen.renderer.enabled = false;
	} // End Start
	
	// Update is called once per frame
	void Update () 
	{	
		if(player.getCanteen() == true)
		{
			Debug.Log("Equipped canteen");					
			canteen.renderer.enabled = true;	
		}				
		else if(player.getCanteen() == false)
		{
			Debug.Log("Canteen is gone?!");
			canteen.renderer.enabled = false;
		}	
	} // End Update
}

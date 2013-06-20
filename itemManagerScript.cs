/* Script for managing the PlayerItems
  calls and sends to inventoryScript.cs
  and separate item scripts to display
  item icons and control items
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * know which item is equipped via int
 * update
 *   	check for key presses (1-4)
 * 		set current item - int
 * 		disable previous item
 * */



public class itemManagerScript : MonoBehaviour 
{
	PlayerStates playerEnum;
	
	// set up current item and previous item variables
	public int i_currentItem;
	public int i_previousItem;
	
	// set up list for player's items
	public List<GameObject> PlayerItems = new List<GameObject>();
	
	// currItem: int
	// prevItem: int
	// itemList: list bool

	// Use this for initialization
	void Start () 
	{	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown("1") && i_currentItem != 1)
		{
			i_previousItem = i_currentItem;
			i_currentItem = 1;
			
			// if key 1 && currentItem != 1
			// set prevItem = currentItem
			// currentItem = 1
			
			// if key 2 && itemlist[1] == true && currentItem !=2
			// prevItem = currentItem
			// currentItem = 2
			// disable prevItem
			// enable currentItem
		
		}
		
		if(Input.GetKeyDown("2") && PlayerItems[1] == true && i_currentItem !=2)
		{
			i_previousItem = i_currentItem;
			i_currentItem = 2;
			
		}
		
		if(Input.GetKeyDown("3"))
		{			
		}
		
		if(Input.GetKeyDown("4"))
		{			
		}
	}
	
//	int SetCurrentItem()
//	{
//		return i_currentItem;
//	}
	
//	int SetCurrentItem(int)
//	{		
//	}
	
//	int DisableItem()
//	{		
//	}
	
//	int EnableItem()
//	{		
//	}

}

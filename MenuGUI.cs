using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour
{  
	
	void OnGUI()	
		{
			
			// begins the group for the menu
			GUI.BeginGroup(new Rect(Screen.width/2 - 100, Screen.height/2 - 150, 200, 280));
				
				// creates the menu box	
				GUI.Box(new Rect(0,0,200,280), "Menu");
	
				// creates the buttons. If pressed, will load scene accordingly
	
				// start game button		
				if(GUI.Button(new Rect(50,50,100,30), "Start Game"))		
				{		
					Application.LoadLevel("Game");		
				}
			
				// options button		
				if(GUI.Button(new Rect(50,100,100,30), "Options"))
				{		
					Application.LoadLevel("Options");		
				}		
			
				// credits button
				if(GUI.Button (new Rect(50,150,100,30), "Credits"))
				{
					Application.LoadLevel("Credits");
				}
			
				// quit game button
				if(GUI.Button (new Rect(50,200,100,30), "Quit Game"))
				{
					Application.LoadLevel("Quit Game");
					//Application.Quit();
					// switch to quit game later
					// Quit Game level for testing purpose
				}
			
			GUI.EndGroup ();
			
		}
		
}

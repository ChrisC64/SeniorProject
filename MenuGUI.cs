using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour
{  
	
	void OnGUI()	
		{
			GUI.BeginGroup(new Rect(Screen.width/2 - 50, Screen.height / 2 - 50, 150, 160));
				// creates the menu box	
				GUI.Box(new Rect(0,0,150,160), "Menu");
	
				// creates the buttons. If pressed, will load scene accordingly
	
				// start game button		
				if(GUI.Button(new Rect(30,40,80,20), "Start Game"))		
				{		
					Application.LoadLevel("Game");		
				}
			
				// options button		
				if(GUI.Button(new Rect(30,70,80,20), "Options"))
				{		
					Application.LoadLevel("Options");		
				}		
			
				// credits button
				if(GUI.Button (new Rect(30,100,80,20), "Credits"))
				{
					Application.LoadLevel("Credits");
				}
			
				// quit game button
				if(GUI.Button (new Rect(30,130,80,20), "Quit Game"))
				{
					Application.LoadLevel("Quit Game");
					//Application.Quit();
				}
			
			GUI.EndGroup ();
			
		}
		
}

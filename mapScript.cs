/* Script for setting up the map
    Ineffective way to set up the map covers
    for now
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapScript : MonoBehaviour 
{
	
	public Texture2D t_mapBackground;
	public Texture2D t_mapCover;
	
//	public List<Texture2D> t_mapCover = new List<Texture2D>();
//	public int mapCoverSize = 48;
	
//	public int rows;
//	public int cols;
//	public Texture2D[][]t_mapCover;
	
	// draw overall map screen/background
	// draw different boxes representing areas of the map
	// enable mouse click to clear map area

	struct derp
	{
	}
		
//	public bool IsButtonShowing = true;
	
	void OnGUI()
	{

// 		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
//		OpenMap();
		
		GUI.BeginGroup(new Rect(0, 0, 1200, 800));
		
			GUI.DrawTexture(new Rect(0, 0, 800, 600), t_mapBackground);			
		
//		if(IsButtonShowing)
//		{
		
				if(GUI.Button(new Rect(0, 0, 100, 100), t_mapCover))
					{			
						
					}		
		
				if(GUI.Button(new Rect(100, 0, 100, 100), t_mapCover))
					{

					}
				if(GUI.Button(new Rect(200, 0, 100, 100), t_mapCover))
					{
			
					}
				if(GUI.Button(new Rect(300, 0, 100, 100), t_mapCover))
					{
			
					}
				if(GUI.Button(new Rect(400, 0, 100, 100), t_mapCover))
					{
			
					}
				if(GUI.Button(new Rect(500, 0, 100, 100), t_mapCover))
					{
			
					}
				if(GUI.Button(new Rect(600, 0, 100, 100), t_mapCover))
					{
			
					}
				if(GUI.Button(new Rect(700, 0, 100, 100), t_mapCover))
					{
		
					}

//		}

		
//			GUI.Button(new Rect(0, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(100, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(200, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(300, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(400, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(500, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(600, 0, 100, 100), t_mapCover);
//			GUI.Button(new Rect(700, 0, 100, 100), t_mapCover);

//			GUI.DrawTexture(new Rect(0, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(100, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(200, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(300, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(400, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(500, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(600, 0, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(700, 0, 100, 100), t_mapCover);
			
//			GUI.DrawTexture(new Rect(0, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(100, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(200, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(300, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(400, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(500, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(600, 100, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(700, 100, 100, 100), t_mapCover);
	
//			GUI.DrawTexture(new Rect(0, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(100, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(200, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(300, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(400, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(500, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(600, 200, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(700, 200, 100, 100), t_mapCover);
			
//			GUI.DrawTexture(new Rect(0, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(100, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(200, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(300, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(400, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(500, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(600, 300, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(700, 300, 100, 100), t_mapCover);
			
//			GUI.DrawTexture(new Rect(0, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(100, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(200, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(300, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(400, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(500, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(600, 400, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(700, 400, 100, 100), t_mapCover);
	
//			GUI.DrawTexture(new Rect(0, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(100, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(200, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(300, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(400, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(500, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(600, 500, 100, 100), t_mapCover);
//			GUI.DrawTexture(new Rect(700, 500, 100, 100), t_mapCover);
		
		//GUI.Box(new Rect(left, top, width, height);
		
		GUI.EndGroup();		
		
	}

	
	void OpenMap()
	{
//		GUILayout.BeginVertical();
//		GUILayout.FlexibleSpace();
//		for(i = 0; i < rows; i++)
//		{
//GUILayout.BeginHorizontal();
//			GUILayout.FlexibleSpace();
//			for(j = 0; j < cols; j++)
//			{
	
//			}
		}
	
	// Use this for initialization
	void Start () 
	{
	
//		for(int i = 0; i < mapCoverSize; i++)
//		{
//			mapCover.Add(mapCover);
//		}
		
//		rows = 6;
//		cols = 8;
//		mapCover = new Texture2D[i][j];
		
//		for(i = 0; i < rows; i++)
//		{
//			for(j = 0; j < cols; j++)
//			{
	//			mapCover[i][j] = mapCover;
//			}
//		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
//		if(Input.GetKeyDown("m"))
//		{
//			CreateMap();
//		}
		
		if(Input.GetMouseButtonDown(0))
		{
			Destroy(this);	
		}

	}	
	
//	void CreateMap()
//	{
//		GUI.BeginGroup(new Rect(10, 10, 1200, 800));
//		GUI.color = Color.white;
//			GUI.Box(new Rect(0, 0, 1123, 750), mapBackground);
		

//		GUI.EndGroup();
		
//	}
}

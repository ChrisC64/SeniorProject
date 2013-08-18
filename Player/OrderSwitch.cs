using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OrderSwitch : MonoBehaviour {
	private bool bIsOn;
	private bool bNoMoreFlips;
	public List<GameObject> orderSwitch;
	// Use this for initialization
	void Start () 
	{
		bIsOn = false;
		bNoMoreFlips = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!bNoMoreFlips)
		{
			if(bIsOn)
			{
				this.renderer.material.color = Color.white;	
				this.light.enabled = true;
			}
			else if(!bIsOn)
			{
				this.renderer.material.color = Color.white;
				this.light.enabled = false;
			}
		}
	}
	
	//when activated switch state and send message to object
	void Activate() 
	{
		if(!bNoMoreFlips)
		{
			bIsOn = true;
			for(int i = 0; i < orderSwitch.Count; i++)
			{
				orderSwitch[i].SendMessage("Check", this.gameObject);
			}
		}
	}
	
	void Reset() 
	{
		bIsOn = false;
		this.light.enabled = false;
	}
	
	void StopFlips()
	{
		bNoMoreFlips = true;	
	}
	
}

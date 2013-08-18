using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OrderSwitchObject : MonoBehaviour {
	//public List<int> orderList;
	public List<GameObject> objectList;
	public GameObject targetObject;
	private int count;
	//private variables
	private bool bIsSolved;
	// Use this for initialization
	void Start () 
	{
		count = 0;
		bIsSolved = false;
		foreach(GameObject obj in objectList)
		{
			objectList[count].renderer.material.color = Color.white;	
			count++;
		}
		count = 0;
		//this.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Check (GameObject obj) {
		//check gameObject's number
		if(obj == objectList[count] && !bIsSolved)
		{	
			Debug.Log ("Match! Obj: " + obj.ToString() + " Count: " + count + " ObjList: " + objectList[count].ToString());
			Debug.Log ("Count List: " + objectList.Count);
			if(count == objectList.Count - 1)
			{
				Open ();
				bIsSolved = true;
				this.gameObject.renderer.material.color = Color.green;
			}
			count++;
		}
		else
		{
			count = 0;
			foreach(GameObject item in objectList)
			{
				objectList[count].SendMessage("Reset");
				count++;
			}
			count = 0;
			this.renderer.material.color = Color.red;
			Debug.Log ("Reset! Count: " + count);
		}
	}
	
	void Open() {
		Debug.Log ("Door opened!");
		this.gameObject.SendMessage("Activate");
		int counter = 0;
		foreach(GameObject item in objectList)
		{
			objectList[counter].SendMessage("StopFlips");
			counter++;
		}
	}
}

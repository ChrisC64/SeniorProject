using UnityEngine;
using System.Collections;

public class LightObject : MonoBehaviour {
  public GameObject lightTrigger;
	private bool b_IsActive;
	private LightGem lightGem;
	private DarkGem darkGem;
	// Use this for initialization
	void Start () {
	 	lightGem = GameObject.FindWithTag ("Sun_Gemstone").GetComponent<LightGem>();
		darkGem = GameObject.FindWithTag ("Moon_Gemstone").GetComponent<DarkGem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ActivateDark() {
		
			//Set render and collider
			Debug.Log ("Displaying Object...");
			lightTrigger.renderer.enabled = true;
			lightTrigger.collider.isTrigger = false;
	}
	
	void ActivateLight() {
			//Set render and collision to false
			Debug.Log ("Removing the object...");
			lightTrigger.renderer.enabled = false;
			lightTrigger.collider.isTrigger = true; 	
	}
}

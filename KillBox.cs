using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {
  public float f_Damage;
	private PlayerStates playerStates;
	
	void Awake() {
		playerStates = GameObject.FindWithTag("Player").GetComponent<PlayerStates>();
	}
	// Use this for initialization
	void Start () {
		f_Damage = playerStates.getMaxHP();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player")
		{
			Debug.Log("Player is dead! No");
			playerStates.takeDamage(f_Damage);	
		}
		else{
			//Do nothing	
		}
	}
}

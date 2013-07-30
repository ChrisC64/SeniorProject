using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
  public GameObject moveObject;
	//bools
	public bool slideLeft;
	public bool slideRight;
	public bool moveForward;
	public bool moveBack;
	public bool moveUp;
	public bool moveDown;
	
	//ints
	private int direction;
	private float vel;
	private bool bIsMoving; 
	
	//floats
	private float distance;
	public float maxDistance;
	public float speed;
	public float maxSpeed;
	
	private float startTime;
	//vectors
	private Vector3 startPos;
	private Vector3 endPos;
	// Use this for initialization
	void Start () {
		//Set velocity to positive or negative based upon direction
		//directon = # is used for the switch/case in the update function
		//endPos variable is given the end coordinates for the
		if(moveForward){
			direction = 0;
			vel = 1.0f;
		} else if (moveBack) {
			direction = 1;
			vel = -1.0f;
		} else if (slideLeft) {
			direction = 2;
			vel = -1.0f;
		} else if (slideRight) {
			direction = 3;
			vel = 1.0f;
		} else if (moveUp) {
			direction = 4;
			vel = 1.0f;
		} else if (moveDown) {
			direction = 5;
			vel = -1.0f;
		} else {
			moveForward = true;
			moveBack = false;
			moveUp = false;
			moveDown = false;
			slideLeft = false;
			slideRight = false;
			bIsMoving = false;
			direction = 0;
			vel = 1.0f;
		}
		
		startPos = moveObject.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//bool begins movement condition
		if(bIsMoving)
		{
			#region Switch
			switch(direction){
			//move forward
			case(0): 
				//translate position over time
				transform.Translate(0, 0, (vel * speed) * Time.deltaTime, Space.Self);
				Debug.Log ("Moving forward: " + moveObject.transform.position.ToString());
				break;
			case(1): //move back
				//translate position over time
				transform.Translate(0, 0, (vel * speed) * Time.deltaTime, Space.Self);
				Debug.Log ("Moving backward: " + moveObject.transform.position.ToString());
				break;
			case(2): //slide left
				//translate position over time
				transform.Translate((vel * speed) * Time.deltaTime, 0, 0, Space.Self);
				Debug.Log ("Moving left: " + moveObject.transform.position.ToString());
				break;
			case(3): //slide right
				//translate position over time
				transform.Translate((vel * speed) * Time.deltaTime, 0, 0, Space.Self);
				Debug.Log ("Moving right: " + moveObject.transform.position.ToString());
				break;
			case(4): //move up
				//translate position over time
				transform.Translate(0, (vel * speed) * Time.deltaTime, 0, Space.Self);
				Debug.Log ("Moving up: " + moveObject.transform.position.ToString());
				break;
			case(5): //move down
				//translate position over time
				transform.Translate(0, (vel * speed) * Time.deltaTime, 0, Space.Self);
				Debug.Log ("Moving down: " + moveObject.transform.position.ToString());
				break;
			default:
				Debug.Log ("Moving nowhere....");
				break;
			}
			#endregion SWITCH
			//bIsMoving = false;
			Debug.Log ("Start Time: " + startTime);
			distance += speed * Time.deltaTime;
			if(distance >= maxDistance)
			{
				bIsMoving = false; 	
			}
		}
	}
	
	void Activate() {
		//here we move the object, so if we use any switches
		//to move the object, it will be activated via switch
		bIsMoving = true;
		//startTime = 0;
	}
}

#pragma strict

/////////////////////////
//Variables
/////////////////////////
	
//the sluggish effect between game object and companion body
//the smaller the quicker the body will follow the object
var fMoveDamp : float = 0.1;

//Determines the speed in which the companion will rotate to the direction it's moving. 
//Higher means quicker rotation
var fRotationSpeed : float = 5;
	
//The game object the body will follow
var tParentToFollow : Transform;

//Velocity of body
//No Y because we want the body to stick to the ground. 
var fVelocityX : float;
var fVelocityZ : float;
	
/////////////////////////
//Awake function: Used to initialize stuff, 
//called only once every scene
/////////////////////////
function Awake()
{
	tParentToFollow = transform.parent;
	transform.parent = null;
}

function Update () {
	 
	//These make the model mesh follow the parent with a slight delay for realism.
	transform.position.x = Mathf.SmoothDamp(transform.position.x, tParentToFollow.position.x, fVelocityX, fMoveDamp); 
	transform.position.z = Mathf.SmoothDamp(transform.position.z, tParentToFollow.position.z, fVelocityZ, fMoveDamp);
	//transform.position.y = tParentToFollow.GetComponent(CompanionAIScript).transform.position.y; 
	 
	//This rotates the mesh to follow the parent's rotation with a slight lag for realism.
	transform.rotation = Quaternion.Lerp(transform.rotation, tParentToFollow.rotation, fRotationSpeed*Time.deltaTime);
	
	//This keeps the body from tilting when going up on angles. 
	transform.rotation.x = 0.0f;
	
		
	////////////////////////////////////////////////
	//This for loop will keep the body to the floor 
	//of the current cell
	////////////////////////////////////////////////
	//RayCastHit array to hold data of objects hit by raycast
	var hits : RaycastHit[];
	
	//Set the ray above the companion body and shoot the ray down. 
	//100 is an estimate of the body's height, need to be somewhere in the head
	hits = Physics.RaycastAll(Ray(transform.position + Vector3(0, 10, 0), Vector3.up * -1));
	
	for(var i:int=0; i<hits.Length; i++)
	{
		var hit : RaycastHit = hits[i];
		if(hit.transform.gameObject == tParentToFollow.gameObject.GetComponent(CompanionAIScript).currentCell)
		{
			transform.position.y = hit.point.y;	
		}
	}
}

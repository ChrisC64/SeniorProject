

//Variables 
var playerTransform : Transform;
var speed : float = 5.0f;
var delayTime : float = 0.5f;
var rotationSpeed : float = 0.0f; 
var distance : float;
var damage : int = 10;

function Start () 
{
	playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform; 
	transform.LookAt(transform.position+Vector3(0,1,0));
}

function Update () 
{ 
	distance = Vector3.Distance(gameObject.transform.position, playerTransform.position);
	if(delayTime > 0)
		delayTime -=  Time.deltaTime; 
		
	if(delayTime <= 0) 
	{  
		if(rotationSpeed < 2)
			rotationSpeed += 0.01f;
	}
		
	transform.LookAt(Vector3.Slerp(gameObject.transform.position, playerTransform.position, rotationSpeed)); 
	transform.Translate(Vector3.forward*speed*Time.deltaTime);  
	
	
	if(distance < 1)
	{
		GameObject.FindGameObjectWithTag("Player").SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject); 
	}
}

function ActivateDark()
{
	Destroy(gameObject);
}

//function OnTriggerEnter(other : Collider)
//{
//	if(other.tag == "Player")
//	{
//		Destroy(gameObject);
//	}
//}
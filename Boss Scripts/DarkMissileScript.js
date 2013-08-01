

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
		GameObject.FindGameObjectWithTag("Boss").SendMessage("SubtractSpirit", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject); 
	}
}

function RandomRise()
{
	transform.LookAt(transform.position+Vector3(Random.Range(-2,2),1,Random.Range(-2,2)));
}

function ActivateLight()
{	
	
}

function ActivateDark()
{
	GameObject.FindGameObjectWithTag("Boss").SendMessage("SubtractSpirit", SendMessageOptions.DontRequireReceiver);
	Destroy(gameObject);
}

//function OnTriggerEnter(other : Collider)
//{
//	if(other.tag == "Player")
//	{
//		Destroy(gameObject);
//	}
//}
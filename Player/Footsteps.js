 
 
 ////////////////////////////////////////////
 //Footstep sound effect script
 ////////////////////////////////////////////
 
//////////////
//VARIABLES 
//////////////
//Make another audioclip array for different materials(i.e rock, wood, etc.)
var defaultClip : AudioClip[];
var dirt : AudioClip[];

private var movementState : int;
private var step : boolean = true;
var audioWalkTimer : float = 0.45; 	//Delay for walking
var audioRunTimer : float = 0.25;	//Delay for running


//Movement sounds/steps
function OnControllerColliderHit (hit : ControllerColliderHit)
{
	Debug.Log("Check");
	var controller : CharacterController = /*GameObject.FindGameObjectWithTag("Player").*/GetComponent(CharacterController);
	
	//determine if player is walking or running
	Debug.Log("Magnituge: "+controller.velocity.magnitude);
	if(controller.velocity.magnitude==0) 
	{
		movementState = 0; 		 //is idle
	}
	else if(controller.velocity.magnitude>5 && controller.velocity.magnitude<7)
	{
		movementState = 1;		//is walking
	}
	else if(controller.velocity.magnitude>7)
	{
		movementState = 2;		//is running
	}
		
	
	//If the player is on the ground AND player's speed is between 7 and 5(walking) AND step is true....
	if(controller.isGrounded && step)
	{
		switch(hit.gameObject.tag)
		{
		case "Dirt":
			Dirt(movementState);
			break;			
		default:
			Default(movementState);
			break;
		}
	}
}

//The default sound just in case ground is untagged
function Default(state: int)
{ 
	if(state!=0) 
	{
		step = false;
		//adds some randomization if more than one clip is inserted to the array
		audio.clip = defaultClip[Random.Range(0, defaultClip.length)];
		audio.volume = 0.1;
		audio.Play();
		switch(state)
		{
		case 1:
			yield WaitForSeconds(audioWalkTimer);
			break;
		case 2:
			yield WaitForSeconds(audioRunTimer);
			break;
		}
	}		
	step = true;
}

//If player walks on dirt
function Dirt(state: int)
{
	if(state!=0) 
	{
		step = false;
		//adds some randomization if more than one clip is inserted to the array
		audio.clip = dirt[Random.Range(0, dirt.length)];
		audio.volume = 0.1;
		audio.Play();
		switch(state)
		{
		case 1:
			yield WaitForSeconds(audioWalkTimer);
			break;
		case 2:
			yield WaitForSeconds(audioRunTimer);
			break;
		}
	}		
	step = true;
}
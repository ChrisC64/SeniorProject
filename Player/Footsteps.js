 
 
 ////////////////////////////////////////////
 //Footstep sound effect script
 ////////////////////////////////////////////
 
//////////////
//VARIABLES 
//////////////
//Make another audioclip array for different materials(i.e rock, wood, etc.)
var defaultClip : AudioClip[];
//var dirt : AudioClip[];
var controller : CharacterController; 

private var movementState : int;
private var step : boolean = true;
var audioWalkTimer : float = 0.45; 	//Delay for walking
var audioRunTimer : float = 0.25;	//Delay for running 

function Start()
{
	 controller = GetComponent(CharacterController);
}


//Movement sounds/steps
function Update()
{	
	if(controller.isGrounded) 
	//if(controller.velocity.y<1&&controller.velocity.y>-0.5)
	{ 
		if(controller.velocity.magnitude>1)
		{
			//If the player is on the ground AND player's speed is between 7 and 5(walking) AND step is true....
			if(step)
			{
				Default();
			}
		}		
	}
}

//The default sound just in case ground is untagged
function Default()
{ 	
	step = false;
	//adds some randomization if more than one clip is inserted to the array
	audio.clip = defaultClip[Random.Range(0, defaultClip.length)];
	audio.volume = 0.25;
	audio.Play(); 
	yield WaitForSeconds(audioWalkTimer);	
	step = true;
}

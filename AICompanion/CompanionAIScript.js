

//Variables for companion movement
var currentCell : GameObject;
var playerMovementScript : PlayerMovementScript;
var playerTransform : Transform;
var playerCell : GameObject;
var goalDoor : GameObject;
var shortestPathSoFar : float;
var v3LastPos : Vector3;
var v3TargetLook : Vector3;
var qLastRotation : Quaternion;
var fGapBetweenPlayer : float;

var currentMoveSpeed:float = 4.0;

//Variables for random movement when player is idle. 
var fIdleTimer : float = 10.0;
var fPause : float = 2.0;
var v3RandomizedCourse : Vector3;
var bCalcNewRandCourseVector : boolean = true;

//Variables for Torches
var arrTorches = new Array();
var bTorchDetected : boolean = false;
var gaNearestTorch : GameObject;
var fGapBetweenTorch : float = 1.0f;

@HideInInspector	
var waitToStart : int = 5;

function Awake()
{
	shortestPathSoFar = Mathf.Infinity;
	playerMovementScript = GameObject.FindWithTag("PlayerPosition").GetComponent(PlayerMovementScript);
	playerTransform = GameObject.FindWithTag("PlayerPosition").transform;
	waitToStart = 5;
	v3RandomizedCourse = transform.position;
	fIdleTimer = 10.0f;
	v3LastPos = transform.position;
	fGapBetweenPlayer = 3.0f;
}

function Update()
{

	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Goes through the cells and doors to determine shortest path to player
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(waitToStart<=0)
	{
		CalcPathToPlayer();
	}
	
	waitToStart--;	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Actualy movement script for the AI
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	
	//If there is a door or path is blocked
	if(goalDoor)
	{
		if(!goalDoor.GetComponent(AIpathDoorScript).doorOpen)
			goalDoor = null;
	}	

	/////////////////////////////////////////////////////////////////////
	//if companion is not in the same cell as player, go to the goalDoor
	/////////////////////////////////////////////////////////////////////
	if(goalDoor && currentCell!=playerCell)
	{
		if(!currentCell.GetComponent(AIpathCellScript).wait)
		{
			GoForDoor();
		}
	}
	
	/////////////////////////////////////////////////////////////////////
	//if companion is in the same cell as player
	/////////////////////////////////////////////////////////////////////
	if(playerCell == currentCell)
	{
		///////////////////////////////////////////////////////////////
		//First check to see if there are any torches in the cell/room
		///////////////////////////////////////////////////////////////
		
		if(bTorchDetected)
		{
						
			//Go through all the array
			for(var torch:GameObject in arrTorches)
			{
				//Don't include torches already lit
				if(!torch.GetComponent(TorchInterScript).bIsOn)
				{
					//if gaNearestTorch is already lit, assign it to the next unlit torch
					if(gaNearestTorch.GetComponent(TorchInterScript).bIsOn)
					{
						gaNearestTorch = torch;
					}
					//if gaNearestTorch is off, start comparing it with the others to determine which is the closest. 
					//assign that to gaNearestTorch
					else if(Vector3.Distance(torch.transform.position, transform.position) < Vector3.Distance(gaNearestTorch.transform.position, transform.position))
					{					
						gaNearestTorch = torch;							
					}
				}
			}
			
			Debug.Log("Go For Nearest Torch");
			//If distance between companion and torch is greater than fGapBetweenTorch....
			if(Vector3.Distance(gaNearestTorch.transform.position, transform.position) > fGapBetweenTorch)
			{
				//move to torch until so
				transform.position += (gaNearestTorch.transform.position - transform.position).normalized * currentMoveSpeed * Time.deltaTime;
				FaceDirection(true);
			}
			else
			{
				FaceDirection(false);
			}		
			
			bTorchDetected = false;
			for(var torch:GameObject in arrTorches)
			{
				if(!torch.GetComponent(TorchInterScript).bIsOn)
					bTorchDetected = true;
			}
			
		}		
		else
		{		
			if(fIdleTimer>-1)
				fIdleTimer -= Time.deltaTime;
			
			/////////////////////////////////////////////////////////////////////
			//If idle timer have yet to reach zero
			/////////////////////////////////////////////////////////////////////
			if(fIdleTimer>0)
			{
				if(!currentCell.GetComponent(AIpathCellScript).wait)
					GoForPlayer();
			}
		
			/////////////////////////////////////////////////////////////////////
			//If timer is up, companion will start to wander in current cell
			/////////////////////////////////////////////////////////////////////
			else
				WonderInCurCell();	
		}		
	}	
	
	//update last position
	v3LastPos = transform.position;
	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}


function OnTriggerEnter (other :Collider)
{
	if(other.tag == "AIpathCell")
	{
		currentCell = other.gameObject;
		//Debug.Log("Update arrTorches with torches from new cell");
		arrTorches = other.GetComponent(AIpathCellScript).torches;
		bTorchDetected = false;
		if(currentCell.GetComponent(AIpathCellScript).bTorches)
		{
			for(var torch:GameObject in arrTorches)
			{
				if(!torch.GetComponent(TorchInterScript).bIsOn)
				{
					bTorchDetected = true;
					//Initialize nearest torch with first torch in the array
					gaNearestTorch = torch;
				}
			}
		}
			
	}
}
 
//////////////////////////////////////////////////////////////////////////
//Name: GoForPlayer
//Use: 	Called when companion is in the same cell as player. 
//		Will simply move towards player's position until a certain distance.
//		Will also begin the countdown for idle timer. 
//Para: None
///////////////////////////////////////////////////////////////////////////
function WonderInCurCell()
{
	Debug.Log("Wondering");
	/////////////////////////////////////////////////////////////////////
	//Calculate new random position in current cell
	/////////////////////////////////////////////////////////////////////
	if(bCalcNewRandCourseVector)
	{
		//Call the randomize function to calculate a position within the current cell. 
		v3RandomizedCourse = FindRandomSpotInCurCell();
		bCalcNewRandCourseVector = false;
	}
	if(Vector3.Distance(transform.position, v3RandomizedCourse) < transform.localScale.x)
	{
		FaceDirection(false);
		if(fPause>-1)
			fPause -= Time.deltaTime;
		if(fPause<0)
		{
			bCalcNewRandCourseVector = true;
			fPause = 2.0f;
		}
	}
	else
	{			
		transform.position += (v3RandomizedCourse - transform.position).normalized * currentMoveSpeed * Time.deltaTime;
		FaceDirection(true);
	}
}

//////////////////////////////////////////////////////////////////////////
//Name: FindRandomSpotInCurCell
//Use: 	Called to calculate random position in the current cell. 
//Para: None
/////////////////////////////////////////////////////////////////////////// 
function FindRandomSpotInCurCell()
{
	return currentCell.transform.position + (currentCell.transform.rotation * Vector3(Random.Range(
	currentCell.transform.localScale.x * -0.5, currentCell.transform.localScale.x * 0.5), 0, Random.Range(
	currentCell.transform.localScale.z * -0.5, currentCell.transform.localScale.z * 0.5)));
}

//////////////////////////////////////////////////////////////////////////
//Name: GoForPlayer
//Use: 	Called when companion is in the same cell as player. 
//		Will simply move towards player's position until a certain distance.
//		Will also begin the countdown for idle timer. 
//Para: None
///////////////////////////////////////////////////////////////////////////
function GoForPlayer()
{
	playerTransform = GameObject.FindWithTag("PlayerPosition").GetComponent(Transform);
	var playerDistance : float = Vector3.Distance(playerTransform.position, gameObject.transform.position);
	
	if(playerDistance>10.0f)
		currentMoveSpeed = 10.0f;
	else
		currentMoveSpeed = 4.0f;
		
	Debug.Log("Going for Player");
	/////////////////////////////////////////////////////////////////////
	//If distance between companion and player is greater than 5
	/////////////////////////////////////////////////////////////////////
	if(Vector3.Distance(transform.position, playerTransform.position) > fGapBetweenPlayer)
	{
		transform.position += (playerTransform.position - transform.position).normalized * currentMoveSpeed * Time.deltaTime;
		//transform.rotation = Quaternion.LookRotation(transform.position - v3LastPos);
		//qLastRotation = transform.rotation;
		FaceDirection(true);
	}				
	else 
	{
		//transform.rotation = qLastRotation;
		FaceDirection(false);
	}
}

//////////////////////////////////////////////////////////////////////////
//Name: GoForDoor
//Use: 	Called if the companion is not in the same cell as the player. 
//		Will make companion move towards the door leading to shortest path
//		to player.
//Para: None
///////////////////////////////////////////////////////////////////////////
function GoForDoor()
{
	Debug.Log("Going for Door");
	
	var playerDistance : float = Vector3.Distance(playerTransform.position, gameObject.transform.position);
	
	if(playerDistance>10.0f)
		currentMoveSpeed = 10.0f;
	else
		currentMoveSpeed = 4.0f;
	
	transform.position += (goalDoor.transform.position - transform.position).normalized * currentMoveSpeed * Time.deltaTime;	
	FaceDirection(true);
	//Reset idle timer
	fIdleTimer = 10.0f;
	//set to true so that it calculates in new current cell 
	bCalcNewRandCourseVector = true;
}

//////////////////////////////////////////////////////////////////////////
//Name: CalcPathToPlayer
//Use: 	Called to shift through every door to determine which is the shortest
//		path to the player
//Para: None
///////////////////////////////////////////////////////////////////////////
function CalcPathToPlayer()
{
	playerCell = playerMovementScript.currentCell;
		
	for(var doorCheckNow : GameObject in currentCell.GetComponent(AIpathCellScript).doors)
	{
		for(var i:int = 0; i < doorCheckNow.GetComponent(AIpathDoorScript).cells.length; i++)
		{
			if(doorCheckNow.GetComponent(AIpathDoorScript).cells[i] == playerCell)
			{
				if(doorCheckNow.GetComponent(AIpathDoorScript).doorsToCells[i] < shortestPathSoFar)
				{
					goalDoor = doorCheckNow;
					shortestPathSoFar = doorCheckNow.GetComponent(AIpathDoorScript).doorsToCells[i];
				}
			}
		}
	}
	shortestPathSoFar = Mathf.Infinity;	
}

//////////////////////////////////////////////////////////////////////////
//Name: FaceDirection
//Use: 	Called to change the rotation of the mesh to match the direction
//		it is moving to. 
//Para: Call the function with true if the object is in motion. False when 
//		object needs to keep to face the last direction it is facing.
///////////////////////////////////////////////////////////////////////////
function FaceDirection(bIsMoving : boolean)
{
	if(bIsMoving)
	{
		transform.rotation = Quaternion.LookRotation(transform.position - v3LastPos);
		qLastRotation = transform.rotation;
	}
	else
	{
		transform.rotation = qLastRotation;
	}
}




#pragma strict

//Variables
var whiteMissilePrefab : GameObject;
var darkMissilePrefab : GameObject;
var endDoor : GameObject;
var moveDoor;
//floats
private var startTimer : float;
var spawnTime : float = 3.0f;
var spawnRate : float = 5.0f; 
//ints
var spiritMax : int = 1;
var spiritCount : int = 0; 
var bossHealth : int = 5; 
var STYLE : int = 0;
//booleans
var canSpawn : boolean = true;
private var bPlayerArrives : boolean = false;
private var bIsDead : boolean = false;


function Start () 
{
	whiteMissilePrefab = Resources.Load("White Spirit") as GameObject;
	darkMissilePrefab = Resources.Load("Dark Spirit") as GameObject;
	startTimer = 3.0f;
	moveDoor = endDoor.GetComponent("MoveObject");
}

function Update () 
{	 
	if(bPlayerArrives)
	{
		if(startTimer <= 0)
		{
			if(bossHealth<=0 && !bIsDead)
			{
				endDoor.tag = "Door";
				this.gameObject.animation.Play("Death_Mateas");
				bIsDead = true;
			} 
			/*else if(bossHealth>0) //never enter here after spiritCount >= spiritMax; logical error
			{
				canSpawn = true;
				spawnTime -= Time.deltaTime;  
			}*/
			if(spiritCount>=spiritMax)
			{
				canSpawn = false;
			}
			else if(spiritCount <= spiritMax)
			{
				canSpawn = true;
				spawnTime -= Time.deltaTime;
			} 
			
			//this.animation.Play("Idle_Mateas");
			//Will only spawn more once the previous wave is all gone
			if(canSpawn && spawnTime <= 0 && !bIsDead) //check if spawn time allows you to spawn more
			{
				if(!this.gameObject.animation.IsPlaying("Summon"))
				{
					this.gameObject.animation.Play("Summon");
				}
				spawnTime = spawnRate;
						
				switch(STYLE)
				{
				case 0: 
					Debug.Log("SpiritCount: " + spiritCount + " Style 0");
					spiritCount++;
					SpawnWave(1);
					break; 
				case 1:	 
					//Broken
					Debug.Log("SpiritCount: " + spiritCount + " Style 1");
					spiritCount++;
					SpawnSpam(1); 
					break;
				}
					
				//Play audio clip 
				/*if(!audio.IsPlaying())
				{
					audio.Play();
				}
				else if(audio.IsPlaying())
				{ audio.Pause();}*/
			} 
			
			if(!animation.IsPlaying("Death_Mateas") && bIsDead)
			{
				Destroy(gameObject.FindWithTag("Boss").gameObject);
				
			}
		}
		startTimer -= Time.deltaTime;
		Debug.Log("start time: " + startTimer);
	}
}

function SubtractSpirit()
{
	 spiritCount--;
}

//Spawn enemies at once in waves
function SpawnWave(num:int)
{
	var rand : int;
	var newMissile : GameObject;
 
 	//for(var i:int=0; i<num; i++)
 	//{
		rand = Random.Range(0,2);
		if(rand==0) 
		{ 
			newMissile = Instantiate(whiteMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
			newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver); 
			//spiritCount++; 
		}
		else 
		{
			newMissile = Instantiate(darkMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
			newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver); 
			//spiritCount++; 
		}
		//spiritCount++;  
	//} 
} 

function SpawnSpam(num:int)
{
	var rand : int;
	var newMissile : GameObject; 
	
	//if(num>0)
	//{
		rand = Random.Range(0,2);
		if(rand==0) 
		{ 
			newMissile = Instantiate(whiteMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
			newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver);
		}
		else 
		{
			newMissile = Instantiate(darkMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
			newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver);
		}
		
		//spiritCount++; 
		//num--;
	//} 
} 
 
//For when the boss gets damaged. Increment difficulty. 
function Activate()
{
	//spiritMax++; 
	spawnRate = spawnRate / 2 ;
	bossHealth--;
	if(bossHealth > 0 )
	{
		this.gameObject.animation.Play("Damage_Mateas");
	}
	else if (bossHealth <= 0)
	{
		this.gameObject.animation.Play("Knockback");
	}
}

function StartTimer()
{
	bPlayerArrives = true;
}


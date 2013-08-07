

//Variables
var whiteMissilePrefab : GameObject;
var darkMissilePrefab : GameObject;
var spawnTime : float = 1.0f;
var spawnRate : float = 5.0f; 
var spiritMax : int = 5;
var spiritCount : int = 0; 
var canSpawn : boolean = true;
var bossHealth : int = 5; 

var STYLE : int = 0;

function Start () 
{
	whiteMissilePrefab = Resources.Load("White Spirit") as GameObject;
	darkMissilePrefab = Resources.Load("Dark Spirit") as GameObject;
}

function Update () 
{	 
	if(bossHealth<=0)
	{
		Destroy(gameObject.Find("BossMesh").gameObject);
	} 
	if(spiritCount>=spiritMax)
		canSpawn = false;
	else if(bossHealth>0) 
	{
		canSpawn = true;
		spawnTime -= Time.deltaTime;  
	}
	
	
	//Will only spawn more once the previous wave is all gone
	if(canSpawn)
	{
		if(spawnTime <= 0)
		{ 
			spawnTime = spawnRate;
				
			switch(STYLE)
			{
			case 0: 
				SpawnWave(spiritMax);
				
				break; 
			case 1:	 
				//Broken
				SpawnSpam(spiritMax); 
				break;
	
			
			}
			
			//Play audio clip 
			audio.Play();
		} 
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
 
 	for(var i:int=0; i<num; i++)
 	{
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
		spiritCount++;  
	} 
} 

function SpawnSpam(num:int)
{
	var rand : int;
	var newMissile : GameObject; 
	
	if(num>0)
	{
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
		
		spiritCount++; 
		num--;
	} 
} 
 
//For when the boss gets damaged. Increment difficulty. 
function Hurt()
{
	spiritMax += 5; 
	bossHealth--;
}




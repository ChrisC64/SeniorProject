

//Variables
var whiteMissilePrefab : GameObject;
var darkMissilePrefab : GameObject;
var spawnTime : float = 5.0f;
var spawnRate : float = 1.0f; 
var spiritMax : int = 5;
var spiritCount : int = 0; 
var canSpawn : boolean = true; 

var STYLE : int = 0;

function Start () 
{
	whiteMissilePrefab = Resources.Load("White Spirit") as GameObject;
	darkMissilePrefab = Resources.Load("Dark Spirit") as GameObject;
}

function Update () 
{
	spawnTime -= Time.deltaTime; 
	
	if(spiritCount>=spiritMax)
		canSpawn = false;
	else if(spiritCount==0) 
	{
		canSpawn = true;  
	}
	
	
	//Will only spawn more once the previous wave is all gone
	if(spiritCount<spiritMax && canSpawn)
	{
		if(spawnTime <= 0)
		{
			spawnTime = spawnRate; 
				
			switch(STYLE)
			{
			case 0: 
				SpawnWave(5);
				break; 
			case 1:
				SpawnSpam();
				break;
	
			
			}
//			for(var i:int=0; i<5; i++)
//			{
//			SpawnSpirits();
//			spiritCount++; 
//			}
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
			spiritCount++; 
		}
		else 
		{
			newMissile = Instantiate(darkMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
			newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver); 
			spiritCount++; 
		} 
	}
} 

function SpawnSpam()
{
	var rand : int;
	var newMissile : GameObject; 
	
	rand = Random.Range(0,2);
	if(rand==0) 
	{ 
		newMissile = Instantiate(whiteMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
		newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver);
		spiritCount++;
	}
	else 
	{
		newMissile = Instantiate(darkMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation); 
		newMissile.SendMessage("RandomRise", SendMessageOptions.DontRequireReceiver);
		spiritCount++;
	}
}




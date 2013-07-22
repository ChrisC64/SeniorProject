

//Variables
var whiteMissilePrefab : GameObject;
var darkMissilePrefab : GameObject;
var spawnTime : float = 5.0f;
var spawnRate : float = 3.0f;

function Start () 
{
	whiteMissilePrefab = Resources.Load("WhiteMissile") as GameObject;
	darkMissilePrefab = Resources.Load("DarkMissile") as GameObject;
}

function Update () 
{
	spawnTime -= Time.deltaTime;
	
	if(spawnTime <= 0)
	{
		spawnTime += spawnRate;
		
		var rand : int = Random.Range(0, 2);
		
		Debug.Log("Missile is: "+rand);
		
		var newMissile : GameObject;
		if(rand==0)
			newMissile = Instantiate(whiteMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation);
		else
			newMissile = Instantiate(darkMissilePrefab, gameObject.transform.position+Vector3(0, 1, 0), transform.rotation);
	}
}


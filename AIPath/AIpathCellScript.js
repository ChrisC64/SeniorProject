

var doors = new Array();
var torches = new Array();
var bTorches : boolean = false;



function Awake()
{
	bTorches = false;
}

function OnTriggerEnter(other : Collider)
{
	if(other.tag=="AIpathDoor")
	{
		doors.Add(other.gameObject);	
	}
	if(other.tag == "Torch")
	{
		Debug.Log("Adding Torch to array list");
		torches.Add(other.gameObject);
		bTorches = true;
	}
}
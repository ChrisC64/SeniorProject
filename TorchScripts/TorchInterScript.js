
var fTimer : float = 2.0f;
var bIsOn : boolean = false;
var bStartTimer : boolean = false;

function Awake()
{
	fTimer = 2.0f;
	bIsOn = false;
	bStartTimer = false;
}

function Update()
{
	if(bStartTimer && !bIsOn)
	{
		fTimer -= Time.deltaTime;
	}
	
	if(fTimer<0)
	{
		transform.parent.gameObject.GetComponent(TorchScripts).CallSwitch();
		bIsOn = true;
		fTimer = 2.0f;
	}
}

//////////////////////////////////////
//Name: OnTriggerEnter
//	Goes through all colliders for the player only.
//	Goes to parent to call the CallSwitch() function.
///////////////////////////////////////
function OnTriggerEnter(colider : Collider)
{
	if(colider.tag == "Companion")
	{	
		bStartTimer = true;
	}
}
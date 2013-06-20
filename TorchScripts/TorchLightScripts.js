

var bIsOn : boolean = false;

function Awake () 
{
	bIsOn = false;
	Switch();
}


//////////////////////////////////////////////////
//Name:		Switch()
//Function:	If called will toggle the point light
//			on or off depending on its current state.
//Param: 	None
//////////////////////////////////////////////////
function Switch()
{
	Debug.Log("Switch() is called");
	//If light is off, turn it on
	if(!bIsOn)
	{
		Debug.Log("Torch is off");
		gameObject.SetActive(false);
		bIsOn = true;
	}
	else
	{
		Debug.Log("Torch is on");
		gameObject.SetActive(true);
		bIsOn = false;
	}
}
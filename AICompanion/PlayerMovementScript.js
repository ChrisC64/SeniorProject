

var currentCell:GameObject;

function OnTriggerStay (hitTrigger : Collider)
{
	if(hitTrigger.tag == "AIpathCell")
	{
		currentCell = hitTrigger.gameObject;
	}
}

function OnTriggerExit ()
{
	//BE CAREFUL WITH THIS CODE!!!!!!!!!!!!
	//currentCell = null;
}
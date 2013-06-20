

//Simply calls the Switch() function to
//Toggle the point light child to active or inactive. 
function CallSwitch()
{
	transform.Find("TorchLight").GetComponent(TorchLightScripts).Switch();
}
#pragma strict


//Variables:
var DialogClip : AudioClip;
var OnlyOnce : boolean;

function Start () 
{

}

function Update () 
{
	
}

function OnTriggerEnter (other:Collider)
{
	if(other.transform.tag == "Player")
	{		
		if(OnlyOnce)
		{
			GameObject.Find("Companion Body").SendMessage("PlayAudioClip", DialogClip, SendMessageOptions.DontRequireReceiver); 
			Destroy(gameObject);
		}
		else 
		{
			GameObject.Find("Companion Body").SendMessage("PlayAudioClip", DialogClip, SendMessageOptions.DontRequireReceiver); 
		}
	}
}
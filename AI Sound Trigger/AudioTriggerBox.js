#pragma strict


//Variables:
var DialogClip : AudioClip;
var BackgroundClip : AudioClip;
var AmbienceClip : AudioClip;
var DialogOnce : boolean; 
var AmbienceOnce : boolean;

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
		if(BackgroundClip!=null)
		{
			GameObject.FindGameObjectWithTag("BackgroundSound").audio.clip = BackgroundClip;
			GameObject.FindGameObjectWithTag("BackgroundSound").audio.Play();
		}
		
		if(AmbienceClip!=null)
		{ 
			if(AmbienceOnce)
				GameObject.FindGameObjectWithTag("AmbienceSound").audio.PlayOneShot(AmbienceClip, 1);
			else
			{
				GameObject.FindGameObjectWithTag("AmbienceSound").audio.clip = AmbienceClip;
				if(!GameObject.FindGameObjectWithTag("AmbienceSound").audio.isPlaying)
					GameObject.FindGameObjectWithTag("AmbienceSound").audio.Play();
			}	
			
			if(AmbienceOnce && !GameObject.FindGameObjectWithTag("AmbienceSound").audio.isPlaying)
			{
				AmbienceClip = null; 
				GameObject.FindGameObjectWithTag("AmbienceSound").audio.clip = null;
			}
		}
		
		if(DialogClip!=null)
		{ 
			if(DialogOnce)
				GameObject.Find("Nora").audio.PlayOneShot(DialogClip, 1);
			else
			{
				GameObject.Find("Nora").audio.clip = DialogClip;
				if(!GameObject.Find("Nora").audio.isPlaying) 
					GameObject.Find("Nora").audio.Play();
			}
			
			if(DialogOnce && !GameObject.Find("Nora").audio.isPlaying)
			{  
				DialogClip = null;
				GameObject.Find("Nora").audio.clip = null;
			}				
		}
	}
}

function OnTriggerExit(other:Collider)
{
}
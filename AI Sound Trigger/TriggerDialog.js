#pragma strict

function Start () 
{
}

function Update () 
{

}

function PlayAudioClip(SoundClip)
{
	gameObject.audio.clip = SoundClip;	
	gameObject.audio.Play();
}
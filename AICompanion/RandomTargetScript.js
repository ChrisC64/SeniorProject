#pragma strict

var companion : CompanionAIScript;

function Awake () {
	companion = GameObject.FindWithTag("Companion").GetComponent(CompanionAIScript);
}

function Update () {

	transform.position = companion.v3RandomizedCourse;

}
import System.IO;
#pragma strict

var framesPerSecond : int = 10.0;
var frames : Texture2D[];
var shoot : boolean = false;

function Start () {
	shoot = false;
}

function Update () {
	if(shoot == true) {
		var index : int = Time.time * framesPerSecond;
     	index = index % frames.Length;
     	GetComponent.<Renderer>().material.mainTexture = frames[index];
		Debug.Log("Selected Frame: " + index);
	}
}

function startMovie(frms : Texture2D[]) {
	frames = frms;
	shoot = true;
}
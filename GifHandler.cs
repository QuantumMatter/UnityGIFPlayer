using UnityEngine;
using System.Collections;
using System.IO;

public class GifHandler : MonoBehaviour {

	private GifAnimator animator;

	public Texture2D[] frames;
	public string filePath = "Assets/Images/test/";
	public float framesPerSec = 10.0f;
	// Use this for initialization
	void Start () {
		DirectoryInfo dir = new DirectoryInfo (filePath);
		FileInfo[] info = dir.GetFiles ("*.*");
		frames = new Texture2D[info.Length / 2];
		int index = 0;
		foreach (FileInfo f in info) {
			string[] name = f.Name.Split('.');
			if (f.Exists && (name[name.Length - 1].Equals("png"))) {
				string imagePath = f.Directory + "/" + f.Name;
				//Debug.Log(imagePath);
				frames[index] = LoadTexture(imagePath);
				index++;
			}
		}
		animator = this.GetComponent<GifAnimator> ();
		animator.startMovie (frames);
	}

	public static Texture2D LoadTexture(string filePath) {
		
		Texture2D tex = null;
		byte[] fileData;
		
		if (File.Exists (filePath)) {
			fileData = File.ReadAllBytes (filePath);
			if (fileData == null) {
				Debug.Log ("fileData is null");
			} else {
				Debug.Log ("fileData is not null");
			}
			tex = new Texture2D (2, 2);
			tex.LoadImage (fileData); //..this will auto-resize the texture dimensions.
		} else {
			Debug.Log("Image Not Found");
		}
		return tex;
	}
	
	// Update is called once per frame
	void Update () {

	}
}

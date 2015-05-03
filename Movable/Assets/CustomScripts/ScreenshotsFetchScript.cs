using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ScreenshotsFetchScript : MonoBehaviour {

	private static string folderPath = Application.persistentDataPath;

	private FileInfo[] info;
	private Texture2D previous;
	private Texture2D next;
	private Texture2D current;
	private int currentPosition;

	// Use this for initialization
	void OnGUI() {
		if(null != current) {
			GUI.DrawTexture(new Rect(0, 0, 500, 500), current);
		}
	}

	void Start () {
		DirectoryInfo dir = new DirectoryInfo(folderPath);
		info = dir.GetFiles("*.*");
		currentPosition = 0;
		previous = null;
		
		if (info.Length == 0) {
			return;
		}
		
		Debug.Log("Readin file from: " + folderPath + Path.DirectorySeparatorChar + info[currentPosition].Name);
		
		WWW www = new WWW("file://" + folderPath + Path.DirectorySeparatorChar + info[currentPosition].Name);
		current = new Texture2D(500, 500);
		www.LoadImageIntoTexture(current);
		
		Debug.Log("Ajmoooo2 ");
		
		if (info.Length == 1) {
			next = null;
			return;
		}

		next = new Texture2D(500, 500);
		www = new WWW("file://" + folderPath + Path.DirectorySeparatorChar + info[currentPosition + 1].Name);
		www.LoadImageIntoTexture(next);
	}

	public void showNext() {
		if (next == null) {
			return;
		}
		previous = current;
		current = next;

		currentPosition++;

		if (currentPosition == info.Length - 1) {
			next = null;
			return;
		}

		WWW www = new WWW("file://" + folderPath + Path.DirectorySeparatorChar + info[currentPosition + 1].Name);
		www.LoadImageIntoTexture(next);
	}

	public void showPrevious() {
		if (previous == null) {
			return;
		}
		next = current;
		current = previous;

		currentPosition--;
		
		if (currentPosition == 0) {
			previous = null;
			return;
		}
		
		WWW www = new WWW("file://" + folderPath + Path.DirectorySeparatorChar + info[currentPosition - 1].Name);
		www.LoadImageIntoTexture(previous);
	}

}

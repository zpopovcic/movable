using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScreenshotsFetchScript : MonoBehaviour {

	private static string folderPath = Application.persistentDataPath;

	private List<Sprite> sprites = new List<Sprite>();

	private FileInfo[] info;

	private int currentPosition;

	void Update() {
		gameObject.GetComponent<Image>().sprite = sprites[currentPosition];
	}

	void Start () {
		DirectoryInfo dir = new DirectoryInfo(folderPath);
		info = dir.GetFiles("*.*");
		currentPosition = info.Length - 1;

		foreach(FileInfo fileInfo in info) {
			WWW www = new WWW("file://" + folderPath + Path.DirectorySeparatorChar + fileInfo.Name);
			Texture2D texture2d = new Texture2D(1080, 1920);
			www.LoadImageIntoTexture(texture2d);
			sprites.Add(Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), new Vector2(0.5f, 0.5f)));
		}
	}

	public void showPrevious() {
		if (currentPosition == info.Length - 1) {
			return;
		}

		currentPosition++;
	}

	public void showNext() {
		if (currentPosition == 0) {
			return;
		}

		currentPosition--;
	}

}

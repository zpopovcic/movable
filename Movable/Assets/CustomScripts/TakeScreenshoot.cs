using UnityEngine;
using System;
using System.IO;

public class TakeScreenshoot : MonoBehaviour {

	private const string SCREENSHOT_NAME = "MovableShot";

	public void OnClick () {
		//gameObject.SetActive(false);
		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		string filename = SCREENSHOT_NAME + time + ".png";

		Application.CaptureScreenshot(filename);
		ShowObject.screenshotFile = Application.persistentDataPath + Path.DirectorySeparatorChar + filename;

		Debug.Log ("Saved screenshot to " + Application.persistentDataPath + "/" + filename);
	}

}

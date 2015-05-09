using UnityEngine;
using System;
using System.IO;

public class TakeScreenshoot : MonoBehaviour {

	private const string SCREENSHOT_NAME = "MovableShot";
	private static string screenshotFile = null;

	private GameObject buttonBackEC;
	private GameObject buttonImageGallery;
	private GameObject buttonAddObject;
	private GameObject buttonShare;
	private GameObject buttonTakePhoto;
	private GameObject buttonFlashEC;
	private GameObject buttonSettings;

	void Update() {
		loadButtons();
		if (null != screenshotFile) {
			Debug.Log("File " + screenshotFile + " " + File.Exists(screenshotFile));
			if (File.Exists(screenshotFile)) {
				screenshotFile = null;
				setActive(true);
			}
		}
	}

	public void OnClick () {
		loadButtons();
		setActive(false);

		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		string filename = SCREENSHOT_NAME + time + ".png";

		Application.CaptureScreenshot(filename);
		screenshotFile = Application.persistentDataPath + Path.DirectorySeparatorChar + filename;

		Debug.Log ("Saved screenshot to " + Application.persistentDataPath + "/" + filename);
	}

	private void setActive(bool isActive) {
		buttonBackEC.SetActive(isActive);
		buttonImageGallery.SetActive(isActive);
		buttonAddObject.SetActive(isActive);
		buttonShare.SetActive(isActive);
		buttonTakePhoto.SetActive(isActive);
		buttonFlashEC.SetActive(isActive);
		buttonSettings.SetActive(isActive);
	}

	private void loadButtons() {
		if (buttonBackEC == null) {
			buttonBackEC = GameObject.Find("ButtonBackEC");
		}
		if (buttonImageGallery == null) {
			buttonImageGallery = GameObject.Find("ButtonImageGallery");
		}
		if (buttonAddObject == null) {
			buttonAddObject = GameObject.Find("ButtonAddObject");
		}
		if (buttonShare == null) {
			buttonShare = GameObject.Find("ButtonShare");
		}
		if (buttonTakePhoto == null) {
			buttonTakePhoto = GameObject.Find("ButtonTakePhoto");
		}
		if (buttonFlashEC == null) {
			buttonFlashEC = GameObject.Find("ButtonFlashEC");
		}
		if (buttonSettings == null) {
			buttonSettings = GameObject.Find("ButtonSettings");
		}
	}

}

using UnityEngine;
using System;
using System.IO;

public class TakeScreenshoot : MonoBehaviour {

	private const string SCREENSHOT_NAME = "MovableShot";
	private static string screenshotFilename = null;

	private GameObject buttonBackEC;
	private GameObject buttonImageGallery;
	private GameObject buttonAddObject;
	private GameObject buttonShare;
	private GameObject buttonTakePhoto;
	private GameObject buttonFlashEC;
	private GameObject buttonSettings;

	private GameObject panel;

	void Update() {
		loadButtons();
		if (null != screenshotFilename) {
			if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + screenshotFilename)) {
				string flnm = screenshotFilename;
				screenshotFilename = null;
				setActive(true);
				CanvasChanger.ALL_PICTURES_CANVAS.SetActive(true);
				if (null == panel) {
					panel = GameObject.Find("PanelGallery");
				}
				panel.GetComponent<PictureGalleryLoader>().addNewSprite(flnm);
				CanvasChanger.ALL_PICTURES_CANVAS.SetActive(false);
			}
		}
	}

	public void OnClick () {
		loadButtons();
		setActive(false);

		String time = DateTime.Now.ToString("yyyyMMdd_hhmmssfff");
		string filename = SCREENSHOT_NAME + time + ".png";

		Application.CaptureScreenshot(filename);
		screenshotFilename = filename;
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

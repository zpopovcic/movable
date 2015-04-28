using UnityEngine;
using System.Collections;
using System.IO;

public class ShowObject : MonoBehaviour {

	public static string screenshotFile = null;

	private GameObject button;

	void Update() {
		if (button == null) {
			button = GameObject.Find("TakePhotoButton");
		}
		if (null != screenshotFile) {
			Debug.Log("File " + screenshotFile + " " + File.Exists(screenshotFile));
			if (File.Exists(screenshotFile)) {
				screenshotFile = null;
				button.SetActive(true);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class SettingsCanvasScript : MonoBehaviour {

	void Start () {
		CanvasChanger.SETTINGS_CANVAS = gameObject;
		gameObject.SetActive(false);
	}
}

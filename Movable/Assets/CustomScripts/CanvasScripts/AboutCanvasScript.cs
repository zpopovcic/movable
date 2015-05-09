using UnityEngine;
using System.Collections;

public class AboutCanvasScript : MonoBehaviour {

	void Start () {
		CanvasChanger.ABOUT_CANVAS = gameObject;
		gameObject.SetActive(false);
	}
}

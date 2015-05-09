using UnityEngine;
using System.Collections;

public class StartCanvasScript : MonoBehaviour {

	void Start () {
		CanvasChanger.START_CANVAS = gameObject;
		gameObject.SetActive(true);
	}
}

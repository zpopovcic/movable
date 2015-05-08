using UnityEngine;
using System.Collections;

public class CreateTargetCanvasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CanvasChanger.CREATE_TARGET_CANVAS = gameObject;
		gameObject.SetActive(false);
	}

}

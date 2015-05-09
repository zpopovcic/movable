using UnityEngine;
using System.Collections;

public class ARCameraScript : MonoBehaviour {
	
	void Start () {
		CanvasChanger.AR_CAMERA = gameObject;
		gameObject.SetActive(true);
	}

}

using UnityEngine;
using System.Collections;

public class AllObjectsCanvasScript : MonoBehaviour {

	void Start () {
		CanvasChanger.ALL_OBJECTS_CANVAS = gameObject;
		gameObject.SetActive(false);
	}
}

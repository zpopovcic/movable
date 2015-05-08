using UnityEngine;
using System.Collections;

public class AllPicturesCanvasScript : MonoBehaviour {

	void Start () {
		CanvasChanger.ALL_PICTURES_CANVAS = gameObject;
		gameObject.SetActive(false);
	}
}

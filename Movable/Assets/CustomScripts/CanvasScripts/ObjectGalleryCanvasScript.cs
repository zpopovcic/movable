using UnityEngine;
using System.Collections;

public class ObjectGalleryCanvasScript : MonoBehaviour {

	void Start () {
		CanvasChanger.OBJECT_GALLERY_CANVAS = gameObject;
		gameObject.SetActive(false);
	}
}

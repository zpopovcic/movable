using UnityEngine;
using System.Collections;

public class PictureGalleryCanvasScript : MonoBehaviour {
	
	void Start () {
		CanvasChanger.PICTURE_GALLERY_CANVAS = gameObject;
		gameObject.SetActive(false);
	}

}

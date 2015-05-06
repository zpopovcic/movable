using UnityEngine;
using System.Collections;

public class CanvasChanger : MonoBehaviour {

	public static GameObject PICTURE_GALLERY_CANVAS;
	public static GameObject EXPLORE_CANVAS;
	public static GameObject AR_CAMERA;

	public void pictureGalleryToExplore() {
		PICTURE_GALLERY_CANVAS.SetActive(false);
		EXPLORE_CANVAS.SetActive(true);
		AR_CAMERA.SetActive(true);
	}

	public void exploreToPictureGallery() {
		AR_CAMERA.SetActive(false);
		EXPLORE_CANVAS.SetActive(false);
		PICTURE_GALLERY_CANVAS.SetActive(true);
	}

}

using UnityEngine;
using System.Collections;

public class CanvasChanger : MonoBehaviour {

	public static GameObject PICTURE_GALLERY_CANVAS;
	public static GameObject EXPLORE_CANVAS;
	public static GameObject AR_CAMERA;
	public static GameObject ALL_PICTURES_CANVAS;
	public static GameObject ALL_OBJECTS_CANVAS;
	public static GameObject OBJECT_GALLERY_CANVAS;

	public static void allPicturesToPictureGallery() {
		PICTURE_GALLERY_CANVAS.SetActive(true);
		ScreenshotsFetchScript.sprites = PictureGalleryLoader.sprites;
		ALL_PICTURES_CANVAS.SetActive(false);
	}

	public void pictureGalleryToAllPictures() {
		PICTURE_GALLERY_CANVAS.SetActive(false);
		ALL_PICTURES_CANVAS.SetActive(true);
	}

	public void allPicturesToExplore() {
		ALL_PICTURES_CANVAS.SetActive(false);
		EXPLORE_CANVAS.SetActive(true);
		AR_CAMERA.SetActive(true);
	}

	public void exploreToAllPictures() {
		AR_CAMERA.SetActive(false);
		EXPLORE_CANVAS.SetActive(false);
		ALL_PICTURES_CANVAS.SetActive(true);
	}

	public void exploreToAllObjects() {
		AR_CAMERA.SetActive(false);
		EXPLORE_CANVAS.SetActive(false);
		ALL_OBJECTS_CANVAS.SetActive(true);
	}

	public void allObjectsToExplore() {
		ALL_OBJECTS_CANVAS.SetActive(false);
		EXPLORE_CANVAS.SetActive(true);
		AR_CAMERA.SetActive(true);
	}

	public static void allObjectsToObjectGallery() {
		OBJECT_GALLERY_CANVAS.SetActive(true);
		ObjectPicturesFetchScript.sprites = ObjectGalleryLoader.sprites;
		ALL_OBJECTS_CANVAS.SetActive(false);
	}
	
	public void objectGalleryToAllObjects() {
		OBJECT_GALLERY_CANVAS.SetActive(false);
		ALL_OBJECTS_CANVAS.SetActive(true);
	}

}

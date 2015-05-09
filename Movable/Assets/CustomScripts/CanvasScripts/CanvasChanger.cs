using UnityEngine;
using System.Collections;

public class CanvasChanger : MonoBehaviour {

	public static GameObject PICTURE_GALLERY_CANVAS;
	public static GameObject EXPLORE_CANVAS;
	public static GameObject AR_CAMERA;
	public static GameObject ALL_PICTURES_CANVAS;
	public static GameObject ALL_OBJECTS_CANVAS;
	public static GameObject OBJECT_GALLERY_CANVAS;
	public static GameObject CREATE_TARGET_CANVAS;
	public static GameObject ABOUT_CANVAS;
	public static GameObject SETTINGS_CANVAS;
	public static GameObject START_CANVAS;

	private static int startOrExplore;

	public static void allPicturesToPictureGallery() {
		PICTURE_GALLERY_CANVAS.SetActive(true);
		ScreenshotsFetchScript.sprites = PictureGalleryLoader.sprites;
		ALL_PICTURES_CANVAS.SetActive(false);
	}

	public void pictureGalleryToAllPictures() {
		PICTURE_GALLERY_CANVAS.SetActive(false);
		ALL_PICTURES_CANVAS.SetActive(true);
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

	public static void deactivateObjectGallery() {
		OBJECT_GALLERY_CANVAS.SetActive(false);
	}

	public static void activateCreateTarget(){
		AR_CAMERA.SetActive(true);
		CREATE_TARGET_CANVAS.SetActive(true);
	}

	public void createTargetToObjectGallery() {
		CREATE_TARGET_CANVAS.SetActive(false);
		AR_CAMERA.SetActive(false);
		OBJECT_GALLERY_CANVAS.SetActive(true);
	}

	public void aboutToStart() {
		ABOUT_CANVAS.SetActive(false);
		START_CANVAS.SetActive(true);
	}

	public void exploreToStart() {
		EXPLORE_CANVAS.SetActive(false);
		START_CANVAS.SetActive(true);
	}

	public static void createTargetToExplore() {
		CREATE_TARGET_CANVAS.SetActive(false);
		EXPLORE_CANVAS.SetActive(true);
	}

	//FROM EXPLORE
	public void exploreToAllPictures() {
		startOrExplore = 1;
		AR_CAMERA.SetActive(false);
		EXPLORE_CANVAS.SetActive(false);
		ALL_PICTURES_CANVAS.SetActive(true);
	}
	
	public void exploreToAllObjects() {
		startOrExplore = 1;
		AR_CAMERA.SetActive(false);
		EXPLORE_CANVAS.SetActive(false);
		ALL_OBJECTS_CANVAS.SetActive(true);
	}

	public void exploreToSettings() {
		startOrExplore = 1;
		AR_CAMERA.SetActive(false);
		EXPLORE_CANVAS.SetActive(false);
		SETTINGS_CANVAS.SetActive(true);
	}

	//FROM START
	public void startToExplore() {
		START_CANVAS.SetActive(false);
		AR_CAMERA.SetActive(true);
		EXPLORE_CANVAS.SetActive(true);
	}

	public void startToAllObjects() {
		startOrExplore = 0;
		START_CANVAS.SetActive(false);
		ALL_OBJECTS_CANVAS.SetActive(true);
	}

	public void startToAllPictures() {
		startOrExplore = 0;
		START_CANVAS.SetActive(false);
		ALL_PICTURES_CANVAS.SetActive(true);
	}

	public void startToSettings() {
		startOrExplore = 0;
		START_CANVAS.SetActive(false);
		SETTINGS_CANVAS.SetActive(true);
	}

	public void startToAbout() {
		START_CANVAS.SetActive(false);
		ABOUT_CANVAS.SetActive(true);
	}

	//PROBLEM
	public void backFromAllObjects() {
		ALL_OBJECTS_CANVAS.SetActive(false);
		if (startOrExplore == 0) {
			START_CANVAS.SetActive(true);
			return;
		}
		EXPLORE_CANVAS.SetActive(true);
		AR_CAMERA.SetActive(true);
	}

	public void backFromAllPictures() {
		ALL_PICTURES_CANVAS.SetActive(false);
		if (startOrExplore == 0) {
			START_CANVAS.SetActive(true);
			return;
		}
		EXPLORE_CANVAS.SetActive(true);
		AR_CAMERA.SetActive(true);
	}

	public void backFromSettings() {
		SETTINGS_CANVAS.SetActive(false);
		if (startOrExplore == 0) {
			START_CANVAS.SetActive(true);
			return;
		}
		EXPLORE_CANVAS.SetActive(true);
		AR_CAMERA.SetActive(true);
	}

}

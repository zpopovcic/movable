using UnityEngine;
using System.Collections;
using Vuforia;

public class PrepareUDTargetCapturing : MonoBehaviour {

	public void OnClick() {
		CanvasChanger.activateCreateTarget();
		ImageTargetBehaviour imageTargetTemplate = GameObject.Find("UDImageTarget" + ObjectPicturesFetchScript.currentPosition).GetComponent<ImageTargetBehaviour>();
		UserDefinedTargetEventHandler mTargetHandler = GameObject.FindObjectOfType(typeof(UserDefinedTargetEventHandler)) as UserDefinedTargetEventHandler;
		mTargetHandler.imageTargetTemplate = imageTargetTemplate;
		mTargetHandler.Init();
		CanvasChanger.deactivateObjectGallery();
	}

}

using UnityEngine;
using System.Collections;
using Vuforia;

public class PrepareUDTargetCapturing : MonoBehaviour {

	public ImageTargetBehaviour imageTargetTemplate; 

	public void OnClick() {
		Debug.Log("EventHandler STARTED!");
		UserDefinedTargetEventHandler mTargetHandler = GameObject.FindObjectOfType(typeof(UserDefinedTargetEventHandler)) as UserDefinedTargetEventHandler;
		mTargetHandler.imageTargetTemplate = imageTargetTemplate;
		TakeScreenshoot.i = 1;
		mTargetHandler.Init();
	}
}

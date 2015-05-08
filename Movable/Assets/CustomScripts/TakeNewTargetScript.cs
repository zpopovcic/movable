using UnityEngine;
using System.Collections;

public class TakeNewTargetScript : MonoBehaviour {

	public void OnClick () {
		UserDefinedTargetEventHandler mTargetHandler = GameObject.FindObjectOfType(typeof(UserDefinedTargetEventHandler)) as UserDefinedTargetEventHandler;
		if (mTargetHandler.BuildNewTarget()) {
			CanvasChanger.createTargetToExplore();
		}
	}

}

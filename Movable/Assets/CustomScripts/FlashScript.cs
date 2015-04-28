using UnityEngine;
using System.Collections;
using Vuforia;

public class FlashScript : MonoBehaviour {

	private bool flashOn = false;

	public void OnClick() {
		if (flashOn) {
			CameraDevice.Instance.SetFlashTorchMode(false);
			flashOn = false;
			return;
		}
		CameraDevice.Instance.SetFlashTorchMode(true);
		flashOn = true;
	}

}

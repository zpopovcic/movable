using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	private const float ROTATION_RATE = 4f;

	private GameObject rotateableObject;
	
	void Update () {
		if (Input.touches.Length == 3) {
			if (CustomScriptUtils.isAnyTouchEnded(Input.touches)) {
				rotateableObject = null;
				return;
			}
			
			if (CustomScriptUtils.isAnyTouchBegan(Input.touches)) {
				GameObject resizableObj = CustomScriptUtils.getTouchedGameObject(Input.touches);
				if (resizableObj) {
					rotateableObject = resizableObj;
				}
				
				return;
			}
			
			if (CustomScriptUtils.isAnyTouchMoved(Input.touches)) {
				rotateableObject.transform.Rotate(0, getMinimalTouchesDelta() * ROTATION_RATE, 0, Space.World);
			}
		}
	}

	private float getMinimalTouchesDelta() {
		return Mathf.Min (Input.touches [0].deltaPosition.x, Input.touches [1].deltaPosition.x, Input.touches [2].deltaPosition.x);
	}

}

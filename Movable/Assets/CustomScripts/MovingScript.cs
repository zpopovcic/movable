using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

	private GameObject movableObject;

	void Update() {
		if (Input.touches.Length == 1) {
			if (CustomScriptUtils.isAnyTouchEnded(Input.touches)) {
				movableObject = null;
				return;
			}
			
			if (CustomScriptUtils.isAnyTouchBegan(Input.touches)) {
				GameObject movableObj = CustomScriptUtils.getTouchedGameObject(Input.touches);
				if (movableObj) {
					movableObject = movableObj;
				}
				
				return;
			}
			
			if (CustomScriptUtils.isAnyTouchMoved(Input.touches)) {
				if (movableObject) {
					Touch touch = Input.GetTouch(0);
					Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
					movableObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, touch.position.y, cameraTransform.z - 0.5f));

				}
			}
		}

	}
}

using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

	private const float SCALE_COEFICIENT = 10f;
	
	private GameObject movableObject;

	void Update () {
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
					Touch touchedFinger = Input.touches[0];
					
					float currentPositionX = movableObject.transform.position.x + touchedFinger.deltaPosition.x / SCALE_COEFICIENT;
					float currentPositionY = movableObject.transform.position.y + touchedFinger.deltaPosition.y / SCALE_COEFICIENT;
					movableObject.transform.position = new Vector3(currentPositionX, currentPositionY, movableObject.transform.position.z);
				}
			}
		}
	}
}

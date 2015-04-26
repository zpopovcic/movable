using UnityEngine;
using System.Collections;

public class CustomScriptUtils : MonoBehaviour {

	private static RaycastHit rayCastHit;

	public static GameObject getTouchedGameObject(Touch[] touches) {
		foreach (Touch touch in touches) {
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			if (Physics.Raycast (ray.origin, ray.direction, out rayCastHit, Mathf.Infinity)) {
				return rayCastHit.collider.gameObject;
			}
		}
		return null;
	}

	private static bool isAnyTouchInPhase(Touch[] touches, TouchPhase touchPhase) {
		foreach (Touch touch in touches) {
			if (touch.phase == touchPhase) {
				return true;
			}
		}
		return false;
	}

	public static bool isAnyTouchBegan(Touch[] touches) {
		return isAnyTouchInPhase (touches, TouchPhase.Began);
	}

	public static bool isAnyTouchMoved(Touch[] touches) {
		return isAnyTouchInPhase (touches, TouchPhase.Moved);
	}

	public static bool isAnyTouchEnded(Touch[] touches) {
		return isAnyTouchInPhase (touches, TouchPhase.Ended);
	}

}

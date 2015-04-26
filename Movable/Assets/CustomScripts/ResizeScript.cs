using UnityEngine;
using System.Collections;

public class ResizeScript : MonoBehaviour {

	private const float MAX_RESIZE = 4f;

	private GameObject resizableObject;

	private float screenHeight;
	private float coeficient;
	private float lastDistance;
	
	void Update () {
		if (Input.touches.Length == 2) {
			if (CustomScriptUtils.isAnyTouchEnded(Input.touches)) {
				resizableObject = null;
				return;
			}

			if (CustomScriptUtils.isAnyTouchBegan(Input.touches)) {
				GameObject resizableObj = CustomScriptUtils.getTouchedGameObject(Input.touches);
				if (resizableObj) {
					lastDistance = countDistance();
					resizableObject = resizableObj;
				}

				return;
			}

			if (CustomScriptUtils.isAnyTouchMoved(Input.touches) && resizableObject) {
				screenHeight = Screen.height;
				coeficient = screenHeight / (MAX_RESIZE - 1f);

				float newDistance = countDistance();
				float delta = newDistance - lastDistance;
				lastDistance = newDistance;

				if (delta == 0f) {
					return;
				}

				float finalCoeficient = getCoeficient(delta);

				float newScaleX = resizableObject.transform.localScale.x * finalCoeficient;
				float newScaleY = resizableObject.transform.localScale.y * finalCoeficient;
				float newScaleZ = resizableObject.transform.localScale.z * finalCoeficient;

				resizableObject.transform.localScale = new Vector3 (newScaleX, newScaleY, newScaleZ);
			}
		}
	}

	private static float countDistance() {
		Touch touch1 = Input.touches [0];
		Touch touch2 = Input.touches [1];
		return Mathf.Sqrt (Mathf.Pow (touch1.position.x - touch2.position.x, 2f) + Mathf.Pow (touch1.position.y - touch2.position.y, 2f));
	}

	private float getCoeficient(float delta) {
		if (delta > 0f) {
			return 1f + delta / coeficient;
		}
		return 1f / (1f - delta / coeficient);
	}

}

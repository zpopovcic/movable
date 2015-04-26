using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

	private Ray m_Ray;
	private RaycastHit m_RayCastHit;
	private GameObject m_CurrentMovableObject;

	void Update () 
	{
		if (Input.touches.Length == 1) {
			Touch touchedFinger = Input.touches [0];


			switch (touchedFinger.phase) {
			case TouchPhase.Began: 
				m_Ray = Camera.main.ScreenPointToRay (touchedFinger.position);
				if (Physics.Raycast (m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity)) {
					GameObject movableObj = m_RayCastHit.collider.gameObject;
					if (movableObj) {
						m_CurrentMovableObject = movableObj;
					}
				}
				break;
			case TouchPhase.Moved:
				if (m_CurrentMovableObject) { 

					float currentPositionX = m_CurrentMovableObject.transform.position.x + touchedFinger.deltaPosition.x / 10f;
					float currentPositionY = m_CurrentMovableObject.transform.position.y + touchedFinger.deltaPosition.y / 10f;
					m_CurrentMovableObject.transform.position = new Vector3(
						currentPositionX, currentPositionY, m_CurrentMovableObject.transform.position.z);
				}
				break;
			case TouchPhase.Ended:
				m_CurrentMovableObject = null;
				break;
			default:
				break;
			}
		}
	}
}

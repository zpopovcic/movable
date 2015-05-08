using UnityEngine;
using System.Collections;

public class BadButtonScript : MonoBehaviour {

	void Start () {
		UserDefinedTargetEventHandler.badButton = gameObject;
	}
}

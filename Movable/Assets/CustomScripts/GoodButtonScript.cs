using UnityEngine;
using System.Collections;

public class GoodButtonScript : MonoBehaviour {
	
	void Start () {
		UserDefinedTargetEventHandler.goodButton = gameObject;
	}
}

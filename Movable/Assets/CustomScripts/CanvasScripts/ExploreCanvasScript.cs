using UnityEngine;
using System.Collections;

public class ExploreCanvasScript : MonoBehaviour {
	
	void Start () {
		CanvasChanger.EXPLORE_CANVAS = gameObject;
		gameObject.SetActive(true);
	}
}

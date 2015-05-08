using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjectPicturesFetchScript : MonoBehaviour {

	public static List<Sprite> sprites = new List<Sprite>();
	
	public static int currentPosition = 0;
	
	void Update() {
		gameObject.GetComponent<Image>().sprite = sprites[currentPosition];
	}
	
	public void showNext() {
		if (currentPosition == sprites.Count - 1) {
			return;
		}
		
		currentPosition++;
	}
	
	public void showPrevious() {
		if (currentPosition == 0) {
			return;
		}
		
		currentPosition--;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ObjectGalleryLoader : MonoBehaviour {

	private Button pictureGalleryButton;
	private Image buttonBackgroundImage;
	
	public static List<Sprite> sprites = new List<Sprite>();
	
	private FileInfo[] info;
	
	private int deltaY;
	
	void Start () {
		pictureGalleryButton = (Instantiate(Resources.Load("PictureGalleryButton")) as GameObject).GetComponent<Button>();
		buttonBackgroundImage = (Instantiate(Resources.Load("ButtonBackgroundImage")) as GameObject).GetComponent<Image>();
		
		Sprite[] tmpSprites = Resources.LoadAll<Sprite>("");
		
		deltaY = Mathf.Max(0, ((sprites.Count - 1) / 3) * 357 - 1388);
		
		gameObject.transform.GetComponentInParent<RectTransform>().sizeDelta = new Vector2(0, deltaY);
		gameObject.transform.GetComponentInParent<RectTransform>().anchoredPosition = new Vector2(0, gameObject.transform.GetComponentInParent<RectTransform>().anchoredPosition.y - deltaY / 2);

		for (int i = 0; i < tmpSprites.Length; i++) {
			sprites.Add(tmpSprites[i]);
			generateButton(sprites[i], i);
		}
	}
	
	private void generateButton(Sprite Sprite, int position) {
		Image buttonBackground = Image.Instantiate(buttonBackgroundImage);
		buttonBackground.rectTransform.SetParent(gameObject.transform, false);
		buttonBackground.rectTransform.anchorMin = new Vector2(0, 1);
		buttonBackground.rectTransform.anchorMax = new Vector2(0, 1);
		buttonBackground.transform.position = new Vector3(getX(position), getY(position), 0);
		Button newButton = Button.Instantiate(pictureGalleryButton);
		newButton.transform.SetParent(gameObject.transform, false);
		newButton.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
		newButton.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
		newButton.transform.position = new Vector3(getX(position), getY(position), 0);
		newButton.image.sprite = sprites[position];
		AddHandler(newButton, position);
	}
	
	private void AddHandler(Button button, int position) {
		button.onClick.AddListener(() => OnClickMethod(position));
	}
	
	private void OnClickMethod(int position) {
		ObjectPicturesFetchScript.currentPosition = position;
		CanvasChanger.allObjectsToObjectGallery();
	}
	
	private int getX(int position) {
		return (position % 3) * 357 + 183;
	}
	
	private int getY(int position) {
		return (position / 3) * (-357) - 183 + 1754;
	}
}

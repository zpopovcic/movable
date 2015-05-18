using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class PictureGalleryLoader : MonoBehaviour {

	private Button pictureGalleryButton;
	private Image buttonBackgroundImage;

	private static string folderPath = Application.persistentDataPath;
	
	public static List<Sprite> sprites = new List<Sprite>();

	private int oldDeltaY = 0;

	void Start () {
		pictureGalleryButton = (Instantiate(Resources.Load("PictureGalleryButton")) as GameObject).GetComponent<Button>();
		buttonBackgroundImage = (Instantiate(Resources.Load("ButtonBackgroundImage")) as GameObject).GetComponent<Image>();

		DirectoryInfo dir = new DirectoryInfo(folderPath);
		FileInfo[] info = dir.GetFiles("*.*");

		foreach(FileInfo fileInfo in info) {
			addNewSprite(fileInfo.Name);
		}
	}

	public void addNewSprite(string filename) {
		WWW www = new WWW("file://" + folderPath + Path.DirectorySeparatorChar + filename);
		Texture2D texture2d = new Texture2D(1080, 1920);
		www.LoadImageIntoTexture(texture2d);
		sprites.Add(Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), new Vector2(0.5f, 0.5f)));
		generateButton(sprites[sprites.Count - 1], sprites.Count - 1);
		resizePanel();
	}

	private void resizePanel() {
		int newDeltaY = Mathf.Max(0, ((sprites.Count - 1) / 3) * 357 - 1388);

		if (newDeltaY > oldDeltaY) {
			int deltaY = newDeltaY - oldDeltaY;
			gameObject.transform.GetComponentInParent<RectTransform>().sizeDelta = new Vector2(0, deltaY);
			gameObject.transform.GetComponentInParent<RectTransform>().anchoredPosition = new Vector2(0, gameObject.transform.GetComponentInParent<RectTransform>().anchoredPosition.y - deltaY / 2);
			oldDeltaY = newDeltaY;
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
		newButton.image.sprite = Sprite.Create(sprites[position].texture, new Rect(0, 420, 1080, 1080), new Vector2(0.5f,0.5f), 1.0f);
		AddHandler(newButton, position);
	}

	private void AddHandler(Button button, int position) {
		button.onClick.AddListener(() => OnClickMethod(position));
	}

	private void OnClickMethod(int position) {
		ScreenshotsFetchScript.currentPosition = position;
		CanvasChanger.allPicturesToPictureGallery();
	}

	private int getX(int position) {
		return (position % 3) * 357 + 183;
	}

	private int getY(int position) {
		return (position / 3) * (-357) - 183 + 1754;
	}

}

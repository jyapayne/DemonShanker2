using UnityEngine;
using System.Collections;

public class StartHandler : MonoBehaviour {

	public Texture normalButton;
	public Texture hoverButton;
	public GUITexture guiButton;

	void OnMouseEnter() {
		guiButton.texture = hoverButton;
	}

	void OnMouseExit() {
		guiButton.texture = normalButton;
	}

	void OnMouseDown() {
		Application.LoadLevel ("Main");
	}
}

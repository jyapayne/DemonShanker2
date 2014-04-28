using UnityEngine;
using System.Collections;

public class StartHandler : MonoBehaviour {

	public Sprite normalButton;
	public Sprite hoverButton;

	void OnMouseEnter() {
		guiTexture.texture = hoverButton.texture;
	}

	void OnMouseExit() {
		guiTexture.texture = normalButton.texture;
	}

	void OnMouseDown() {
		Application.LoadLevel ("Main");
	}
	
}

using UnityEngine;
using System.Collections;

public class StartHandler : MonoBehaviour {

	public Texture normalButton;
	public Texture hoverButton;

	void OnMouseEnter() {
		guiTexture.texture = hoverButton;
	}

	void OnMouseExit() {
		guiTexture.texture = normalButton;
	}

	void OnMouseDown() {
		Application.LoadLevel ("Main");
	}
}

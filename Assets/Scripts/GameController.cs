using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int swigs;
	public GUIText swigText;

	// Use this for initialization
	void Start () {
		UpdateSwigText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeSwig() {
		swigs -= 1;
		UpdateSwigText();
	}

	void UpdateSwigText() {
		swigText.text = "Swigs Left: " + swigs;
	}
}

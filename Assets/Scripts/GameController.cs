using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int swigs;
	public GUIText swigText;
	public GUIText scoreText;

	private int score = 0;

	// Use this for initialization
	void Start () {
		UpdateSwigText ();
		UpdateScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeSwig() {
		swigs -= 1;
		UpdateSwigText();
	}

	public void AddScore() {
		score += 100;
		UpdateScoreText ();
	}

	public void DetractScore() {
		score -= 150;
		UpdateScoreText ();
	}

	void UpdateSwigText() {
		swigText.text = "Swigs Left: " + swigs;
	}

	void UpdateScoreText() {
		scoreText.text = "Score: " + score;
	}
}

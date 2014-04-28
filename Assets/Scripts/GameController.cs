using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int swigs;
	public GUIText swigText;
	public GUIText scoreText;
	public int maxPatrons;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject[] patronObjects;

	public GUIText shankYouText;
	public GUIText gameOverText;
	public GUIText restartText;

	private int score = 0;
	private int patronCounter = 0;
	private bool restart;
	private int maxSwigs;

	// Use this for initialization
	void Start () {
		maxSwigs = swigs;

		restart = false;

		UpdateSwigText ();
		UpdateScoreText ();

		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		
		while (true)
		{
			if (patronCounter < maxPatrons)
			{
				Vector3 spawnPosition = new Vector3 (20f, 3f, 9f);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (patronObjects[Random.Range (0, patronObjects.Length)], spawnPosition, spawnRotation);

				patronCounter++;
				
				yield return new WaitForSeconds (spawnWait);
			}
			
			yield return new WaitForSeconds (waveWait);

			if (swigs == 0)
			{
				yield return new WaitForSeconds (5);

				shankYouText.enabled = true;
				gameOverText.enabled = true;
				restartText.enabled = true;

				restart = true;

				GameObject.FindGameObjectWithTag ("Player").SetActive (false);

				break;
			}
		}
	}

	public void TakeSwig() {
		swigs -= 1;
		UpdateSwigText();
	}

	public void AddScore() {
		score += 100;
		UpdateScoreText ();
		patronCounter--;
	}

	public void DetractScore() {
		score -= 150;
		UpdateScoreText ();
		patronCounter--;
	}

	void UpdateSwigText() {
		swigText.text = "Swigs Left: " + swigs + " / " + maxSwigs;
	}

	void UpdateScoreText() {
		scoreText.text = "Score: " + score;
	}
}

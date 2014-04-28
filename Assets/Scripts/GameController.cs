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

	private int score = 0;
	private int patronCounter = 0;

	// Use this for initialization
	void Start () {
		UpdateSwigText ();
		UpdateScoreText ();

		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
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
		swigText.text = "Swigs Left: " + swigs;
	}

	void UpdateScoreText() {
		scoreText.text = "Score: " + score;
	}
}

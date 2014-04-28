using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int swigs;
	public GUIText swigText;
	public GUIText scoreText;
	public int patronCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject[] patron;

	private int score = 0;
	private int patrons = 0;

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
			if (patrons < patronCount)
			{
				Vector3 spawnPosition = new Vector3 (40f, 2.5f, 10f);
				Quaternion spawnRotation = Quaternion.identity;

				GameObject patron = Instantiate (patron[Random.Range (0, patron.Length)], spawnPosition, spawnRotation);

				patrons++;
				
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

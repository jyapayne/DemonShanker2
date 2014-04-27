using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {

	private GameController gameController;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController> ();
		else
			Debug.Log("Cannot find GameController script.");
	}

	void OnTriggerEnter(Collider other) {
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
			gameController.DetractScore ();
		}
	}
}

using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {
	public Renderer characterSprite;

	private GameController gameController;
	private bool isDemon = false;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController> ();
		else
			Debug.Log("Cannot find GameController script.");

		if (Random.value > 0.6)
			isDemon = true;
	}

	void OnTriggerEnter(Collider other) {
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
			if(isDemon)
				gameController.AddScore ();
			else
				gameController.DetractScore ();
		}

		if (other.tag == "VVAura" && isDemon) {
			characterSprite.renderer.material.color = Color.red;
		}
	}
}

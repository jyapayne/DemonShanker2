using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {
	public Renderer characterSprite;
	public Renderer demonHead;
	public AudioClip demonDeath;
	public AudioClip patronDeath;

	private GameController gameController;
	private bool isDemon = false;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController> ();
		else
			Debug.Log("Cannot find GameController script.");

		if (Random.value > 0.6 && gameController.currentNumberOfDemons < (gameController.maxPatrons / 4)) {
			isDemon = true;
			gameController.currentNumberOfDemons++;
		}
	}

	void OnTriggerEnter(Collider other) {
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			if(isDemon) {
				AudioSource.PlayClipAtPoint (demonDeath, gameObject.rigidbody.position);
				gameController.AddScore ();
			}
			else {
				AudioSource.PlayClipAtPoint (patronDeath, gameObject.rigidbody.position);
				gameController.DetractScore ();
			}

			Destroy(gameObject);
		}

		if (other.tag == "VVAura" && isDemon) {
			characterSprite.renderer.material.color = Color.red;
			demonHead.renderer.enabled = true;
		}
	}
}

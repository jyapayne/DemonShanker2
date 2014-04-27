using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour {

	public Renderer characterSprite;

	void OnTriggerEnter(Collider other) {
		
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
		}
		
		if (other.tag == "VVAura") {
			characterSprite.renderer.material.color = Color.red;
		}
	}
}

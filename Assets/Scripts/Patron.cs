using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {

    Vector3 dest;

    void Awake() {
        Vector3 pos = GameObject.Find("node3").transform.position;
        NavMeshAgent nva = GetComponent<NavMeshAgent>();
        nva.SetDestination(pos);
        nva.updateRotation = false;
    }

	void OnTriggerEnter(Collider other) {

		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
		}
		
//		gameController.AddScore (scoreValue);
//		
//		Destroy (other.gameObject);
//		Destroy (gameObject);
	}
}

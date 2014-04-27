using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {

    public GameObject[] destinations;
    public int currentDestIndex = 0;
	public Material evilMat;
	public Material neutralMat;

    private NavMeshAgent nva;

    void Awake() {
        nva = GetComponent<NavMeshAgent>();
        nva.updateRotation = false;
        nva.SetDestination(destinations[currentDestIndex].transform.position);
    }

    public void NextDest() {
        if(currentDestIndex + 1 < destinations.Length)
            ++currentDestIndex;
        else
            currentDestIndex = 0;

        nva.SetDestination(destinations[currentDestIndex].transform.position);
    }

	void OnTriggerEnter(Collider other) {

		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
		}

		if (other.tag == "VVAura") {
			renderer.material = evilMat;
		}
		
//		gameController.AddScore (scoreValue);
//		
//		Destroy (other.gameObject);
//		Destroy (gameObject);
	}
}

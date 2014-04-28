using UnityEngine;
using System.Collections;

public class WalkAI : MonoBehaviour {

	private GameObject[] destinations;
	public int currentDestIndex = 0;
	
	private NavMeshAgent nva;
	
	void Awake() {

		GameObject[] allPois = GameObject.FindGameObjectsWithTag("pois");

		GameObject poi1 = allPois[Random.Range (0, allPois.Length)];
		GameObject poi2 = allPois[Random.Range (0, allPois.Length)];

		destinations = new GameObject[2] {
			poi1,
			poi2
		};

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
}

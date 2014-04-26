using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour {

    Vector3 dest;

    void Awake() {
        Vector3 pos = GameObject.Find("node3").transform.position;
        NavMeshAgent nva = GetComponent<NavMeshAgent>();
        nva.SetDestination(pos);
        nva.updateRotation = false;
    }
}

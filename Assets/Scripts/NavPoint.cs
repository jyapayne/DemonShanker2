using UnityEngine;
using System.Collections;

public class NavPoint : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        WalkAI p = other.gameObject.GetComponent<WalkAI>();
        if(p != null)
            p.NextDest();
    }
}

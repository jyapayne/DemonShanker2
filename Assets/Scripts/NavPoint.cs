using UnityEngine;
using System.Collections;

public class NavPoint : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        Patron p = other.gameObject.GetComponent<Patron>();
        if(p != null)
            p.NextDest();
    }
}

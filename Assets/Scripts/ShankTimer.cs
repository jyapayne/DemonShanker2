using UnityEngine;
using System.Collections;

public class ShankTimer : MonoBehaviour {

	private float timer;
	public float length;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > length)
			GameObject.Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	void Update() {

	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.MovePosition (rigidbody.position + movement * speed * Time.deltaTime);

		rigidbody.freezeRotation = true;
	}
}

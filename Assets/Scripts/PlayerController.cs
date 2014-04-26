using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float nextFire;
	public float fireRate;
	public GameObject shank;
	public Transform shankSpawn;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shank, shankSpawn.position, rigidbody.rotation);
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal < 0)
			transform.eulerAngles = new Vector3(0f, -180f, 0f);
		else if (moveHorizontal > 0)//			transform.RotateAround(Vector3.zero, Vector3.up, 0f);
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
		else if (moveVertical < 0)
			transform.eulerAngles = new Vector3(0f, -270f, 0f);
		else if (moveVertical > 0)
			transform.eulerAngles = new Vector3(0f, -90f, 0f);

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.MovePosition (rigidbody.position + movement * speed * Time.deltaTime);

		rigidbody.freezeRotation = true;
		rigidbody.position.Normalize ();
	}

	void Shank(){

	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float nextFire;
	public float delay;
	public GameObject shank;
	public Transform playerAngle;
	public Transform shankSpawn;
	public GameObject vvAura;
	public int swigCounter;
	private int swigs = 0;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			//audio.Play ();
			nextFire = Time.time + delay;
			Instantiate(shank, shankSpawn.position, playerAngle.rotation);
		}

		if (Input.GetButton("ActivateVV") && swigs < swigCounter && Time.time > nextFire)
		{
			nextFire = Time.time + delay * 2;
			Instantiate (vvAura, rigidbody.position, rigidbody.rotation);
			swigs++;
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal < 0)
			playerAngle.eulerAngles = new Vector3(0f, -180f, 0f);
		else if (moveHorizontal > 0)
			playerAngle.eulerAngles = new Vector3(0f, 0f, 0f);
		else if (moveVertical < 0)
			playerAngle.eulerAngles = new Vector3(0f, -270f, 0f);
		else if (moveVertical > 0)
			playerAngle.eulerAngles = new Vector3(0f, -90f, 0f);

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.MovePosition (rigidbody.position + movement * speed * Time.deltaTime);

		rigidbody.freezeRotation = true;
		rigidbody.position.Normalize ();
	}
}

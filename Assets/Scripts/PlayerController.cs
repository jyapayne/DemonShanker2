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

    private Animator animator;

    void Awake()
    {
        animator = GameObject.Find("PlayerSprite").GetComponent<Animator>();
    }

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			//audio.Play ();
			nextFire = Time.time + delay;
			Instantiate(shank, shankSpawn.position, playerAngle.rotation);
            //animator.SetInteger("state", 3);
            animator.Play("player_shank");
		}

		if (Input.GetButton("ActivateVV") && swigs < swigCounter && Time.time > nextFire)
		{
			nextFire = Time.time + delay * 2;
			Instantiate (vvAura, rigidbody.position, rigidbody.rotation);
			swigs++;
            //animator.SetInteger("state", 1);
            animator.Play("player_swig");
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        if (Mathf.Approximately(moveHorizontal, 0) &&
            Mathf.Approximately(moveVertical, 0)) {
            //animator.SetInteger("state", 0);
            //animator.Play("player_idle");
        } else {
            //animator.SetInteger("state", 2);
            animator.Play("player_walk");
        }

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

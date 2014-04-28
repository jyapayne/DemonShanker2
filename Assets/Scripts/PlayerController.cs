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
	private GameController gameController;
	public GameObject playerSprite;

	enum Direction {Left, Right};

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController> ();
		else
			Debug.Log("Cannot find GameController script.");
	}

    private Animator animator;

    void Awake()
    {
        animator = GameObject.Find("PlayerSprite").GetComponent<Animator>();
    }

	void MakePlayerSpriteFace(Direction dir)
	{
		Vector3 scaleVec = playerSprite.transform.localScale;
		if (dir == Direction.Left) {
			scaleVec.x = -1;
		} else if (dir == Direction.Right) {
			scaleVec.x = 1;
		}
		playerSprite.transform.localScale = scaleVec;
	}

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + delay;
			Instantiate(shank, shankSpawn.position, playerAngle.rotation);
			shankSpawn.audio.Play ();
            animator.Play("player_shank");
		}

		if (Input.GetButton("ActivateVV") && gameController.swigs > 0 && Time.time > nextFire)
		{
			nextFire = Time.time + delay * 2;
			Instantiate (vvAura, rigidbody.position, rigidbody.rotation);
			gameController.TakeSwig();
            animator.Play("player_swig");
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveVertical > 0){ // Walking up
			animator.SetBool("isWalkingUp", true);
			animator.SetBool("isWalking", false);
		}
		else if (!Mathf.Approximately (moveHorizontal, 0) || moveVertical < 0) { // walking sideways
			animator.SetBool("isWalking", true);
			animator.SetBool("isWalkingUp", false);
		}
		else {
			animator.SetBool("isWalking", false);
			animator.SetBool("isWalkingUp", false);
		}

		if (moveHorizontal < 0 && moveVertical > 0) { // left up
			playerAngle.eulerAngles = new Vector3(0f, -135, 0f);
			MakePlayerSpriteFace(Direction.Left);
		}
		else if (moveHorizontal < 0 && moveVertical < 0) {// left down
			playerAngle.eulerAngles = new Vector3(0f, -225f, 0f);
			MakePlayerSpriteFace(Direction.Left);
		}
		else if (moveHorizontal > 0 && moveVertical > 0) {//right up
			playerAngle.eulerAngles = new Vector3(0f, -45f, 0f);
			MakePlayerSpriteFace(Direction.Right);
		}
		else if (moveHorizontal > 0 && moveVertical < 0) {//right down
			playerAngle.eulerAngles = new Vector3(0f, 45f, 0f);
			MakePlayerSpriteFace(Direction.Right);
		}
		else if (moveHorizontal < 0)	{ // Stab left
			playerAngle.eulerAngles = new Vector3(0f, -180f, 0f);
			MakePlayerSpriteFace(Direction.Left);
		}
		else if (moveHorizontal > 0) { // Stab right
			playerAngle.eulerAngles = new Vector3 (0f, 0f, 0f);
			MakePlayerSpriteFace(Direction.Right);
		}
		else if (moveVertical < 0) // Stab down
			playerAngle.eulerAngles = new Vector3(0f, -270f, 0f);
		else if (moveVertical > 0) // Stab up
			playerAngle.eulerAngles = new Vector3(0f, -90f, 0f);

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.freezeRotation = true;
	}
}

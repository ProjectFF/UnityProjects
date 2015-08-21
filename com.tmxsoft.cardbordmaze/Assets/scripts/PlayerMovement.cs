using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator anim;
	private PlayerHash hash;
	public float speedDampTime = 1.6f;
	public float turnSmoothing = 25f;
	public float runspeed = 5.0f;
	private Rigidbody rigidbody;
	public int speedHash;
	public float v;
	public float h;


	// Use this for initialization
	void Awake(){
	
		anim = GetComponent<Animator>();
		hash = new PlayerHash();
		rigidbody = GetComponent<Rigidbody> ();
		speedHash = Animator.StringToHash ("Speed");
		anim.SetFloat ("Speed", 0);
	}

	void FixedUpdate(){
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		MovementManagement(h, v);
	}

	void MovementManagement(float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		// If there is some axis input...
		if(horizontal != 0f)
		{
			Rotating(horizontal, vertical);
			transform.Translate(Vector3.forward * runspeed * Time.deltaTime);
			anim.SetBool ("Run", true);
			anim.SetFloat("Speed", 2);
		}
		else if(vertical > 0f )
		{
			anim.SetBool("Run", true);
			transform.Translate(Vector3.forward * runspeed * Time.deltaTime);
			anim.SetFloat("Speed", 2);
		}	
		else if(vertical < 0f )
		{
			transform.Translate(Vector3.back * runspeed * Time.deltaTime);
			anim.SetBool("RunBack", true);
			anim.SetFloat("Speed", 2);
		} else {
			anim.SetBool("Run", false);
			anim.SetBool("RunBack", false);
			anim.SetFloat("Speed", 0);
		}
	}
	
	
	void Rotating (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		rigidbody.MoveRotation(newRotation);
	}


	void AudioManagement(bool run)
	{

	}

	void Update ()
	{
		bool jump = Input.GetButton("Jump");
		bool hit = Input.GetButton("Hit");
		bool roll = Input.GetButton("Roll");
		bool crawl = Input.GetButton("Crawl");


		if (hit) anim.SetBool ("Hit", true );
		else anim.SetBool ("Hit", false );
		if (jump) anim.SetBool ("Jump", true );
		else anim.SetBool ("Jump", false );
		if (roll) anim.SetBool ("Roll", true );
		else anim.SetBool ("Roll", false );
		if (roll) anim.SetBool ("Crawl", true );
		else anim.SetBool ("Crawl", false );

	
	}

}

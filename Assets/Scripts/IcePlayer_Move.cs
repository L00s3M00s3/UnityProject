using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlayer_Move : PlayerMovement {
	float max_Speed = 5f;
	bool direction;
	AudioSource audio;

	void Start()
	{
		 audio = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void FixedUpdate () {
		//Player_Direction();
		PlayerControl();


		if (rbody.velocity.magnitude > max_Speed)
		{
			rbody.velocity = rbody.velocity.normalized * max_Speed;
		}

	}

	public override void PlayerControl()
	{
		if (!GetComponent<Ice_Detection>().IceDetection&&!direction)
		{

			Horizontal = Input.GetAxisRaw("Horizontal");
			Vertical = Input.GetAxisRaw("Vertical");
			orient();


			movement_vector = new Vector2(Horizontal, Vertical);
			//aniamte movements
			if (movement_vector != Vector2.zero)
			{ //if there is an input command
				anim.SetBool("isWalking", true); //declare player as moving
				anim.SetFloat("Input_x", movement_vector.x); //tell animator the value of vector.x
				anim.SetFloat("Input_y", movement_vector.y); //tell animator the value of vector.y
			}
			else { //if there is no movement input, tell animator that the player is not moving.
				anim.SetBool("isWalking", false);
			}


			rbody.velocity = !iscleaning ? movement_vector * speed : Vector2.zero;
			//update rbody position


		}
		else
		{
			SlideMovement();
		}
	}

	void Player_Direction()
	{

		RaycastHit2D hit = Physics2D.Raycast(orientation.transform.position, transform.up, 7f, 1 << LayerMask.NameToLayer("Object"));
		if (hit.collider != null)
		{
			rbody.velocity = Vector2.zero;
			direction = true;
			GetComponent<Ice_Detection>().IceDetection = false;
			Debug.Log("Hit Ray");
		}



	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		movement_vector = Vector2.zero;
		if (GetComponent<Ice_Detection>().OnIce)
		{
			audio.Play ();
			if (!direction)
			{

				GetComponent<Ice_Detection>().IceDetection = false;
				direction = true;

			}
			Debug.Log(direction);
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (GetComponent<Ice_Detection>().OnIce)
		{
			movement_vector = Vector2.zero;

			if (!direction)
			{
				GetComponent<Ice_Detection>().IceDetection = true;

				if (rbody.velocity.magnitude <= 0) {
					direction = true;
				}
			}
		}
	}


	void OnCollisionExit2D(Collision2D collision)
	{
		if (GetComponent<Ice_Detection>().OnIce)
		{
			GetComponent<Ice_Detection>().IceDetection = true;
			direction = false;
			Debug.Log("Leave");
		}
	}
	void SlideMovement()
	{
		anim.SetBool("isWalking", false);
		if (direction)
		{
			if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
			{

				rbody.velocity = Vector2.up * max_Speed;
				anim.SetFloat("Input_x", Vector2.up.x);
				anim.SetFloat("Input_y", Vector2.up.y);
				direction = false;
			}
			if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				rbody.velocity = Vector2.left * max_Speed;
				anim.SetFloat("Input_x", Vector2.left.x);
				anim.SetFloat("Input_y", Vector2.left.y);
				direction = false;
			}
			if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				rbody.velocity = Vector2.down * max_Speed;
				anim.SetFloat("Input_x", Vector2.down.x);
				anim.SetFloat("Input_y", Vector2.down.y);
				direction = false;
			}
			if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				rbody.velocity = Vector2.right * max_Speed;
				anim.SetFloat("Input_x", Vector2.right.x);
				anim.SetFloat("Input_y", Vector2.right.y);
				direction = false;
			}
		}
	}
}
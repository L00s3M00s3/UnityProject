using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Animator anim;
	Rigidbody2D rbody;

	public float speed; //determines speed of player character
	public bool isDead; //determines whether player is dead
    private float Horizontal, Vertical;
    public float combine;

    public Transform orientation;


	private float currentSpeed;


	// Use this for initialization
	void Awake () {
	
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Input_y", -1);
	
		currentSpeed = speed;
        


	}
	
	// Update is called once per frame
	void Update () {

        combine = Horizontal + Vertical;
	


		if (GetComponent<Player_Contact> ().canBeHit) {

			//WASDmovement ();
			Horizontal = Input.GetAxisRaw ("Horizontal");
			Vertical = Input.GetAxisRaw ("Vertical");
		

			Vector2 movement_vector = new Vector2 (Horizontal, Vertical);
			//aniamte movements
			if (movement_vector != Vector2.zero) { //if there is an input command
				anim.SetBool ("isWalking", true); //declare player as moving
				anim.SetFloat ("Input_x", movement_vector.x); //tell animator the value of vector.x
				anim.SetFloat ("Input_y", movement_vector.y); //tell animator the value of vector.y
			} else { //if there is no movement input, tell animator that the player is not moving.
				anim.SetBool ("isWalking", false);
			}


			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * currentSpeed);
			//update rbody position
     

		}
			
	}

	}
			





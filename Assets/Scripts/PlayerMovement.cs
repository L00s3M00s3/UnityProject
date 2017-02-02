using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rbody;

	public float speed; //determines speed of player character
	public bool isDead; //determines whether player is dead
    [HideInInspector]
    public float Horizontal, Vertical;
    public float combine;
    public bool issafe, iscleaning;
    public bool canMove = true;
    
    public Transform orientation;
    [HideInInspector]
    public Vector2 movement_vector;






	// Use this for initialization
	void Awake () {
        GameController.goal = false;
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Input_y", -1);
	
		
        


	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
		orient ();
        combine = Horizontal + Vertical;


        
           PlayerControl();

		if (!issafe && LightFlicker.dark) {
            isDead = true;
			Debug.Log ("Dead");
		}
        else
        {
            isDead = false;
        }
	}


	public virtual void PlayerControl () {

        if (!canMove)
        {
            return;
        }

		Horizontal = Input.GetAxisRaw ("Horizontal");
		Vertical = Input.GetAxisRaw ("Vertical");


		movement_vector = new Vector2 (Horizontal, Vertical);
		//aniamte movements
		if (movement_vector != Vector2.zero) { //if there is an input command
			anim.SetBool ("isWalking", true); //declare player as moving
			anim.SetFloat ("Input_x", movement_vector.x); //tell animator the value of vector.x
			anim.SetFloat ("Input_y", movement_vector.y); //tell animator the value of vector.y
		} else { //if there is no movement input, tell animator that the player is not moving.
			anim.SetBool ("isWalking", false);
		}

            rbody.velocity = !iscleaning ? movement_vector * speed : Vector2.zero;
            //update rbody position
        
	}

	public void orient()
	{
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{

			orientation.rotation = Quaternion.identity;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			orientation.rotation = Quaternion.Euler (transform.forward * 90);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
		
			orientation.rotation = Quaternion.Euler (transform.forward * 180);
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			orientation.rotation = Quaternion.Euler (transform.forward * 270);
		}

	}


			

}





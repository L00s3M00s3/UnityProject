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
    public bool issafe;

    public Transform orientation;


	private float currentSpeed;


	// Use this for initialization
	void Awake () {
        issafe = true;
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Input_y", -1);
	
		currentSpeed = speed;
        


	}
	
	// Update is called once per frame
	void Update () {

        orient();

        combine = Horizontal + Vertical;

		if (GetComponent<Player_Contact> ().canBeHit) {
            PlayerControl();
		}

        if (!issafe && LightFlicker.dark)
        {
            Debug.Log("Dead");
        }
			
	}

    void orient()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            orientation.rotation = Quaternion.identity;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            orientation.rotation = Quaternion.Euler(transform.forward * 90);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            orientation.rotation = Quaternion.Euler(transform.forward * 180);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            orientation.rotation = Quaternion.Euler(transform.forward * 270);
        }
    }

    void PlayerControl()
    {
        
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");


        Vector2 movement_vector = new Vector2(Horizontal, Vertical);
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


        
        rbody.velocity = movement_vector*speed;
        //update rbody position
    }


    
}
			





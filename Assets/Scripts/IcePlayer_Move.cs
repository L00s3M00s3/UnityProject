using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlayer_Move : PlayerMovement {
    float max_Speed = 5f;
	// Update is called once per frame
	void FixedUpdate () {
        PlayerControl();
        if (rbody.velocity.magnitude > max_Speed)
        {
            rbody.velocity = rbody.velocity.normalized * max_Speed;
        }
	}

    public override void PlayerControl()
    {
        if (!GetComponent<Ice_Detection>().IceDetection)
        {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");


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
            rbody.AddForce(movement_vector * speed,ForceMode2D.Force);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        
        GetComponent<Ice_Detection>().IceDetection = false;
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Ice_Detection>().IceDetection = true;
    }
}

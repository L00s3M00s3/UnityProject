using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebWalk : PlayerMovement
{

    

    void FixedUpdate()
    {
        PlayerControl();
    }


    public override void PlayerControl()
    {

        if (speed > 0)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            orient();
            Debug.Log(speed);

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
            StartCoroutine(SlowDown(rbody.velocity.magnitude, GetComponent<Ice_Detection>().OnIce));

            //update rbody position
        }
        else
        {
            Debug.Log("Spider Gun Get You");
            /*Here is where you would put the respawn trigger*/
        }

        
    }

    IEnumerator SlowDown(float playerSpeed,bool sticky)
    {
        if (playerSpeed > 0 && sticky&&speed>0)
        {
            speed -= 0.01f;
            yield return new WaitForSeconds(1.0f);
        }
    }
}

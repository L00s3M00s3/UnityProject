using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlayer_Move : PlayerMovement {
    float max_Speed = 5f;
    bool direction;
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
        
            if (!direction)
            {
                GetComponent<Ice_Detection>().IceDetection = false;
                direction = true;
                movement_vector = Vector2.zero;
            }
            Debug.Log(direction);
        
    }



    void OnCollisionExit2D(Collision2D collision)
    {
        
            GetComponent<Ice_Detection>().IceDetection = true;
           direction = false;
        
    
        Debug.Log("Leave");
    }
    void SlideMovement()
    {
        if (direction)
        {
            if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
            {
                rbody.velocity = Vector2.up * 20f;
                direction = false;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rbody.AddForce(Vector2.left * 20f, ForceMode2D.Force);
                direction = false;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                rbody.AddForce(Vector2.down * 20f, ForceMode2D.Force);
                direction = false;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                rbody.AddForce(Vector2.right * 20f, ForceMode2D.Force);
                direction = false;
            }
        }
    }
}

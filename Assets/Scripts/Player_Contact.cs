using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Contact : MonoBehaviour {
    public PlayerMovement playermovement;
    public Adapted_Shooting playershooting;


    Transform spawn;

	public Animator anim;
	public bool canBeHit;


    void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
        playershooting = GetComponent<Adapted_Shooting>();
		anim = GetComponent<Animator>();
		canBeHit = true;
        spawn = GameObject.FindGameObjectWithTag("Respawn").transform;

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        { //if touched by either enemy bullet or enemy, reduce lives

			if (canBeHit) {
				
				canBeHit = false;

				GetComponent<Rigidbody2D> ().isKinematic = true;
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			
			//PlayerMovement.Lives--;



			anim.SetTrigger ("Die");


			
		
            //play hurt sound
			}
        }


    }

    void OnTriggerEnter2D(Collider2D other) //if entering trigger zone
    {
        /*
        if (other.tag == "HealthUp")
        { //if health item

            PlayerMovement.Lives++;  //increase number of lives
			other.gameObject.SetActive(false); //destroy the pick up item
			AudioSource.PlayClipAtPoint(PickUpItem, transform.position);
        }
        */
     

	
       /* if (other.tag == "EnemyBullet")
        {
            if (canBeHit)
            {

                canBeHit = false;

                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //AddTime(extraTime);
                //PlayerMovement.Lives--;


           
                anim.SetTrigger("Die");




                //play hurt sound
            }
        }*/
    }


	public void Respawn()
	{
		gameObject.transform.position = spawn.position;
		StartCoroutine ("Flash");

	}

	IEnumerator Flash()
	{
		
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.2f);

		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.2f);

		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.2f);

		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.2f);

		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.2f);


		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.2f);

		canBeHit = true;
		GetComponent<Rigidbody2D> ().isKinematic = false;

	}

}

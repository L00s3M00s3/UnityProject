using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Contact : MonoBehaviour {
    public PlayerMovement playermovement;
    public PlayerShooting playershooting;


    //Transform spawn;

	public Animator anim;
	public bool canBeHit;


    void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
        playershooting = GetComponent<PlayerShooting>();
		anim = GetComponent<Animator>();
		canBeHit = true;
        //spawn = GameObject.FindGameObjectWithTag("Respawn").transform;

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        { //if touched by either enemy bullet or enemy, reduce lives

			if (canBeHit) {
				
				canBeHit = false;

				//GetComponent<Rigidbody2D> ().isKinematic = true;
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			
			//PlayerMovement.Lives--;



			anim.SetTrigger ("Die");


			
		
            //play hurt sound
			}
        }


    }

  


	public void Respawn()
	{
		//gameObject.transform.position = spawn.position;
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

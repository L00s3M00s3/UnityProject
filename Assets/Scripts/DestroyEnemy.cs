using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour{


    public static int deadenemies;
	public GameObject splatter;

	//flash colour
	public float flash = 5f;
	public bool damaged;
	public SpriteRenderer Sprite;
	public Color flashColour = new Color(1f, 1f, 1f, 1f);


	//Health
	public float MaxHP;
	public float CurrentHP;


	void Awake()
	{
		splatter.GetComponent<Splat2D> ();
        damaged = false;
	}

	void Update()
	{

		if (damaged) {
		
			Sprite.color = flashColour;
		} else {
		
			Sprite.color = Color.Lerp (Sprite.color, Color.white, flash * Time.deltaTime);
		}
		damaged = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
       
            if (other.tag == "Bullet")
            {

                CurrentHP -= 1;
                other.gameObject.SetActive(false);
                damaged = true;
                //flash white

                if (CurrentHP < 0)
                {
                    deadenemies++;
                    CurrentHP = MaxHP;

                    this.gameObject.SetActive(false);
                    other.gameObject.SetActive(false); 

                    Instantiate(splatter, new Vector2(transform.position.x, transform.position.y), transform.rotation);

                }
            
		} else {
		
			damaged = false;
		
		}


	}

	




}

    



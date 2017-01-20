using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour{


	ItemManager itemmanager;
	private float spawnLife = 5;
	private float spawnPower = 2;
	private float spawnSpeed = 5;
	private float spawnFire = 5;
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
		//itemmanager = GameObject.Find ("Item_Manager").GetComponent<ItemManager> ();
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

                    SpawnLife();
                    SpawnPower();
                    SpawnSpeed();
                    SpawnFire();
                deadenemies++;
                    CurrentHP = MaxHP;

                    this.gameObject.SetActive(false);
                    //other.gameObject.SetActive(false); //deactivate bullet

                    Instantiate(splatter, new Vector2(transform.position.x, transform.position.y), transform.rotation);

                }
            
		} else {
		
			damaged = false;
		
		}


	}

	void SpawnPower()
	{
	
		if (spawnPower > Random.Range (0.0f, 100f)) {
		
			//itemmanager.Activatepower(gameObject.transform);

		}
	}

	void SpawnLife()
	{
		if (spawnLife > Random.Range (0.0f, 100f)) {

			//itemmanager.ActivateLife (gameObject.transform);

		}

	}
	void SpawnSpeed()
	{
		if (spawnSpeed > Random.Range (0.0f, 100f)) {

			//itemmanager.ActivateSpeedUp (gameObject.transform);

		}

	}
	void SpawnFire()
	{
		if (spawnFire> Random.Range (0.0f, 100f)) {

			//itemmanager.ActivateFireUp (gameObject.transform);

		}

	}




}

    



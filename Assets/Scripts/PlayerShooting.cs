using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float fireRateCurrent;
	public float fireRateNormal;
	public float fireRateIncreased;
	public GameObject Forcefield;
	public int bulletlimit = 40;
	public bool isShooting;
	public bool isFiredUp;
	private float nextbullet;
	float countdown = 5.0f;
	public bool poweredup;
	public GameObject bulletPrefab;
	GameObject[] mybullets;
	public Transform[] bulletSpawn;
	string[] keys = { "up", "down", "left", "right" };

	public Animator anim;

	void Awake()
	{
		anim.GetComponent<Animator> ();
		mybullets = new GameObject[bulletlimit];

		for (int i = 0; i < bulletlimit; i++)
		{
			mybullets[i] = Instantiate(bulletPrefab) as GameObject;
			mybullets[i].SetActive(false);
		}

	}


	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (GetComponent<Player_Contact>().canBeHit)
		{
			if (!poweredup)
			{
				DiagonalShooting();
				DirectionalShooting();
			}
			if (poweredup)
			{
				AllShoot();
			}
			if (isFiredUp)
			{

				FireUp();
			}
		}

	}

	void DiagonalShooting()
	{

		if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)))
		{


			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[4].transform);

			}
		}
		if ((Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)))
		{

			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[5].transform);

			}
		}
		if ((Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)))
		{

			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[6].transform);

			}
		}
		if ((Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)))
		{

			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[7].transform);

			}
		}
	}

	void DirectionalShooting()
	{

		if (Input.GetKey(KeyCode.UpArrow))
		{

			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[0].transform);

				//anim.SetBool ("IsAttacking", true);
				anim.SetFloat ("Attack_Y", 1);

			}
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{

			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[1].transform);

				//anim.SetBool ("IsAttacking", true);
				anim.SetFloat ("Attack_X", 1);

			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{

			if (Time.time > nextbullet)
			{
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[2].transform);

				//anim.SetBool ("IsAttacking", true);
				anim.SetFloat ("Attack_Y", -1);

			}
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {

			if (Time.time > nextbullet) {
				nextbullet = Time.time + fireRateCurrent;
				BulletFire(bulletSpawn[3].transform);

				//anim.SetBool ("IsAttacking", true);
				anim.SetFloat ("Attack_X", -1);

			}
		} else {

			anim.SetBool ("IsAttacking", false);

		}
	}

	void AllShoot()
	{
		countdown -= Time.deltaTime;


		if (countdown <= 0)
		{
			poweredup = false;
			countdown = 5.0f;
			Forcefield.GetComponent<SpriteRenderer> ().enabled = false;
		}
		else
		{
			Forcefield.GetComponent<SpriteRenderer> ().enabled = true;
			foreach (string k in keys)
			{
				if(Input.GetKey(k))
				{
					if (Time.time > nextbullet)
					{

						nextbullet = Time.time + fireRateCurrent;

						BulletFire(bulletSpawn[0].transform);
						BulletFire(bulletSpawn[1].transform);
						BulletFire(bulletSpawn[2].transform);
						BulletFire(bulletSpawn[3].transform);
						BulletFire(bulletSpawn[4].transform);
						BulletFire(bulletSpawn[5].transform);
						BulletFire(bulletSpawn[6].transform);
						BulletFire(bulletSpawn[7].transform);



					}
				}
			}

		}
	}

	void FireUp()
	{

		countdown -= Time.deltaTime;
		if (countdown <= 0) {

			isFiredUp = false;
			fireRateCurrent = fireRateNormal;
			countdown = 5.0f;
			Forcefield.GetComponent<SpriteRenderer> ().enabled = false;

		} else {

			fireRateCurrent = fireRateIncreased;
			Forcefield.GetComponent<SpriteRenderer> ().enabled = true;
		}

	}



	void BulletFire(Transform _transform)
	{
		for(int i = 0; i < bulletlimit; i++)
		{
			if(mybullets[i].activeSelf == false)
			{
				mybullets[i].SetActive(true);
				mybullets[i].transform.position = _transform.position;
				mybullets[i].GetComponent<bulletScript>().velocity(_transform);
				break;
			}
		}
	}

}
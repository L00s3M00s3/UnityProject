using UnityEngine;
using System.Collections;

public class Player_Shooting: MonoBehaviour
{

    public float fireRateCurrent;
    public int bulletlimit = 40;
    public bool isShooting;
    private float nextbullet;
    public bool poweredup;
    public GameObject bulletPrefab;
    GameObject[] mybullets;
    public Transform[] bulletSpawn;
    Transform direction;
    float orient;
    public Animator anim;

    void Awake()
    {
        anim.GetComponent<Animator>();
        mybullets = new GameObject[bulletlimit];

        for (int i = 0; i < bulletlimit; i++)
        {
            mybullets[i] = Instantiate(bulletPrefab) as GameObject;
            mybullets[i].SetActive(false);
        }

    }


    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        
        direction = GetComponent<PlayerMovement>().orientation;
        
        orient = GetComponent<PlayerMovement>().combine;
        
        //orientationshooting(orient);
        
        if (GetComponent<Player_Contact>().canBeHit)
        {
            if (poweredup)
            { 
                DirectionalShooting();
            }
        }

    }

    
   

    void DirectionalShooting()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&direction.rotation.z == 0.0f)
        {

            if (Time.time > nextbullet)
            {
                nextbullet = Time.time + fireRateCurrent;
                BulletFire(bulletSpawn[0].transform);

                //anim.SetBool ("IsAttacking", true);
                //anim.SetFloat("Attack_Y", 1);

            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && LeftOrRight.right)
        {

            if (Time.time > nextbullet)
            {
                nextbullet = Time.time + fireRateCurrent;
                BulletFire(bulletSpawn[1].transform);

                //anim.SetBool ("IsAttacking", true);
                //anim.SetFloat("Attack_X", 1);

            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && direction.rotation.z == 1f)
        {

            if (Time.time > nextbullet)
            {
                nextbullet = Time.time + fireRateCurrent;
                BulletFire(bulletSpawn[2].transform);

                //anim.SetBool ("IsAttacking", true);
                //anim.SetFloat("Attack_Y", -1);

            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && LeftOrRight.left)
        {

            if (Time.time > nextbullet)
            {
                nextbullet = Time.time + fireRateCurrent;
                BulletFire(bulletSpawn[3].transform);

                //anim.SetBool ("IsAttacking", true);
                //anim.SetFloat("Attack_X", -1);

            }
        }
        else {

            anim.SetBool("IsAttacking", false);

        }
    }

    



    void BulletFire(Transform _transform)
    {
        for (int i = 0; i < bulletlimit; i++)
        {
            if (mybullets[i].activeSelf == false)
            {
                mybullets[i].SetActive(true);
                mybullets[i].transform.position = _transform.position;
                mybullets[i].GetComponent<turretScript>().velocity(_transform);
                break;
            }
        }
    }

}
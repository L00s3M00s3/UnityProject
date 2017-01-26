using UnityEngine;
using System.Collections;

public class Pattern_Control : MonoBehaviour {

    public Transform[] emmiters;
    public GameObject shot;
    GameObject[] enemybullets;
    SpriteRenderer Sprite;
    private float nextfire, worriedfire;
    public float ROF, WROF;

    public bool vulnerable;
    int limit = 21;
    float fragile = 1.0f;
    Inventory currentItem;
    [HideInInspector]
    public State _state = State.relaxed;


    // Use this for initialization
    void Awake () {
        Sprite = GetComponentInParent<SpriteRenderer>();
        enemybullets = new GameObject[limit];
        currentItem = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        nextfire = 2.0f;
        for(int i = 0; i < limit; i++)
        {
            enemybullets[i] = Instantiate(shot) as GameObject;
            enemybullets[i].SetActive(false);

        }
	}
	
	// Update is called once per frame
	void Update () {
        ChangeState();

        switch (_state)
        {
            case State.relaxed:
                relaxed();
                break;
            case State.worried:
                worried();
                break;
        }


	
	}

    public enum State
    {
        relaxed,
        worried
    }

    void relaxed()
    {
        if(nextfire < 0.0f)
        {
            
            vulnerable = true;
            Sprite.color = Color.red;
            if (fragile < 0.0f)
            {
                for (int i = 0; i < emmiters.Length; i++)
                {
                    BulletFire(emmiters[i]);
                }
                nextfire = 2.0f;
                fragile = 1.0f;
            }
            fragile -= Time.deltaTime;
        }
        else
        {
            //Write something here about invulnirability
            
                vulnerable = false;
                nextfire -= Time.deltaTime;
            
            
        }
    }

    void worried()
    {
        if (worriedfire < 0.0f)
        {
            vulnerable = true;
            Sprite.color = Color.red;
            if (fragile < 0.0f)
            {
                for (int i = 0; i < emmiters.Length; i++)
                {
                    BulletFire(emmiters[i]);
                }
                worriedfire = 1.0f;
                fragile = .5f;
            }
            fragile -= Time.deltaTime;

        }
        else
        {
            //Write something here about invulnirability
            worriedfire -= Time.deltaTime;
            vulnerable = false;
        }
    }

    void ChangeState()
    {
        if (currentItem.currentItem.Equals(Inventory.Items.Gun))
        {
            _state = State.worried;
        }
        else
        {
            _state = State.relaxed;
        }
    }

    void BulletFire(Transform _transform)
    {
        for(int i = 0; i < limit; i++)
        {
            if (enemybullets[i].activeSelf == false)
            {
                enemybullets[i].SetActive(true);
                enemybullets[i].transform.position = _transform.position;
                enemybullets[i].GetComponent<turretScript>().velocity(_transform);
                break;
            }
        }
    }

    

    


}

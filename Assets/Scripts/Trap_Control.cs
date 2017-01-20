using UnityEngine;
using System.Collections;

public class Trap_Control : MonoBehaviour {

    public GameObject spear;
    GameObject[] trapspears;
    private float nextfire;
    bool right;
    static public bool triggered;
    public float ROF;
    int limit = 3;

	// Use this for initialization
	void Awake () {
        triggered = false;
        right = RightorLeft(gameObject.name);
        trapspears = new GameObject[limit];
        nextfire = 2.0f;
        for (int i = 0; i < limit; i++)
        {
            trapspears[i] = Instantiate(spear) as GameObject;
            trapspears[i].SetActive(false);

        }

    }
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            if (Time.time > nextfire)
            {
                nextfire = Time.time + ROF;
                BulletFire(gameObject.transform, right);
            }
        }
	
	}

    bool RightorLeft(string name)
    {
        if (name.Contains("Right"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void BulletFire(Transform _transform,bool right)
    {
        for (int i = 0; i < limit; i++)
        {
            if (trapspears[i].activeSelf == false)
            {
                trapspears[i].SetActive(true);
                trapspears[i].transform.position = _transform.position;
                trapspears[i].GetComponent<Spear_Script>().velocity(_transform,right);
                break;
            }
        }
    }
}

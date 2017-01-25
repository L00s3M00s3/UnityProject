using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : MonoBehaviour {
    public GameObject spider;
    GameObject[] spiderarray;
    int limit = 1;
    public Transform spawn;
    float spawntime;
    public bool cleaned;
	// Use this for initialization
	void Awake () {
        spiderarray = new GameObject[limit];
        for(int i = 0; i < limit; i++)
        {
            spiderarray[i] = Instantiate(spider) as GameObject;
            spiderarray[i].SetActive(false);
        }
        spawntime = 5.0f;
        cleaned = false;

	}
	
	void Start()
    {
        InvokeRepeating("Spawn", spawntime, spawntime);
    }

    void Spawn()
    {


        if (!cleaned)
        {
            for (int i = 0; i < limit; i++)
            {
                if (spiderarray[i].activeSelf == false)
                {
                    spiderarray[i].SetActive(true);
                    spiderarray[i].transform.position = spawn.position;
                    break;
                }

            }
        }
    }
}

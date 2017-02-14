using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMonsterAI : MonoBehaviour {

	Collider2D attackRange;
	Transform Victim;
	PlayerMovement safe;
	bool AttackPC;
	public float range;
	Vector2 spawnLocation;
	bool spawned,overlap;


	void Start()
	{
		attackRange = GetComponent<Collider2D>();
		attackRange.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		Victim = GameObject.FindGameObjectWithTag("Player").transform;
		safe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		AttackPC = safe.isDead;
		MonsterSpawn(Victim,AttackPC);
	}

	void MonsterSpawn(Transform victim,bool attack)
	{
		if (!attack)
		{
			if (LightFlicker.fade && !spawned)
			{

				gameObject.transform.position = new Vector2(Random.Range(Victim.position.x - range, Victim.position.x + range), Random.Range(Victim.position.y - range, Victim.position.y + range));
				while (overlap)
				{
					gameObject.transform.position = new Vector2(Random.Range(Victim.position.x - range, Victim.position.x + range), Random.Range(Victim.position.y - range, Victim.position.y + range));
				}
				spawned = true;
		
			}
			if (!LightFlicker.fade)
			{
				spawned = false;
			}
		}

		else
		{
			gameObject.transform.position = Victim.position;
			attackRange.enabled = true;
			Debug.Log("Eating Player");
		}
	}



}
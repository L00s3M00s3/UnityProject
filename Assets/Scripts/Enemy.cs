using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[HideInInspector]
	public Transform target;
	public float speed;

	public void MoveTowards()
	{
		float step = speed * Time.deltaTime;

		transform.position = Vector2.MoveTowards(transform.position, target.position, step);
	}

	public void MoveAway()
	{
		float step = speed * Time.deltaTime;

		transform.position = Vector2.MoveTowards(transform.position, target.position, -step);
	}

	public void Idle()
	{
		transform.position = transform.position;
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public Transform target;
	public float speed = 10.0f;
	public int score = 10;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if (transform.position == target.position)
		{
			Destroy(gameObject);
		}
	}

	void ApplyDamage (float amount)
	{
		Manager.instance.score += score;
		Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public Transform target;
	public float speed = 10.0f;

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
			this.gameObject.SetActive(false);
		}
	}
}

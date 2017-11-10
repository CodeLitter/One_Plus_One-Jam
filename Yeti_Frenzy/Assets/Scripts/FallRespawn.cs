using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
	public Transform target;
	public float lowBound = -10.0f;
	private Vector3 returnPosition;
	// Use this for initialization
	void Start ()
	{
		returnPosition = target.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target.position.y < lowBound)
		{
			target.position = returnPosition;
		}
	}
}

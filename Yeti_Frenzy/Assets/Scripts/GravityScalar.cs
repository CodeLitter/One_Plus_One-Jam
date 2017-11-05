using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class GravityScalar : MonoBehaviour
{
	public float positiveMultiplier = 1.0f;
	public float negativeMultiplier = 1.0f;
	[HideInInspector]
	public new Rigidbody rigidbody;
	private Vector3 gravity;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		gravity = Physics.gravity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool is_pressed = CrossPlatformInputManager.GetButton("Action");
		if (rigidbody.velocity.y > 0 && is_pressed)
		{
			Physics.gravity = gravity * positiveMultiplier;
		}
		else if (rigidbody.velocity.y < 0)
		{
			Physics.gravity = gravity * negativeMultiplier;
		}
		else
		{
			Physics.gravity = gravity;
		}
	}
}

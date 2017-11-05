using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour 
{
	public float speed = 10.0f;
	[HideInInspector]
	public new Rigidbody rigidbody;

	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
	}

	void FixedUpdate ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		direction = new Vector3(horizontal, 0, vertical);

		if (direction != Vector3.zero)
		{
			Vector3 force = Camera.main.transform.rotation * direction * speed;
			force.y = 0.0f;
			transform.forward = force;
			force.y = rigidbody.velocity.y;
			rigidbody.velocity = force;
		}
	}
}

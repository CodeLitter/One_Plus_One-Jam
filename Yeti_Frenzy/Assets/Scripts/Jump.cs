using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour 
{	
	public float force = 10.0f;
	public float positiveMultiplier = 0.5f;
	public float negativeMultiplier = 2.0f;
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
		bool is_down = CrossPlatformInputManager.GetButtonDown("Action");
		if (is_down && rigidbody.velocity.y == 0.0f)
		{
			rigidbody.AddForce(0.0f, force, 0.0f, ForceMode.Impulse);
		}

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

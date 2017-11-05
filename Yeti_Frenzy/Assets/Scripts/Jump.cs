using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour 
{	
	public float force = 10.0f;
	[HideInInspector]
	public new Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool is_pressed = CrossPlatformInputManager.GetButtonDown("Action");
		if (is_pressed)
		{
			rigidbody.AddForce(0.0f, force, 0.0f, ForceMode.Impulse);
		}
	}
}

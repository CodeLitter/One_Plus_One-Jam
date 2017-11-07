﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName="Modules/Jump")]
public class Jump : Module 
{	
	public float force = 10.0f;
	public float positiveMultiplier = 0.5f;
	public float negativeMultiplier = 2.0f;
	private Vector3 gravity;

	// Use this for initialization
	override public void OnStart (Player player)
	{
		gravity = Physics.gravity;
	}
	
	// Update is called once per frame
	override public void OnUpdate (Player player)
	{
		bool is_down = CrossPlatformInputManager.GetButtonDown("Action");
		float ground_distance = player.GetComponent<Collider>().bounds.extents.y;
		bool is_grounded = Physics.Raycast(player.transform.position, Vector3.down, ground_distance + 0.1f);
		if (is_down && is_grounded)
		{
			player.rigidbody.AddForce(0.0f, force, 0.0f, ForceMode.Impulse);
		}

		bool is_pressed = CrossPlatformInputManager.GetButton("Action");
		if (player.rigidbody.velocity.y > 0 && is_pressed)
		{
			Physics.gravity = gravity * positiveMultiplier;
		}

		else if (player.rigidbody.velocity.y < 0)
		{
			Physics.gravity = gravity * negativeMultiplier;
		}
		else
		{
			Physics.gravity = gravity;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName="Modules/Strafe")]
public class Strafe : Module
{
	public float speed = 10.0f;

	private Vector3 direction;

	// Use this for initialization
	override public void OnStart (Player player)
	{
		player.rigidbody.freezeRotation = true;
	}

	// Update is called once per frame
	override public void OnUpdate (Player player)
	{
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		direction = (new Vector3(horizontal, 0, vertical)).normalized;

		Vector3 camera_direction = Camera.main.transform.forward;
		camera_direction.y = 0.0f;
		player.transform.forward = camera_direction;

		if (direction != Vector3.zero)
		{
			Vector3 force = Camera.main.transform.rotation * direction * speed;
			force.y = 0.0f;
			if (!Physics.Raycast(player.transform.position, force, 1.0f))
			{
				force.y = player.rigidbody.velocity.y;
				player.rigidbody.velocity = force;
			}
		}
		else
		{
			player.rigidbody.velocity = new Vector3(0, player.rigidbody.velocity.y, 0);
		}
	}
}

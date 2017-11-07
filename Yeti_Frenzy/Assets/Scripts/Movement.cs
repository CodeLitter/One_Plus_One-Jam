using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName="Modules/Movement")]
public class Movement : Module
{
	public float speed = 10.0f;

	private Vector3 direction;

	// Use this for initialization
	override public void OnStart (Player player)
	{
		player.rigidbody.freezeRotation = true;
	}

	override public void OnFixedUpdate (Player player)
	{
	}

	// Update is called once per frame
	override public void OnUpdate (Player player)
	{
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		direction = new Vector3(horizontal, 0, vertical);

		if (direction != Vector3.zero)
		{
			Vector3 force = Camera.main.transform.rotation * direction * speed;
			force.y = 0.0f;
			player.transform.forward = force;
			force.y = player.rigidbody.velocity.y;
			player.rigidbody.velocity = force;
		}
	}
}

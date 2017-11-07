using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName="Modules/Roll")]
public class Roll : Module
{
	public float speed = 10.0f;
	private Vector3 direction;

	// Use this for initialization
	override public void OnStart (Player player)
	{

	}

	public override void OnFixedUpdate (Player player)
	{
		Vector3 limited_velocity = player.rigidbody.velocity;
		limited_velocity.x = Mathf.Clamp(limited_velocity.x, -speed, speed);
		limited_velocity.z = Mathf.Clamp(limited_velocity.z, -speed, speed);
		player.rigidbody.velocity = limited_velocity;
	}

	// Update is called once per frame
	override public void OnUpdate (Player player)
	{
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		direction = new Vector3(horizontal, 0, vertical).normalized;

		if (direction != Vector3.zero)
		{
			Vector3 force = Camera.main.transform.rotation * direction * speed;
			force.y = 0.0f;
			Vector3 torque = Quaternion.Euler(0, 90, 0) * force;
			player.rigidbody.AddTorque(torque, ForceMode.Impulse);
		}
	}
}

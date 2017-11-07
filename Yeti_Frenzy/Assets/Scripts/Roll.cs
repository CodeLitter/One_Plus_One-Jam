using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName="Modules/Roll")]
public class Roll : Module
{
	public float speed = 50.0f;
	private Vector3 direction;

	// Use this for initialization
	override public void OnStart (Player player)
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
			Vector3 force = Camera.main.transform.rotation *
			                (Quaternion.Euler(0, 90, 0) *
			                direction * speed);
			force.y = 0.0f;
			player.rigidbody.AddTorque(force, ForceMode.Impulse);
		}
	}
}

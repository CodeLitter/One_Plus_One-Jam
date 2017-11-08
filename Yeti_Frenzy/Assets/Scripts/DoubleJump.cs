using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName="Modules/DoubleJump")]
public class DoubleJump : Module
{
	public float force = 10.0f;
	private bool firstJumpAble;
	private bool secondJumpAble;

	// Use this for initialization
	override public void OnStart (Player player)
	{
		firstJumpAble = false;
		secondJumpAble = false;
	}

	// Update is called once per frame
	override public void OnUpdate (Player player)
	{
		bool is_down = CrossPlatformInputManager.GetButtonDown("Action");
		float ground_distance = player.GetComponent<Collider>().bounds.extents.y + 0.5f;
		bool is_grounded = Physics.Raycast(player.transform.position, Vector3.down, ground_distance);

		if (is_grounded)
		{
			firstJumpAble = true;
			secondJumpAble = true;
		}
		//Horrible Horrible
		if (is_down && is_grounded && firstJumpAble)
		{
			player.rigidbody.velocity = Vector3.zero;
			player.rigidbody.AddForce(0.0f, force, 0.0f, ForceMode.Impulse);
			firstJumpAble = false;
		}

		if (is_down && !is_grounded && secondJumpAble)
		{
			player.rigidbody.velocity = Vector3.zero;
			player.rigidbody.AddForce(0.0f, force, 0.0f, ForceMode.Impulse);
			secondJumpAble = false;
		}
	}
}

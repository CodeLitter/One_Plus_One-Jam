using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float amount = 10.0f;
	public List<string> tags;

	void OnCollisionEnter (Collision collision)
	{
		if (tags.Contains(collision.transform.tag))
		{
			collision.transform.SendMessage("ApplyDamage", amount);
		}
	}
}

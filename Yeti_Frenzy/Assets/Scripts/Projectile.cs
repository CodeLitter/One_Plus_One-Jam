using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	public float damage = 10.0f;
	public List<string> tags;

	void OnCollisionEnter (Collision collision)
	{
		if (tags.Contains(collision.transform.tag))
		{
			collision.transform.SendMessage("ApplyDamage", damage);
			gameObject.SetActive(false);
		}
	}
}

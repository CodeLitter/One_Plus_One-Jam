using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
	public Transform target;
	public Transform respawnPoint;

	public void Respawn ()
	{
		target.position = respawnPoint.position;
	}
}

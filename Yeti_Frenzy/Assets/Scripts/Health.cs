using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float amount = 100.0f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (amount <= 0.0f)
		{
			gameObject.SetActive(false);
		}	
	}

	void ApplyDamage (float amount)
	{
		this.amount -= amount;
	}
}

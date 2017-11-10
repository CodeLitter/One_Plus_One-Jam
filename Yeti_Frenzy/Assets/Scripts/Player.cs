using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	[HideInInspector]
	public new Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		//call start of each module in manager
		foreach (var module in Manager.instance.modules)
		{
			module.OnStart(this);
		}
	}

	void FixedUpdate ()
	{
		foreach (var module in Manager.instance.modules)
		{
			module.OnFixedUpdate(this);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		foreach (var module in Manager.instance.modules)
		{
			module.OnUpdate(this);
		}
	}

	void LateUpdate ()
	{
		foreach (var module in Manager.instance.modules)
		{
			module.OnLateUpdate(this);
		}
	}

	void ApplyDamage (float amount)
	{
		var health_module = Manager.instance.modules.Find(module => module.GetType() == typeof(Health)) as Health;
		if (health_module != null)
		{
			health_module.ApplyDamage(amount);
		}
	}
}

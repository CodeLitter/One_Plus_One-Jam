using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	public List<Module> modules;
	[HideInInspector]
	public new Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
		modules = Manager.instance.modules;
		modules.Add(ScriptableObject.CreateInstance<Jump>());
		//modules.Add(ScriptableObject.CreateInstance<Movement>());
        modules.Add(ScriptableObject.CreateInstance<Shooter>());
		modules.Add(ScriptableObject.CreateInstance<Roll>());
		//modules.Add(ScriptableObject.CreateInstance<FreeLook>()); //TODO
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
}

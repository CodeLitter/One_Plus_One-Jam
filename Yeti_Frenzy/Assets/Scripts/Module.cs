using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : ScriptableObject
{

	// Use this for initialization
	virtual public void OnStart (Player player) {}

	virtual public void OnFixedUpdate (Player player) {}

	// Update is called once per frame
	virtual public void OnUpdate (Player player) {}

	virtual public void OnLateUpdate (Player player) {}
}

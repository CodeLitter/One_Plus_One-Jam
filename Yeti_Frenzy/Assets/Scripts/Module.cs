using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : ScriptableObject
{

	// Use this for initialization
	virtual public void Start (Player player) {}

	virtual public void FixedUpdate (Player player) {}

	// Update is called once per frame
	virtual public void Update (Player player) {}

	virtual public void LateUpdate (Player player) {}
}

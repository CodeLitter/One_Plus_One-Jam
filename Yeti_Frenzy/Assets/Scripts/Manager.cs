using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Manager")]
public class Manager : ScriptableSingleton<Manager> 
{
	public List<Module> modules;
	public int score;

	void OnEnable ()
	{
		modules.Clear();
	}
}

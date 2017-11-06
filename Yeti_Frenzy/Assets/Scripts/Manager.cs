using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : ScriptableSingleton<Manager> 
{
	public List<Module> modules = new List<Module>();
}

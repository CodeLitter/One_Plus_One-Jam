using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ModuleUI : MonoBehaviour
{
	public enum Type
	{
		MOVEMENT,
		ACTION,
		ATTACK,
		MISC
	}

	public List<Module> modules;
	public Type type;
	[HideInInspector]
	public Image image;
	private int current;

	// Use this for initialization
	void Start ()
	{
		image = GetComponentInChildren<Image>();
		if (Manager.instance.modules.Count <= (int)type)
		{
			int count = ((int)type + 1) - Manager.instance.modules.Count;
			Manager.instance.modules.AddRange(Enumerable.Repeat<Module>(null, count));
		}
		current = modules.IndexOf(Manager.instance.modules[(int)type]);

		if (current == -1)
		{
			current = 0;
			Manager.instance.modules[(int)type] = modules[current];
		}
		image.sprite = modules[current].sprite;
	}

	public void Next ()
	{
		current = (current + 1) % modules.Count;
		image.sprite = modules[current].sprite;
		Manager.instance.modules[(int)type] = modules[current];
	}
}

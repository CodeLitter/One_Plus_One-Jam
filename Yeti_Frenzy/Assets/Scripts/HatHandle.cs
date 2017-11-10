using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatHandle : MonoBehaviour
{
	public List<GameObject> hats;
	public UnityEngine.Events.UnityEvent complete;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hats.TrueForAll(hat => !hat.activeSelf))
		{
			complete.Invoke();
		}
	}
}

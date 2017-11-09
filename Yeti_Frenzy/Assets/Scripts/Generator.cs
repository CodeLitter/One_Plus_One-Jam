using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	public Target[] originals;
	public Transform end;
	public float delay = 5.0f;
	public float interval = 1.0f;
	private Timer timer = new Timer();
	// Use this for initialization
	void Start ()
	{
		timer.Start();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < delay)
		{
			return;
		}

		if (timer.Elapsed > interval)
		{
			var original = originals[Random.Range(0, originals.Length)];
			var instance = Instantiate<Target>(original, transform.position, transform.rotation);
			instance.target = end;
			timer.Reset();
		}
	}
}

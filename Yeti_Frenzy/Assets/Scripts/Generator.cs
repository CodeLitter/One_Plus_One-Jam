using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	public Target[] originals;
	public float multiplier = 1.0f;
	public Transform end;
	public float interval = 1.0f;
	private Timer timer = new Timer();

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer.Elapsed > interval)
		{
			var original = originals[Random.Range(0, originals.Length)];
			var instance = Instantiate<Target>(original, transform.position, transform.rotation);
			instance.target = end;
			instance.score = (int)(instance.score * multiplier);
			timer.Reset();
		}
	}

	public void Play ()
	{
		timer.Start();
	}
}

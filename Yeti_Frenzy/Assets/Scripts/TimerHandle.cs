using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerHandle : MonoBehaviour
{
	public float delay = 5.0f;
	public UnityEvent start;
	public float timeLimit = 300.0f;
	public UnityEvent action;
	[HideInInspector]
	public Text text;
	private delegate void OnUpdate ();
	private OnUpdate updateCaller;
	private Timer timer = new Timer();

	// Use this for initialization
	void Start ()
	{
		text = GetComponentInChildren<Text>();
		timer.Start();
		updateCaller = DelayUpdate;
	}

	// Update is called once per frame
	void Update ()
	{
		if (updateCaller != null)
		{
			updateCaller.Invoke();
		}
	}

	void DelayUpdate ()
	{
		text.text = string.Format("Starting In:\n{0:0000}", (delay - timer.Elapsed));
		if (timer.Elapsed >= delay)
		{
			start.Invoke();
			timer.Reset();
			updateCaller = MainUpdate;
		}
	}

	void MainUpdate ()
	{
		text.text = string.Format("Time Left:\n{0:0000}", (timeLimit - timer.Elapsed));
		if (timer.Elapsed >= timeLimit)
		{
			action.Invoke();
			enabled = false;
		}
	}
}

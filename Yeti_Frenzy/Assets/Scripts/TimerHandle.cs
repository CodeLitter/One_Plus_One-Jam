﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerHandle : MonoBehaviour
{
	public float timeLimit = 300.0f;
	public UnityEvent action;
	[HideInInspector]
	public Text text;
	private Timer timer = new Timer();

	// Use this for initialization
	void Start ()
	{
		text = GetComponentInChildren<Text>();
		timer.Start();
	}

	// Update is called once per frame
	void Update ()
	{
		text.text = string.Format("Time Left:\n{0:0000}", (timeLimit - timer.Elapsed));
		if (timer.Elapsed >= timeLimit)
		{
			action.Invoke();
			enabled = false;
		}
	}
}
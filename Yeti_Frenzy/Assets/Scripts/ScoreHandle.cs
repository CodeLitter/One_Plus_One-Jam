using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreHandle : MonoBehaviour
{
	public int scoreToComplete = 1000;
	public UnityEvent action;
	[HideInInspector]
	public Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponentInChildren<Text>();
		Manager.instance.score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = string.Format("Score:\n{0:0000}", Manager.instance.score);
		if (scoreToComplete <= Manager.instance.score)
		{
			action.Invoke();
			enabled = false;
		}
	}
}

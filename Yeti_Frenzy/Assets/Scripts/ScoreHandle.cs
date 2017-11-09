using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandle : MonoBehaviour
{
	[HideInInspector]
	public Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = string.Format("Score:\n{0:0000}", Manager.instance.score);
	}
}

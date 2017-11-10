using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	[HideInInspector]
	public Slider slider;
	private Health health;

    void Start ()
    {
        slider = GetComponent<Slider>();
    }
	
	void Update ()
    {
		if (health != null)
		{
			slider.value = health.amount;
		}
		else
		{
			health = Manager.instance.modules.Find(module => module.GetType() == typeof(Health)) as Health;
		}
	}
}

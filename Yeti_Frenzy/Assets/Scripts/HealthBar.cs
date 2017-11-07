using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float maxHealth;
    public float minHealth;
    public float currentHealth;

    private bool alive;

    private Slider slider;

    public bool Alive
    {
        get
        {
            return alive;
        }

        set
        {
            alive = value;
        }
    }
    
    void Start ()
    {
        slider = GetComponent<Slider>();
        currentHealth = slider.value;
        maxHealth = slider.maxValue;
        minHealth = slider.minValue;

    }
	
	void Update ()
    {
        slider.value = currentHealth;

        if (currentHealth == minHealth)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }
	}

    public void addDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
        }
    }

    public void addHealth(int healthAmount)
    {
        currentHealth += healthAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public float healthAmount()
    {
        return currentHealth;
    }
}

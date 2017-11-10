using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Modules/Health")]
public class Health : Module {

	public float amount = 100.0f;
	public UnityEngine.Events.UnityEvent onDeath;

	// Use this for initialization
	override public void OnStart (Player player)
	{
		
	}
	
	// Update is called once per frame
	override public void OnUpdate (Player player)
	{
		if (amount <= 0.0f)
		{
			amount = 100.0f;
			onDeath.Invoke();
		}	
	}

	void ApplyDamage (float amount)
	{
		this.amount -= amount;
        playHurtSound();
	}

    void playHurtSound()
    {
        SoundManager.getInstance().playEffect("Grunt");
    }
}

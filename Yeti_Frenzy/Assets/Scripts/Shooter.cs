using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Modules/Shooter")]
public class Shooter : Module
{
    public float speed = 1000.0f;              // The speed at which the projectile will move.
    private GameObject snowball_pattern;     // The GameObject we will instatiate child gameobjects with.
    private GameObject snowball_clone;      // The instantiated game object, which calculations/physics will be performed on.

    //-------------------------------------------------------------------------
    // Use this for initialization
    override public void OnStart(Player player)
    {
        this.snowball_pattern = Resources.Load("Snowball") as GameObject;
    }

    //-------------------------------------------------------------------------
    // Update is called once per frame
    override public void OnUpdate(Player player)
    {
        bool is_down = CrossPlatformInputManager.GetButtonDown("Attack");

        if (is_down)
        {

            Vector3 front = (player.transform.forward*2) + player.transform.position;

            if (snowball_clone)
            {
                this.snowball_clone.transform.position = front;
            }
            else
            { 
                this.snowball_clone = Instantiate<GameObject>(snowball_pattern, front, Quaternion.identity) as GameObject;
            }

			this.snowball_clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.snowball_clone.GetComponent<Rigidbody>().AddForce(player.transform.forward * this.speed);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutcracker : MonoBehaviour {

    private const float ATTACKINTERVAL = 1.5f;

	public float projectileSpeed = 100.0f;
    private float timeSinceLastAttack = 0.0f;

    private Transform myTarget;
    private GameObject thePlayer;
    private GameObject nut_clone;

    public  GameObject nut_pattern;

    //-------------------------------------------------------------------------
    // Use this for initialization
    void Start ()
    {
        this.thePlayer = GameObject.Find("yeti");
        if (!this.nut_pattern)
        {
            Debug.LogAssertion("Err, nut not provided for Nutcracker.  How will he crack nuts?");
        }
	}

    //-------------------------------------------------------------------------
    // Update is called once per frame
    void Update ()
    {
        if (myTarget)
        {
            this.transform.LookAt(myTarget);

            if (timeSinceLastAttack <= 0.0f)
            {
                throwNut();
                timeSinceLastAttack += Time.deltaTime;
            }
            else
            {
                timeSinceLastAttack += Time.deltaTime;
            }

            if (timeSinceLastAttack >= ATTACKINTERVAL)
            {
                timeSinceLastAttack = 0;
            }
        }
	}

    //-------------------------------------------------------------------------
    //
    void throwNut()
    {
        Vector3 front = (this.transform.forward * 2) + this.transform.position;

        if (nut_clone)
        {
            this.nut_clone.transform.position = front;
            this.nut_clone.SetActive(true);
        }
        else
        {
            this.nut_clone = Instantiate<GameObject>(nut_pattern, front, Quaternion.identity) as GameObject;
        }

        this.nut_clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.nut_clone.GetComponent<Rigidbody>().AddForce(this.transform.forward * this.projectileSpeed);
    }

    //-------------------------------------------------------------------------
    //
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            myTarget = other.transform;

        }
    }

    //-------------------------------------------------------------------------
    //
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            myTarget = null;
        }
    }
}

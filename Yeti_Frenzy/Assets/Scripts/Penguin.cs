using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : Enemy
{
    //-----------------------------------------------------------------------------
    // Default values for an Penguin
    private const int HEALTHDEFAULT = 2;
    private const int DAMAGEDEFAULT = 5;
    private const float SPEEDDEFAULT = 2;
    private const float ROTATIONSPEEDDEFAULT = 1;
    private const float ATTACKINTERVAL = 1.5f;

    private float detectionRadius = 5.0f;

    private Vector3 startPos;
    private Vector3 targetDestination;
    private bool targetIsPlayer;

    //-----------------------------------------------------------------------------
    // Private member variable data.
    private float timeSinceLastAttack = 0.0f;   // The time elapsed since this Penguin has last attacked.
    private bool isInAttackRadius = false;     // Is the player within this Penguin's attack radius?

    private Animator myAnimator;
    public Animator animator
    {
        get
        {
            if (myAgent == null)
            {
                myAnimator = GetComponent<Animator>();
            }
            return myAnimator;
        }
    }

    private UnityEngine.AI.NavMeshAgent myAgent;
    public UnityEngine.AI.NavMeshAgent agent
    {
        get
        {
            if (myAgent == null)
            {
                myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            }
            return myAgent;
        }
    }

    //-----------------------------------------------------------------------------
    // A reference to the player.
    private GameObject thePlayer;

    //=============================================================================
    // Initialize things here
    void Awake()
    {
        this.myHealth = HEALTHDEFAULT;
        this.myDamage = DAMAGEDEFAULT;
        this.myRotationSpeed = ROTATIONSPEEDDEFAULT;
        this.myType = enType.PENGUIN;
        this.thePlayer = GameObject.Find("yeti");
    }

    //=============================================================================
    // Post Initialization things here
    void Start()
    {
        this.thePlayer = GameObject.Find("yeti");
        this.startPos = this.transform.position;
    }

    //=============================================================================
    // Update is called once per frames
    void Update()
    {
        switch (this.myState)
        {
            case enState.IDLE:
                break;
            case enState.TRACK:
                pursueTarget();
                break;
            case enState.ATTACK:
                attackPlayer();
                break;
            case enState.MOVE:
                break;
            case enState.DEAD:
                killPenguin();
                break;
            default:
                break;
        }

        checkPenguinHealth();
        stateUpdate();
    }

    //=============================================================================
    // Sets the detection radius of this Penguin to the passed value.
    public void setDetectionRadius(float radius)
    {
        this.detectionRadius = radius;
    }

    //=============================================================================
    // Updates the state of this Penguin, if needed.
    void stateUpdate()
    {
        switch (this.myState)
        {
            //-----------------------------------------------------------------------------
            case enState.IDLE:
                //check to see if the player has entered the aggression radius
                if (isPlayerNearby())
                {
                    this.targetIsPlayer = true;
                    this.targetDestination = thePlayer.transform.position;
                    this.myState = enState.TRACK;
                }
                break;
            //-----------------------------------------------------------------------------
            case enState.TRACK:
                //check to see if the player has left aggression radius
                if (!isPlayerNearby())
                {
                    this.myState = enState.IDLE;
                }
                break;
            //-----------------------------------------------------------------------------
            case enState.ATTACK:
                //check to see if the player has left the attack radius
                if (isPlayerNearby() && !isInAttackRadius)
                {
                    this.myState = enState.MOVE;
                }
                // check to see if the player has left the aggression radius
                else if (!isPlayerNearby() && !isInAttackRadius)
                {
                    this.myState = enState.IDLE;
                }
                break;
            //-----------------------------------------------------------------------------
            case enState.MOVE:
                break;
            //-----------------------------------------------------------------------------
            case enState.DEAD:
                //Penguin is dead, object should be destroyed, if not already.
                killPenguin();
                break;
        }
    }

    //=============================================================================
    // If something enters the trigger box, do something based upon it's type.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Projectile"))
        {
            damagePenguin();
        }
    }

    //=============================================================================
    // If something enters the trigger box, do something based upon it's type.
    void OnTriggerStay(Collider other)
    {
        if (other.transform.name.Equals("Kira") && this.myState != enState.ATTACK)
        {
            this.myState = enState.ATTACK;
            this.targetIsPlayer = false;
            this.targetDestination = startPos;

        }
    }

    //=============================================================================
    // If something enters the trigger box, do something based upon it's type.
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))

        {
            this.myState = enState.TRACK;
        }
    }

    //=============================================================================
    // Check to see if the health of this Penguin is 0, if so, change the state of this
    // Penguin to enState.DEAD
    void checkPenguinHealth()
    {
        if (isDefeated())
        {
            this.myState = enState.DEAD;
        }
    }

    //=============================================================================
    // Follow the player around, until the player enters the hitbox for attacking.
    void pursueTarget()
    {
        this.transform.LookAt(new Vector3(targetDestination.x,
                                          this.transform.position.y,
                                          targetDestination.z));

        if (this.targetIsPlayer == false)
        {
            if (Vector3.Distance(this.targetDestination, this.transform.position) <= 0.2f)
            {
                Debug.Log("Targeting Player");
                this.targetDestination = thePlayer.transform.position;
                this.targetIsPlayer = true;
            }
        }
        else
        {
            this.targetDestination = thePlayer.transform.position;
        }

        this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(targetDestination);
    }

    //=============================================================================
    // Returns whether or not the player is within aggression radius.
    bool isPlayerNearby()
    {
        bool withinX = false;
        bool withinY = false;
        bool withinZ = false;

        if (Mathf.Abs(this.transform.position.x - thePlayer.transform.position.x) <= this.detectionRadius)
        {
            withinX = true;
        }
        if (Mathf.Abs(this.transform.position.y - thePlayer.transform.position.y) <= this.detectionRadius)
        {
            withinY = true;
        }
        if (Mathf.Abs(this.transform.position.z - thePlayer.transform.position.z) <= this.detectionRadius)
        {
            withinZ = true;
        }

        return ((withinX == withinY) && (withinY == withinZ) && (withinZ == withinX));
    }

    //=============================================================================
    // Attack the player, and prevent damaging for a small period of time.
    void attackPlayer()
    {
        if (timeSinceLastAttack <= 0.0f)
        {
            //do damage to player.
            SoundManager.getInstance().playEffect("Grunt");
            thePlayer.SendMessage("ApplyDamage", 10.0f);
     
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

    //=============================================================================
    // "Destroys" the Penguin and all assosciated gameobjects.
    // ALL enemies will be moved to a magic value, where they will be deactivated.
    void killPenguin()
    {

        this.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;  // Disable the NavmeshAgent in order to prevent the Penguin
                                                                           // from clipping back onto the platform after being "killed".
        this.transform.position = OUTOFBOUNDS;              // Move this Penguin out of bounds to the predefined location.
        this.gameObject.SetActive(false);                   // Disable this Penguin, preventing interactability.
    }

    //=============================================================================
    // Deal a single point of damage to the Penguin.
    void damagePenguin()
    {
        this.myHealth -= 1;
        playHurtSound();
    }

    //=============================================================================
    // Deal a specific amount of damage to the Penguin.  A negative number may be
    // passed to heal the Penguin by the passed amount.
    void damagePenguin(int damage)
    {
        this.myHealth -= damage;
        playHurtSound();
    }

    //=============================================================================
    // Plays a random hurt sound from a selection of pre-defined sounds.  Sounds
    // chosen via random number generation.
    void playHurtSound()
    {
        int val = 0;
        val = (int)Random.Range(0f, 2.99f) + 1;
        SoundManager.getInstance().playEffect("Squeak" + val);
    }

    void OnAnimatorMove()
    {
        // Update position based on animation movement using navigation surface height
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
    }

}
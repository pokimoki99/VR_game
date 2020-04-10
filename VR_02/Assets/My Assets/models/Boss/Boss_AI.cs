using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.

    private UnityEngine.AI.NavMeshAgent nav;                                // Reference to the nav mesh agent.
    public Transform player_transform;                               // Reference to the player's transform.
    public GameObject player;
    public Player_hp player_hp;

    public string text;
    public float timeBetweenAttacks = 3.0f;     // The time in seconds between each attack.
    //Playerhp playerHealth;                  // Reference to the player's health.

    float timer=3;                                // Timer for counting up to the next attack.
    enum AIState { Chasing, Attacking };

    AIState state;

    float enemydist;   //how far away is enemy



    public Animator anim;

    int attack;

    //Text messagetext;


    //Colliders
    public GameObject Leg_Sweep;
    public GameObject Swipe;
    public GameObject Cast;
    public GameObject Punch;
    public GameObject Kick;

    //collider tests
    bool player_hit, Leg_Sweep_Hit, Swipe_Hit, Cast_Hit, Punch_Hit, Kick_Hit,attacking;

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        var rotation = Quaternion.LookRotation(player_transform.position - transform.position);
        transform.rotation = rotation;//Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.5f);

        anim = this.gameObject.GetComponent<Animator>();

        anim.SetBool("IsBattlecry",true);
        StartCoroutine(battlecry_timer());

        Leg_Sweep.GetComponent<BoxCollider>().enabled = false;
        Kick.GetComponent<BoxCollider>().enabled = false;
        Swipe.GetComponent<BoxCollider>().enabled = false;
        Cast.GetComponent<BoxCollider>().enabled = false;
        Punch.GetComponent<BoxCollider>().enabled = false;

        //messagetext = GameObject.Find("MessageText").GetComponent<Text>();


    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        switch (state)
        {
            case AIState.Chasing:
                Chasing();
                break;
            case AIState.Attacking:
                Attacking();
                break;
        }

        enemydist = Vector3.Distance(player.transform.position, transform.position);

        if (enemydist <= 20)
        {
            state = AIState.Chasing;

        }

        if (enemydist <= 4)
        {

            state = AIState.Attacking;
        }
    }


    void Chasing()
    {
        //nav.speed = 0;
        nav.destination = player.transform.position;
        nav.speed = chaseSpeed;
        nav.isStopped = false;
    }

    void Attacking()
    {
        
        if (timer >= timeBetweenAttacks)
        { 

            nav.speed = 0;
            if (attacking == false)
            {

                Leg_Sweep.GetComponent<BoxCollider>().enabled = true;
                Swipe.GetComponent<BoxCollider>().enabled = true;
                Cast.GetComponent<BoxCollider>().enabled = true;
                Punch.GetComponent<BoxCollider>().enabled = true;
                Kick.GetComponent<BoxCollider>().enabled = true;
                if (attack == 0)
                {
                    anim.SetBool("IsAttacking", true);
                    anim.SetFloat("attack", 0);
                    StartCoroutine(Attack_timer());
                    //Debug.Log("Leg_Sweep");
                    //legswee
                    Leg_Sweep_Hit = true;
                    attacking = true;

                }
                else if (attack == 1)
                {
                    anim.SetBool("IsAttacking", true);
                    anim.SetFloat("attack", 0.25f);
                    StartCoroutine(Attack_timer());
                    //Debug.Log("Swipe");
                    //clawattack
                    Punch_Hit = true;
                    attacking = true;


                }
                else if (attack == 2)
                {
                    anim.SetBool("IsAttacking", true);
                    anim.SetFloat("attack", 0.5f);
                    StartCoroutine(Attack_timer());
                    //Debug.Log("cast");
                    //cast
                    Cast_Hit = true;
                    attacking = true;


                }
                else if (attack == 3)
                {
                    anim.SetBool("IsAttacking", true);
                    anim.SetFloat("attack", 0.75f);
                    StartCoroutine(Attack_timer());
                    //Debug.Log("punch");
                    //swipe
                    Swipe_Hit = true;
                    attacking = true;
                }
                else if (attack == 4)
                {
                    anim.SetBool("IsAttacking", true);
                    anim.SetFloat("attack", 1);
                    StartCoroutine(Attack_timer());
                    //Debug.Log("kick");
                    Kick_Hit = true;
                    attacking = true;
                }
            }



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player_hit = true;


            if (player_hit)
            {

                Leg_Sweep.GetComponent<BoxCollider>().enabled = false;
                Swipe.GetComponent<BoxCollider>().enabled = false;
                Cast.GetComponent<BoxCollider>().enabled = false;
                Punch.GetComponent<BoxCollider>().enabled = false;
                Kick.GetComponent<BoxCollider>().enabled = false;
                if (Leg_Sweep_Hit)
                {
                    //Leg_Sweep.GetComponent<BoxCollider>().enabled = true;
                    player_hp.health-=0.2f;
                    Leg_Sweep_Hit = false;
                    Debug.Log("leg");
                    attacking = false;
                    Leg_Sweep.GetComponent<BoxCollider>().enabled = false;
                }
                else if (Swipe_Hit)
                {
                    //Swipe.GetComponent<BoxCollider>().enabled = true;
                    player_hp.health-=0.3f;
                    Swipe_Hit = false;
                    Debug.Log("swipe");
                    attacking = false;
                    Swipe.GetComponent<BoxCollider>().enabled = false;

                }
                else if (Cast_Hit)
                {
                    //Cast.GetComponent<BoxCollider>().enabled = true;
                    //Cast_Hit = false;
                    player_hp.health-=0.1f;
                    Debug.Log("cast");
                    attacking = false;
                    Cast.GetComponent<BoxCollider>().enabled = false;
                }
                else if (Punch_Hit)
                {
                    //Punch.GetComponent<BoxCollider>().enabled = true;
                    player_hp.health-=0.2f;
                    Punch_Hit = false;
                    Debug.Log("punch");
                    attacking = false;
                    Punch.GetComponent<BoxCollider>().enabled = false;
                }
                else if (Kick_Hit)
                {
                    //Kick.GetComponent<BoxCollider>().enabled = true;
                    player_hp.health-=-0.2f;
                    Kick_Hit = false;
                    Debug.Log("kick");
                    attacking = false;
                    Kick.GetComponent<BoxCollider>().enabled = false;
                }
                player_hit = false;
            }
        }
    }

    void attack_type()
    {
        attack = Random.Range(0, 4);
    }
    IEnumerator Attack_timer()
    {
        yield return new WaitForSeconds(2.8f);
        anim.SetBool("IsAttacking", false);
        timer = 0;
        attack_type();
        attacking = false;

    }
   IEnumerator battlecry_timer()
    {
        yield return new WaitForSeconds(2.8f);
        anim.SetBool("IsBattlecry", false);
        yield return new WaitForSeconds(0.00001f);
        state = AIState.Chasing;
    }
    
}


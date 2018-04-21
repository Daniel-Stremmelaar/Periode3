using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Walker : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private float currentTime;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool senseField;
    [HideInInspector] public bool chasing;
    private bool attackTimer;
    [SerializeField] private float attackRateMain;
    private float attakcRate;
    [SerializeField] private float time;
    [SerializeField] private Transform raycastPos;
    [SerializeField] private int damage;

    [Header("Charging")]
    [SerializeField] private Transform chargePoint;

    private RaycastHit look;
    private RaycastHit attack;


    void Start ()
    {
        attakcRate = attackRateMain;
        senseField = false;
        currentTime = time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
	}
    void Update()
    {
        ThinkTimer();
        isChasing();
        isAttack();
        isLooking();
    }

    void ThinkTimer()
    {
        if (chasing && !senseField && !isDead)
        {
            currentTime -= Time.deltaTime;
            agent.SetDestination(player.position);
        }

        if (currentTime <= 0)
        {
            chasing = false;
            currentTime = time;
            agent.SetDestination(chargePoint.position);
        }
    }
    void isLooking()
    {
        if (Physics.Raycast(raycastPos.position, raycastPos.forward, out look, 10f))
        {
            if (!isDead)
            {
                if (look.transform.tag == "Player")
                {
                    chasing = true;
                    isChasing();
                }
            }
        }
        Debug.DrawRay(raycastPos.position, raycastPos.forward * 10, Color.red);
    }

    public void isChasing()
    {
        if (chasing)
        {
            agent.SetDestination(player.position);
        }
    }


    public void Sensefield()
    {
        agent.SetDestination(player.position);
    }

    void isAttack()
    {
        if (Physics.Raycast(raycastPos.position, raycastPos.forward, out attack, 3f))
        {
            if (attack.transform.tag == "Player")
            {
                attakcRate -= Time.deltaTime;
            }
        }
        Debug.DrawRay(raycastPos.position, raycastPos.forward * 3, Color.yellow);

        if (attakcRate <= 0)
        {
            attack.transform.GetComponent<Train_Health_Manager>().HurtPlayer(damage);
            attakcRate = attackRateMain;
        }
    }

}

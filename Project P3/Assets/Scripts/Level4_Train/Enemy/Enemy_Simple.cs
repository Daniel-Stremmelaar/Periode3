using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Simple : MonoBehaviour
{
    private NavMeshAgent agent;
    private int numberPoint;
    private RaycastHit attack;
    private float attakcRate;
    private Transform player;
    private float currentTime;
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] private Transform raycastPos;
    [SerializeField] private float attackRateMain;
    [SerializeField] private float damage;
    [SerializeField] private float time;

    [HideInInspector] public bool senseField;
    public bool chasing1;

    void Start()
    {
        attakcRate = attackRateMain;
        currentTime = time;
        numberPoint = 0;
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        isAttack();
        agent.SetDestination(wayPoints[numberPoint].position);
    }

    void ThinkTimer()
    {
        if (chasing1 && !senseField)
        {
            currentTime -= Time.deltaTime;
            agent.SetDestination(player.position);
        }

        if (currentTime <= 0)
        {
            chasing1 = false;
            currentTime = time;
            agent.SetDestination(wayPoints[numberPoint].position);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "WayPoint")
        {
            if (other.transform == wayPoints[0])
            {
                numberPoint = 1;
            }
            else if (other.transform == wayPoints[1])
            {
                numberPoint = 0;
            }
        }
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

    public void isChasing()
    {
        if (chasing1)
        {
            agent.SetDestination(player.position);
        }
    }
}


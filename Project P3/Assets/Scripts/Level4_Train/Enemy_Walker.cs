using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Walker : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private float currentTime;
    [SerializeField]private bool senseFieldB;
    [SerializeField]private bool hittrue;
    [SerializeField] private float time;

    [Header("Charging")]
    [SerializeField] private Transform chargePoint;

    [SerializeField] RaycastHit hit;


    void Start ()
    {
        senseFieldB = false;
        hittrue = false;
        currentTime = time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
	}
    void Update()
    {
        ThinkTimer();
        Attack();
    }

    void ThinkTimer()
    {
        if (senseFieldB)
        {
            currentTime -= Time.deltaTime;
            agent.SetDestination(player.position);
        }

        if (currentTime <= 0)
        {
            currentTime = time;
            senseFieldB = false;
            agent.SetDestination(chargePoint.position);
        }
    }

    void Sensefield()
    {
        agent.SetDestination(player.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hittrue)
        {
            Sensefield();
        }
    }

    void OnTriggerExit(Collider other)
    {  
        if (other .gameObject.tag == "Player" && hittrue)
        {
            senseFieldB = true;
        }
    }

    void Attack()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit,20f))
        {
            if (hit.transform.tag == "Player")
            {
                hittrue = true;
                agent.SetDestination(player.position);
            }
            else
            {
                hittrue = false;
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
    }

}

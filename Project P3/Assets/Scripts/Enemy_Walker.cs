using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Walker : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private float currentTime;
    private bool senseFieldB;
    [SerializeField] private float time;

    [Header("Charging")]
    [SerializeField] private Transform chargePoint;


    void Start ()
    {
        senseFieldB = false;
        currentTime = time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
	}
    void Update()
    {
        ThinkTimer();
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
        if (other.gameObject.tag == "Player")
        {
            Sensefield();
        }
    }

    void OnTriggerExit(Collider other)
    {
        senseFieldB = true;
    }

}

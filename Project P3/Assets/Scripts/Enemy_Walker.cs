using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Walker : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update ()
    {
        agent.SetDestination(player.position);
	}
}

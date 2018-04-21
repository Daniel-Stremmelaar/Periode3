using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Simple : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private int numberPoint;
    [SerializeField] List<Transform> wayPoints = new List<Transform>();

    void Start()
    {
        numberPoint = 0;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(wayPoints[numberPoint].position);
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
}


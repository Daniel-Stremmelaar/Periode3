using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensfield : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bool dDead = enemy.GetComponent<Enemy_Walker>().isDead;
            if (!dDead)
            {
                enemy.GetComponent<Enemy_Walker>().chasing = true;
                enemy.GetComponent<Enemy_Walker>().senseField = true;
                enemy.GetComponent<Enemy_Walker>().isChasing();
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.GetComponent<Enemy_Walker>().senseField = false;
        }
    }
}

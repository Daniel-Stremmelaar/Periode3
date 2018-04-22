using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensfield : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private bool enemyWalker;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemyWalker)
            {
                enemy.GetComponent<Enemy_Walker>().chasing = true;
                enemy.GetComponent<Enemy_Walker>().senseField = true;
                enemy.GetComponent<Enemy_Walker>().isChasing();
            }
            else
            {
                enemy.GetComponent<Enemy_Simple>().chasing1 = true;
                enemy.GetComponent<Enemy_Simple>().senseField = true;
                enemy.GetComponent<Enemy_Simple>().isChasing();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemyWalker)
            {
                enemy.GetComponent<Enemy_Walker>().senseField = false;
            }
            else
            {
                enemy.GetComponent<Enemy_Simple>().senseField = false;
            }
        }
    }
}

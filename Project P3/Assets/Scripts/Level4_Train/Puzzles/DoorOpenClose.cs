using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpenClose : MonoBehaviour
{
    [HideInInspector]public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print(other.transform.name);
            anim.SetBool("DoorOpen", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            anim.SetBool("DoorOpen", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Health_Manager : MonoBehaviour
{
    public int health;

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    public virtual void Health(int damage)
    {
        health -= damage;
    }
}

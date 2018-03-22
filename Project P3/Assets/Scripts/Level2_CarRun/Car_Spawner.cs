using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : Spawner_Base
{
    private int car1;

    void Start()
    {
        car1 = Random.Range(0, 1);
    }
    public override void Spawner()
    {
        base.Spawner();
        Instantiate(cars[car1], transform.position, transform.rotation);
    }
}

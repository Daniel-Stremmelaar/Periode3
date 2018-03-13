using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Behavior : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        MoveSpeed();
    }
    public void MoveSpeed()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

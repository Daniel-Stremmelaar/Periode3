using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Train : MonoBehaviour
{
    [SerializeField] int number;

    public void Pressed()
    {
        transform.gameObject.GetComponentInParent<PuzzelDoor_Train>().Buttons(number);
    }
}

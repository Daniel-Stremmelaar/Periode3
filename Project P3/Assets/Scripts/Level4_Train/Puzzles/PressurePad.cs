using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private int number;
    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "PickUp")
        {
            collision.transform.gameObject.GetComponent<BoxNumber>();
            if (collision.transform.gameObject.GetComponent<BoxNumber>().numberBox == number)
            {
                transform.gameObject.GetComponentInParent<Puzzle_2Box>().PressurePad(number);
            }
        }
    }
}

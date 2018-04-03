using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTrain_PlayerInteract : MonoBehaviour
{
    [SerializeField] private RaycastHit hit;
    [SerializeField] private float raycastLength;
    [SerializeField] GameObject doorPanel;


    void Start ()
    {
		
	}

	void Update ()
    {
        Interact();
    }

    void Interact()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag != null)
            {
                if (hit.transform.tag == "DoorPanel")
                {
                    doorPanel.SetActive(true);
                    if (Input.GetButtonDown("E"))
                    {
                        Debug.Log("Door Opens");
                    }
                }
                else
                {
                    doorPanel.SetActive(false);
                }
            }
            else
            {
                
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 20, Color.blue);
    }

}

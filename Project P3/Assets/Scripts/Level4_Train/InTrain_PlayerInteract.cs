using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTrain_PlayerInteract : MonoBehaviour
{
    [SerializeField] private RaycastHit hit;
    [SerializeField] private float raycastLength;
    [SerializeField] private GameObject doorPanel;
    [SerializeField] private bool hitPanel;
    private Transform panel;


    void Start()
    {
        hitPanel = false;
    }

    void Update()
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
                    hitPanel = true;
                    panel = hit.transform.GetChild(0);
                    panel.gameObject.SetActive(true);               
                    if (Input.GetButtonDown("E"))
                    {
                        Debug.Log("Door Opens");
                    }
                }
                else
                {
                    hitPanel = false;
                    doorPanel.SetActive(false);
                    panel.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            //panel.gameObject.SetActive(false);
            doorPanel.SetActive(false);
        }
        Debug.DrawRay(transform.position, transform.forward * 5, Color.blue);
    }
}
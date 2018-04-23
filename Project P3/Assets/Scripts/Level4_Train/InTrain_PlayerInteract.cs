using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTrain_PlayerInteract : MonoBehaviour
{
    [SerializeField] private RaycastHit hit;
    [SerializeField] private float raycastLength;
    [SerializeField] private GameObject doorPanel;
    [SerializeField] private Transform crosshair;

    [SerializeField] private float currentStamina;
    [SerializeField] private float maxStamina;
    public Slider staminaSlider;
    [SerializeField] private float weight;
    [SerializeField]private bool noPower;
    private Rigidbody grav;

    private string contact;
    private string obj;

    void Start()
    {
        noPower = false;
        currentStamina = maxStamina;
        staminaSlider.value = CalculaterWeight();
        Cursor.visible = false;
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {
        Interact();
    }


    void Interact()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            grav = hit.transform.gameObject.GetComponent<Rigidbody>();
            contact = hit.transform.tag;
            obj = hit.transform.name;
            switch (contact)
            {
                case "Puzzle":
                    if (obj == "Button1" || obj == "Button2" || obj == "Button3")
                    {
                        doorPanel.SetActive(true);
                        if (Input.GetButtonDown("E"))
                        {
                            hit.transform.gameObject.GetComponent<Button_Train>().Pressed();
                        }
                    }
                    else
                    {
                        doorPanel.SetActive(false);
                    }
                    break;
                case "PickUp":
                    if (Input.GetButton("Fire1"))
                    {
                        if (!noPower)
                        {
                            if (hit.transform.gameObject.GetComponent<Rigidbody>().mass > 100)
                            {
                                currentStamina -= Time.deltaTime * grav.mass / weight;
                                Stamina();
                                hit.transform.parent = gameObject.transform;
                                grav.useGravity = false;
                                grav.isKinematic = true;
                            }
                            else
                            {
                                hit.transform.parent = gameObject.transform;
                                grav.useGravity = false;
                                grav.isKinematic = true;
                            }
                        }
                        else
                        {
                            hit.transform.parent = null;
                            grav.useGravity = true;
                            grav.isKinematic = false;
                        }
                    }
                    else
                    {
                        hit.transform.parent = null;
                        grav.useGravity = true;
                        grav.isKinematic = false;
                    }
                    break;
                default:
                    doorPanel.SetActive(false);
                    break;
            }
            Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
        }
        else
        {
            doorPanel.SetActive(false);
        }
        Vector3 aboveGround = new Vector3(0,0,0);
        RaycastHit cros;
        if (Physics.Raycast(transform.position,transform.forward, out cros , Mathf.Infinity))
        {
            hit.point += aboveGround;
            crosshair.position = cros.point;
        }
        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        else
        {
            currentStamina += Time.deltaTime * weight;
            Stamina();
        }
        if (currentStamina > 10)
        {
            noPower = false;
        }
    }

    public void Stamina()
    {
        staminaSlider.value = CalculaterWeight();
        if (currentStamina <= 0)
        {
            noPower = true;
            currentStamina = 0;
            hit.transform.parent = null;
            grav.useGravity = true;
            grav.isKinematic = false;
        }
    }

    private float CalculaterWeight()
    {
        return currentStamina / maxStamina;
    }
}
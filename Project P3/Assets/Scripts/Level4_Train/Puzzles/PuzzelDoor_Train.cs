using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelDoor_Train : MonoBehaviour
{
    [SerializeField] private List<bool> button = new List<bool>();
    [SerializeField] private List<bool> lockSwitch = new List<bool>();
    public bool dooropen;
    static Animator anim;
    public int amount;
    private PuzzleCalculater puzzleCal;

    [SerializeField] Material non;
    [SerializeField] Material green;

    [SerializeField] private List<GameObject> lightB = new List<GameObject>();

    void Start()
    {
        bool newBoolb = new bool();
        for (int l = 0; l < lightB.Count; l++)
        {
            lightB[l].GetComponent<MeshRenderer>().material = non;
        }

        for (int i = 0; i < 3; i++)
        {
            button.Add(newBoolb);
        }

        bool newBoolLS = new bool();
        for (int ls = 0; ls < 3; ls++)
        {
            lockSwitch.Add(newBoolLS);
        }

        puzzleCal = new PuzzleCalculater();
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        Buttons(amount);
	}

    public void Buttons(int amount)
    {
        if (amount == 1)
        {
            button[0] = true;
            lightB[0].GetComponent<MeshRenderer>().material = green;
            Opendoor();
        }

        if (amount == 2)
        {
            button[1] = true;
            lightB[1].GetComponent<MeshRenderer>().material = green;
            Opendoor();
        }

        if (amount == 3)
        {
            button[2] = true;
            lightB[2].GetComponent<MeshRenderer>().material = green;
            Opendoor();
        }
    }

    public void Opendoor()
    {
        puzzleCal.Puzzel(button, lockSwitch, lightB, non, green);
        dooropen = puzzleCal.doorSwitch();
        if (dooropen)
        {
            anim.SetBool("DoorOpen", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            dooropen = false;
            puzzleCal.Puzzel(button, lockSwitch, lightB, non, green);
            anim.SetBool("DoorOpen", false);
        }
    }
}

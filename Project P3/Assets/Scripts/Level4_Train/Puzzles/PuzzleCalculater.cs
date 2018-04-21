using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCalculater
{
    bool door;

    public void Puzzel(List<bool>button, List<bool>lockSwitch,List<GameObject>light , Material non, Material green)
    {
        if (button[0] == true)
        {
            if (button[2] == true && lockSwitch[0] == true && button[1] == false && lockSwitch[1] == false)
            {
                button[0] = false;
                button[2] = false;
                lockSwitch[0] = false;
                light[0].GetComponent<MeshRenderer>().material = non;
                light[2].GetComponent<MeshRenderer>().material = non;
            }
        }

        if (button[1] == true)
        {
            if (button[0] == true && lockSwitch[0] == false)
            {
                button[0] = false;
                button[1] = false;
                lockSwitch[0] = false;
                light[0].GetComponent<MeshRenderer>().material = non;
                light[1].GetComponent<MeshRenderer>().material = non;
            }
        }

        if (button[2] == true)
        {
            if (button[0] == true && lockSwitch[0] == false)
            {
                button[2] = false;
                button[0] = false;
                lockSwitch[0] = false;
                light[2].GetComponent<MeshRenderer>().material = non;
                light[0].GetComponent<MeshRenderer>().material = non;
            }
        }

        if (button[2] == true)
        {
            if (button[1] == true && lockSwitch[1] == false)
            {
                button[2] = false;
                button[1] = false;
                lockSwitch[1] = false;
                light[2].GetComponent<MeshRenderer>().material = non;
                light[1].GetComponent<MeshRenderer>().material = non;
            }
        }


        if (button[0] == true && button[1] == false)
        {
            lockSwitch[0] = true;
        }

        if (button[0] == true && lockSwitch[0] == true && button[1] == true)
        {
            lockSwitch[1] = true;
        }


        if (button[0] == true && lockSwitch[0] == true && button[1] == true && lockSwitch[1] == true && button[2] == true)
        {
            lockSwitch[2] = true;
        }

        if (button[0] == true && lockSwitch[0] == true && button[1] == true && lockSwitch[1] == true && button[2] == true && lockSwitch[2] == true)
        {
            door = true;
            button[0] = false;
            button[1] = false;
            button[2] = false;
            lockSwitch[0] = false;
            lockSwitch[1] = false;
            lockSwitch[2] = false;
        }
    }


    public bool doorSwitch()
    {
        return door;
    }
}


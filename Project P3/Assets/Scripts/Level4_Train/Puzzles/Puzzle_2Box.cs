using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puzzle_2Box : MonoBehaviour
{
    static Animator anim;
    private bool locked;
    private int number;
    private bool allOn;
    [SerializeField] private List<Transform> pressure = new List<Transform>();
    [SerializeField] private List<GameObject> lightS = new List<GameObject>();
    [SerializeField] private List<bool> press = new List<bool>();

    [SerializeField] Material non;
    [SerializeField] Material green;

    private AudioSource audioSourse;
    [SerializeField] private AudioClip doorslide;
    [SerializeField] private float volumeScale;


    void Start ()
    {
        volumeScale = 1f;
        audioSourse = GetComponent<AudioSource>();
        anim =  GetComponent<Animator>();
        locked = false;
        allOn = false;
        lightS[0].GetComponent<MeshRenderer>().material = non;
    }

	void Update ()
    {
        PressurePad(number);
	}

    public void PressurePad(int number)
    {
        if (number == 1)
        {
            press[0] = true;
        }

        if (number == 2)
        {
            press[1] = true;
        }

        if (number == 3)
        {
            press[2] = true;
        }

        if (press[0] && press[1] && press[2])
        {
            if (!locked)
            {
                allOn = true;
                lightS[0].GetComponent<MeshRenderer>().material = green;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!locked && allOn)
            {
                anim.SetBool("DoorOpen", true);
                audioSourse.PlayOneShot(doorslide, volumeScale);
                audioSourse.pitch = 1.5f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (locked)
            {
                audioSourse.PlayOneShot(doorslide, volumeScale);
                audioSourse.pitch = 1f;
                anim.SetBool("DoorOpen", false);
                locked = true;
                allOn = false;
            }
        }
    }
}

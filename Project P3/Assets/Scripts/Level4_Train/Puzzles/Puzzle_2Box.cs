using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puzzle_2Box : MonoBehaviour
{
    [SerializeField] private List<Transform> pressure = new List<Transform>();
    static Animator anim;
    int number;
    [SerializeField] private List<bool> press = new List<bool>();
    private bool locked;

    private AudioSource audioSourse;
    [SerializeField] private AudioClip doorslide;
    [SerializeField] private float volumeScale;


    void Start ()
    {
        volumeScale = 1f;
        audioSourse = GetComponent<AudioSource>();
        anim =  GetComponent<Animator>();
        locked = false;
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
            anim.SetBool("DoorOpen", false);
            locked = true;
            audioSourse.PlayOneShot(doorslide, volumeScale);
            audioSourse.pitch = 1f;
        }
    }
}

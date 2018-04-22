using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpenClose : MonoBehaviour
{
    [HideInInspector]public Animator anim;
    private AudioSource audioSourse;
    [SerializeField] private AudioClip doorslide;
    [SerializeField] private float volumeScale;


    void Start()
    {
        volumeScale = 1f;
        audioSourse = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print(other.transform.name);
            anim.SetBool("DoorOpen", true);
            audioSourse.PlayOneShot(doorslide, volumeScale);
            audioSourse.pitch = 1.5f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            anim.SetBool("DoorOpen", false);
            audioSourse.PlayOneShot(doorslide, volumeScale);
            audioSourse.pitch = 1f;
        }
    }
}

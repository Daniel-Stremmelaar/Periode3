using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Button_Train : MonoBehaviour
{
    [SerializeField] private int number;
    private AudioSource audioSourse;
    [SerializeField] private AudioClip button;
    [SerializeField] private float volumeScale;

    void Start()
    {
        volumeScale = 1f;
        audioSourse = GetComponent<AudioSource>();
    }
    public void Pressed()
    {
        transform.gameObject.GetComponentInParent<PuzzelDoor_Train>().Buttons(number);
        audioSourse.PlayOneShot(button, volumeScale);
    }
}

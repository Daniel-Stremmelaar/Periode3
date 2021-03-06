﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Train_Health_Manager : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float maxHealth;
    public Slider healthSlider;

    [SerializeField] private string loadLevel;

    void Start ()
    {
        currentHealth = maxHealth;
        healthSlider.value = CalculateHealth();
	}

	void Update ()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(loadLevel);
        }
	}

    public float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
    public void HurtPlayer(float damage) // A public void that is for your damage. 
    {
        currentHealth -= damage;
        healthSlider.value = CalculateHealth();
    }
}

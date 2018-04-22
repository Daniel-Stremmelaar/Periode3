using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    [SerializeField] private string loadLevel;
    public bool nextLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(loadLevel);
            nextLevel = true;
        }
    }
}

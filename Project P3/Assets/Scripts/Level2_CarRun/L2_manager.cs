using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class L2_manager : MonoBehaviour
{
    public Button RestartButton;
    public GameObject restartButtonSwitch;
    public Vector3 death;

    
    void Start()
    {
        restartButtonSwitch.SetActive(false);
        death.y = -2;
    }

    void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if (GameObject.FindWithTag("Player").transform.position.y < -2)
        {
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().useGravity = false;
            restartButtonSwitch.SetActive(true);
            RestartButton.onClick.AddListener(Restart);
        }
    }

    public void Restart()
    {
        if (restartButtonSwitch == true)
        {
            SceneManager.LoadScene("Jorrit");
        }
    }

}

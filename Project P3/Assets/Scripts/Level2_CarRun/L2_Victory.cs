using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L2_Victory : MonoBehaviour
{
    public GameObject victoryTextSwitch;
    public Button nextLevel;
    public GameObject nextLevelSwitch;

    void Start()
    {
        victoryTextSwitch.SetActive(false);
        nextLevelSwitch.SetActive(false);
    }

    public void OnCollisionEnter(Collision victory)
    {
        if (victory.gameObject.tag == ("Player"))
        {
            victoryTextSwitch.SetActive(true);
            nextLevelSwitch.SetActive(true);
            nextLevel.onClick.AddListener(NextLevel);
        }
    }

    public void NextLevel()
    {
        Debug.Log("Player has gone to the next level");
    }
}

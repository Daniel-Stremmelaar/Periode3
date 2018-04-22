using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    public GameObject player;
    public GameObject key;
    public bool getKey;

	// Use this for initialization
	void Start () {
        getKey = false;
	}
	
	// Update is called once per frame
	void Update () {
        CheckCardPickup();
        CheckWin();
	}

    public void CheckCardPickup()
    {
        if(player.transform.position.z > -4 && player.transform.position.z < -1 && player.transform.position.x < 2)
        {
            getKey = true;
            Destroy(key, 0.1f);
        }
    }

    public void CheckWin()
    {
        if(getKey == true)
        {
            if(player.transform.position.x > 28 && player.transform.position.z < 4 && player.transform.position.z > 1)
            {
                Time.timeScale = 0;
                print("You win");
            }
        }
    }
}

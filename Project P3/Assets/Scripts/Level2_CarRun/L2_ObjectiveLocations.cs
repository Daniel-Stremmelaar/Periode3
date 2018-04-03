using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ObjectiveLocations : MonoBehaviour {

    public GameObject startObjective;
    public GameObject endObjective;
    public GameObject LObj1;
    public GameObject LObj2;
    public GameObject RObj1;
    public GameObject RObj2;
    public Vector3 leftlocation;

    public void LeftObjective()
    {
        GameObject.Find("RightWall").SetActive(true);
        LObj1.SetActive(true);
        LObj2.SetActive(true);
        RObj1.SetActive(false);
        RObj2.SetActive(false);
        
    }
}



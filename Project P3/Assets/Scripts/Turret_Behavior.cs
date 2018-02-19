using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Behavior : MonoBehaviour {

    private GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
        //clamp rotation between X = 80 and X = 133
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Movement : MonoBehaviour {

    private GameObject target;
    public int speed;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
}

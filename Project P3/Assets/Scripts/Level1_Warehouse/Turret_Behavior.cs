using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Behavior : MonoBehaviour {

    private GameObject target;
    public float time;
    public bool mayFire;
    public GameObject projectile;
    public bool active;
    public GameObject lauchPoint;
    public float activationTime;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Activate());
	}
	
	// Update is called once per frame
	void Update () {
        if (active == true)
        {
            transform.LookAt(target.transform);
            //clamp rotation between X = 80 and X = 133

            if (mayFire == true)
            {
                Instantiate(projectile, lauchPoint.transform.position, Quaternion.identity);
                mayFire = false;
                StartCoroutine(Reload());
            }
        }
	}

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(time);
        mayFire = true;
    }

    public IEnumerator Activate()
    {
        yield return new WaitForSeconds(activationTime);
        active = true;
    }
}

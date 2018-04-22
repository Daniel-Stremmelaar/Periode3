using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Movement : MonoBehaviour {

    private GameObject target;
    public int speed;
    public int damage;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.1f);
        if (collision.gameObject.tag == "Player")
        {
            DoDamage(damage, collision.gameObject);
        }
    }

    public void DoDamage(int dmg, GameObject target)
    {
        target.GetComponent<WinCondition>().hp -= dmg;
    }
}

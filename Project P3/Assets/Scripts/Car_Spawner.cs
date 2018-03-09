using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject car1;
    public bool spawnCheck = true;

    private void Update()
    {
        MaySpawn();
    }
    public void MaySpawn()
    {
        if(spawnCheck == true)
        {
            StartCoroutine(SpawnTime());
            Spawner();
        }
    }
    public void Spawner()
    {
        GameObject g = Instantiate(car1, transform.position, transform.rotation);
        Destroy(g, 15);
        spawnCheck = false;
    }
    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(1);
        spawnCheck = true;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject car1;
    public bool spawnCheck = true;
    public float lifeTime;
    public float spawn;

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
        Destroy(g, lifeTime);
        spawnCheck = false;
    }
    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(spawn);
        spawnCheck = true;
    }
    
}

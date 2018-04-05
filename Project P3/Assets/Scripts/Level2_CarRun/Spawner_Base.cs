using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Base : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    private int random;
    public bool spawnCheck = true;
    public float lifeTime;
    public float spawn;

    void Start()
    {
       
       
    }
    void Update()
    {
        
        random = Random.Range(0, (cars.Count));
       
        MaySpawn();
    }
    public void MaySpawn()
    {
        if (spawnCheck == true)
        {
            StartCoroutine(SpawnTime());
            Spawner();
        }
    }
    public virtual void Spawner()
    {
        GameObject g = Instantiate(cars[random], transform.position, transform.rotation);
        Destroy(g, lifeTime);
        spawnCheck = false;
    }
    public virtual IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(spawn);
        spawnCheck = true;
    }

}

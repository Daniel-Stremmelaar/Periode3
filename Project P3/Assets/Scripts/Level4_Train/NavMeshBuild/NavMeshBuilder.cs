using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBuilder : MonoBehaviour
{
    public NavMeshSurface[] surface;


    void Start()
    {
        for (int i = 0; i < surface.Length; i++)
        {
            surface[i].BuildNavMesh();
        }
    }
}

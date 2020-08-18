using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] _TerrainPrefab;
    public List<GameObject> _PrefabedTerrain;

    // Update is called once per frame
    void Update()
    {
        foreach(obstacle o in _TerrainPrefab)
        {
            if (o._IsInitialized == false)
                o.Init;
        }

        

    }
}

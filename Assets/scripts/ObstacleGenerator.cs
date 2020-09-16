using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] _TerrainPrefab;
    

    public void Init()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
          
        

    }

    private void NewLand()
    {
        if (_TerrainPrefab != null)
        {
            Transform parent = GameObject.Find("map").GetComponent<Transform>();
            GameObject child = Instantiate(_TerrainPrefab[0]);
            child.transform.parent = parent;
            child.transform.position = new Vector3(child.transform.position.x,
                                                   gameObject.transform.position.y
                                                    , child.transform.position.z);
            child.name = "Blocks";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
            
            NewLand();
       
    }

    //1. 지형이 특정 지점을 통과하면
    //2. 새로운 지형 생성
    //3. 그러는 도중 생성된 지형이 특정 지점을 통과하면
    //4. 지형 파괴
}

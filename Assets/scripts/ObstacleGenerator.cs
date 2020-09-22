using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] _TerrainPrefab;

    private GameObject _prevLandPart = null;
    public Vector3 prevPos;

    public void Init()
    {
        _prevLandPart = _TerrainPrefab[0];
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
            int random = UnityEngine.Random.Range(0, 9);
            GameObject prefab = _TerrainPrefab[random];
            GameObject newLand = Instantiate(prefab);
            newLand.transform.parent = parent;
            newLand.AddComponent<Ground>();                       

            prevPos = _prevLandPart.transform.position;
            float offset = UnityEngine.Random.Range(2.0f, 4.0f);
            newLand.transform.position = new Vector3(prevPos.x + Common.LAND_PART_WIDTH + offset, prevPos.y, prevPos.z);
            _prevLandPart = newLand;
        }

        else
        {
            Debug.LogError("프리팹 미부착");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if( collision.gameObject.tag == "Player")
           NewLand();
       
    }

    //1. 지형이 특정 지점을 통과하면
    //2. 새로운 지형 생성
    //3. 그러는 도중 생성된 지형이 특정 지점을 통과하면
    //4. 지형 파괴
}

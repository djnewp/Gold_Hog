using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class scene_base : MonoBehaviour
{
    public GameObject _startpoint;
    public GameObject _player;
    //public GameObject keyprefab;


    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Init()
    {
        GameObject pl = GameObject.Find("guy");
        if (pl == null)

        {
        GameObject p = Instantiate(_player);
        p.name = "guy";
        //canvas = GameObject.Find("Canvas");
        if (p == null)
        {
            Debug.LogError("플레이어 없음");
        }
        Vector3 startPos = _startpoint.transform.position;
        p.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        }


    }

}

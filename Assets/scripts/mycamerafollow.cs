﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycamerafollow : MonoBehaviour
{
    public Transform _target;
    GameObject _pc;

    // Start is called before the first frame update
    public void Init()
    {
        _pc = GameObject.Find("guy");
        _target = _pc.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 charPos = _target.position;

        float camZ = transform.position.z;
        transform.position = new Vector3(charPos.x, charPos.y, camZ);
        
    }
}

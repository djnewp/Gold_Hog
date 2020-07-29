using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamescene : scene_base
{
    mycamerafollow _mycam;
    public UIMng _uIMng;
    
    // Start is called before the first frame update
    public override void Init()
    {
        //카메라 초기화
        base.Init();
        _mycam = Camera.main.GetComponent<mycamerafollow>();
        _mycam.Init();

        //UI 초기화
        _uIMng.Init();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    GameObject _gameobj;
    GameObject _char;
    UIManage _uiManage;
    mainchar _mychar;
    public GameObject _start;
    public mycamerafollow _mycam;

    public GameScreen _gameScreen;

    public GameObject _mapObj;
    public MapMovement _move;
    Animator _anim;
    public Rigidbody2D _maprig;

    [HideInInspector]
    public static GameManage _instance;
    public static GameManage Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(GameManage)) as GameManage;
                if (null == _instance)
                {
                    Debug.LogError("GameManage 가져오기 실패");
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        _gameScreen.Init();

        _mycam.Init();

        _gameobj = GameObject.Find("UIManage");
        _uiManage = _gameobj.GetComponent<UIManage>();
        _move.Init();
        _anim = _char.GetComponent<Animator>();
        obstacle[] obstacleList = _mapObj.GetComponentsInChildren<obstacle>(true);
        foreach (obstacle o in obstacleList)
        o.Init();
        _maprig = GameObject.Find("map").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Respawn()
    {
        Vector3 SP = new Vector3(_start.transform.position.x, _start.transform.position.y, _start.transform.position.z);
        _mychar.transform.position = SP;
        _mychar.OnHeal(_mychar._maxhp);
        _uiManage.Show("HPGauge", true);
        _move.transform.position = _move.StartPos;
        _maprig.bodyType = RigidbodyType2D.Dynamic;
        
        
    }

    public void GameOver()
    {
        _mychar._hp = 0;
        _anim.SetInteger("hp", _mychar._hp);
        _uiManage.Show("ResultScreen", true);
        //게임오버 및 재시작 UI 표시하기

    }
}

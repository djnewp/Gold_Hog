﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class GameManage : MonoBehaviour
{
    UIManage _uiManage;
    mainchar _mychar;
    public GameObject _start;
    public mycamerafollow _mycam;

    public GameScreen _gameScreen;

    public GameObject _mapObj;
    public MapMovement _move;
    Animator _anim;
    Text _gameScore;
    public Rigidbody2D _maprig;
    public naming _name;
    ObstacleGenerator _og;
    public GameObject _btns;

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

    #region 내부로직
    [HideInInspector]
    public bool IsGameOver = false;
    [HideInInspector]
    public float Score;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        _gameScreen.Init();

        _mycam.Init();
        _mychar = mainchar.Instance;

        _uiManage = GameObject.Find("UIManage").GetComponent<UIManage>();
        _move.Init();
        _anim = _mychar.GetComponent<Animator>();
        ObstacleInit();
        _maprig = GameObject.Find("map").GetComponent<Rigidbody2D>();
        _gameScore = GameObject.Find("InGameScore").GetComponent<Text>();

        _og = _move.GetComponent<ObstacleGenerator>();
        _og.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver != true)
        {
            Score += Time.deltaTime * 10;
            _gameScore.text = (Score.ToString("N1") + "m");
            
        }
    }

    public void Respawn()
    {
        float offset = 1.5f;
        Vector3 t = _start.transform.position;
        Vector3 SP = new Vector3(t.x, t.y, t.z);
        _mychar.transform.position = new Vector3 (SP.x+offset, SP.y,SP.z);
        _mychar.OnHeal(_mychar._maxhp);
        _uiManage.Show("HPGauge", true);
        _move.transform.position = t;
        _maprig.bodyType = RigidbodyType2D.Dynamic;
        IsGameOver = false;
        Score = 0;
        _gameScore.enabled = true;
        ObstacleInit();
        _btns.SetActive(true);
        
    }

    public void GameOver()
    {
        _mychar._hp = 0;
        _anim.SetInteger("hp", _mychar._hp);
        _uiManage.Show("ResultScreen", true);
        IsGameOver = true;
        _gameScore.enabled = false;
        _og._prevLandPart = null;
        _og.prevPos = new Vector3(0, transform.position.y, transform.position.z);
        _btns.SetActive(false);
        //게임오버 및 재시작 UI 표시하기

    }

    public void HpRegain()
    {
        _mychar._hp = _mychar._maxhp;
    }

    private void ObstacleInit()
    {
        obstacle[] obstacleList = _mapObj.GetComponentsInChildren<obstacle>(true);
        foreach (obstacle o in obstacleList)
            o.Init();
    }
}

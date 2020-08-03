using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    GameObject _gameobj;
    GameObject _char;
    UIManage _uiManage;
    mainchar _mychar;
    public GameObject _start;
    // Start is called before the first frame update
    void Start()
    {
        _gameobj = GameObject.Find("UIManage");
        _uiManage = _gameobj.GetComponent<UIManage>();
        _char = GameObject.Find("guy");
        _mychar = _char.GetComponent<mainchar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mychar._hp <= 0 || _mychar.transform.position.y <= -6) GameOver();

    }

    public void Respawn()
    {
        Vector3 SP = new Vector3(_start.transform.position.x, _start.transform.position.y, _start.transform.position.z);
        _mychar.transform.position = SP;
    }

    public void GameOver()
    {
        _mychar._hp = 0;
        _uiManage.Show("ResultScreen", true);
        //게임오버 및 재시작 UI 표시하기

    }
}

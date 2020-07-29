using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMng : MonoBehaviour
{

    public GameObject[] _uiList;
    public My2DUserControl _my2duser;
    public GameMng _gamem;
    GameObject player;
    public ui_hpbar[] _HpBars;
    public Slider _slider;

    // Start is called before the first frame update
    public void Init()
    {
        //_slider.value = 1.0f;
        
        for (int i=0; i<_HpBars.Length; i++)
        {
            _HpBars[i].Init();
        }

        HideAll();
        Show("ui_start", true);
        _gamem = FindObjectOfType<GameMng>();
        GameObject ui = null;
        ui_base uiBase = null;

        for (int i =0;i<_uiList.Length;i++)
        {
            ui = _uiList[i];
            uiBase = ui.GetComponent<ui_base>();
            uiBase.Init();
        }
    }

    public void HideAll()
    {
        GameObject ui = null;

        for (int 회 = 0; 회 < _uiList.Length; 회++)
        {

            ui = _uiList[회];
            ui.SetActive(false);
        }

        
    }

    public void OnGameStart()
    {
        player = GameObject.Find("guy");
        _my2duser = player.GetComponent<My2DUserControl>();
        Show("ui_play", true);

    }

    public void GameOver()
    {
        Show("ui_gameover", true);
    }

    public void Restart()
    {
        _gamem.Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ending()
    {
        Show("ui_ending", true);
    }

    public GameObject GetUi(string name)
    {
        GameObject ui = null;
        for (int 회 = 0; 회 < _uiList.Length; 회++)
        {
            ui = _uiList[회];
            if (ui.name == name)
            {
                return ui;
            }
        }

        return null;
    }

    public void initHp(int hp)
    {
        GameObject ui = GetUi("ui_play");
        if(ui != null)
        {
            ui_play uip = ui.GetComponent<ui_play>();
            uip.InitHP(hp);

        }
    }
    public void OnDmg(int hp)
    {
        GameObject ui = GetUi("ui_play");
        if (ui != null)
        {
            ui_play uip = ui.GetComponent<ui_play>();
            uip.InitHP(hp);

        }
    }

    public void Show(string name, bool show)
    {
        HideAll();

        GameObject ui = null;

        for (int 회 = 0; 회 < _uiList.Length; 회++)
        {

            ui = _uiList[회];



            if (ui.name == name)
            {
                Debug.Log(ui.name+ "on? :" + show);
                ui.SetActive(show);
            }
        }
    }
}

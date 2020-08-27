using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    public GameObject[] _uiList;
    GameManage _gamem;

    [HideInInspector]
    public static UIManage _Inst;
    public static UIManage Instance
    {
        get
        {
            if(null == _Inst)
            {
                _Inst = FindObjectOfType(typeof(UIManage)) as UIManage;

                if(null == Instance)
                {
                    Debug.LogError("UIManage 가져오기 실패");
                }
            }
            return _Inst;
        }
        
    }

    
    // Start is called before the first frame update
    public void Init()
    {
        Show("HPGauge", true);
        _gamem = GameManage.Instance;
    }
    public void HideAll()
    {
        
        GameObject ui;

        for (int 회 = 0; 회 < _uiList.Length; 회++)
        {

            ui = _uiList[회];
            ui.SetActive(false);
        }


    }

    public void Show(string name, bool show)
    {
        HideAll();

        GameObject ui;

        for (int 회 = 0; 회 < _uiList.Length; 회++)
        {

            ui = _uiList[회];



            if (ui.name == name)
            {
                Debug.Log(ui.name + "on? :" + show);
                ui.SetActive(show);
            }
        }
    }

    public void Restart()
    {
        _gamem.Respawn();
        
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void ToMenu()
    {
       SceneManager.LoadScene("menuscreen");
        
    }
}

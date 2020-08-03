using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    public GameObject[] _uiList;
    GameManage _gamem;
    
    // Start is called before the first frame update
    void Start()
    {
        Show("HPGauge", true);
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
        SceneManager.GetSceneByName("hog_main");
    }
    // Update is called once per frame
    void Update()
    {
    }
}

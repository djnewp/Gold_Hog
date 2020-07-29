using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ui_play : ui_base
{
    public Text _SndBtn;
    int soundOnOff = 1;
    public GameObject _menuObj;

    public Text _hptext;

    public override void OnButtonClick(GameObject buttonObj)
    {
        base.OnButtonClick(buttonObj);
        if (buttonObj.name == Common.BTN_SET)
        {
            _gameobj.SetActive(true);

        }

        if (buttonObj.name == Common.BTN_SOUND)
        {
            SndOnOff();
        }
        if(buttonObj.name == Common.BTN_LOBBY)
        {
            SceneManager.LoadScene((int)SCENE.LOBBY);
        }

    }

    public override void Init()
    {
        base.Init();

        _menuObj.SetActive(false);

        if (PlayerPrefs.HasKey("sound_onoff")==true)
        {
          soundOnOff = PlayerPrefs.GetInt("sound_onoff");
            string onoff = "";
            if(soundOnOff == 1)
            {
                onoff = "ON";
            }
            if (soundOnOff == 0)
            {
                onoff = "OFF";
            }
            _SndBtn.text = "사운드" + onoff;
        }
    }

    void SndOnOff()
    {

        //PlayerPrefs.GetInt("sound_onoff");

        string onoff = "";

        if(soundOnOff == 1)
        {
            soundOnOff = 0;
            onoff = "OFF";
            PlayerPrefs.SetInt("sound_onoff", 0);
        }

        else if (soundOnOff == 0)
        {
            soundOnOff = 1;
            onoff = "ON";
            PlayerPrefs.SetInt("sound_onoff", 1);
        }

        _SndBtn.text = "사운드"  +  onoff;
    }

    public void InitHP(int hp)
    {
        _hptext.text = hp.ToString();
    }
}

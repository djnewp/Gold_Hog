using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class naming : MonoBehaviour
{
    public string _userID = null;
    InputField _inputField;
    public scoring _scoring;

    // Update is called once per frame

    private void OnEnable()
    {
        Input.imeCompositionMode = IMECompositionMode.Off;
        _inputField = GetComponent<InputField>();
    }

    public void UserNameHasWritten(string userid)
    {
        Debug.Log("IME:" + Input.imeCompositionMode.ToString());

        string temp = _inputField.text;

        Debug.Log("입력 중: " + temp);
        _userID = temp;
    }

    public void UserNameConfirmed(string temp)
    {
        Debug.Log("입력 끝" + temp);
        _userID = temp;
    }

    public void OnButtonClick()
    {
        if (_userID != null)
        {
            using (StreamWriter sw = new StreamWriter("HighScore.txt", true))
            {
                sw.WriteLine(_userID + "," + _scoring.newScore);
            }
            UIManage.Instance.Show("Ranking", true);

        }

        else { Debug.LogError("유저 아이디 가져올 수 없음"); }
    }
}

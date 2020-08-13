using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class naming : MonoBehaviour
{
    string _userID = "";
    InputField _inputField;

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
        using(StreamWriter sw = new StreamWriter("HighScore.txt"))
        {
            sw.WriteLine("Name:" + _userID);
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;


public class WebModule : MonoBehaviour
{

    [HideInInspector]
    public static WebModule _inst;
    public static WebModule Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<WebModule>();
                if (_inst == null)
                {
                    Debug.LogError("퀘스트매니저 없음");
                }
            }

            return _inst;
        }
    }

 

    void Start()
    {
    }


    

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("lname", "하");
        form.AddField("fname", "준영");

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.81:4869/join_proc", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string text = www.downloadHandler.text;
            Debug.Log(text);
            Debug.Log("Form upload complete!");
        }
    }    
  
    public IEnumerator SendHighScore(int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("member_email", "test@gmail.com");
        form.AddField("highScore", score);


        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.81:4869/high_score", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string result = www.downloadHandler.text;

            Debug.Log(result);
        }
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ui_ranking : ui_base
{
    public Text[] _scoreTextList;
    public naming _name;
    public GameObject _Mainscreen;


    public string[] GetScoreList()
    {
        List<string> scoreList = new List<string>();

        string path = "";
#if UNITY_ANDROID
        path = Application.persistentDataPath + "/HighScore.txt";
#else
            path = "HighScore.txt";
#endif




        using (StreamReader sr = new StreamReader(path))
        {
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();

                scoreList.Add(line);
            }
        }

        // 점수 순으로 정렬하기
        scoreList.Sort(CompareScore);


        return scoreList.ToArray();
    }

    int CompareScore(string a, string b)
    {
        //예를들면,
        // a 08-25 10:53, 921
        // b 08-25 11:36, 533

        string[] strList;
        char[] delimiter = { ' ', ','};

        strList = a.Split(delimiter);
        string scoreA = strList[1];

        strList = b.Split(delimiter);
        string scoreB = strList[1];

        float scoreA_number = (float)Convert.ToDouble(scoreA);
        float scoreB_number = (float)Convert.ToDouble(scoreB);



        //return scoreA.CompareTo(scoreB); //오름차순 정렬

        //return scoreB.CompareTo(scoreA); // 내림차순 정렬

        return (int)(scoreB_number - scoreA_number);
    }

    public override void Show(bool Show)
    {
        string[] scoreList = GetScoreList();
        base.Show(Show);        
        for (int i = 0; i < 5; i++)
        {
            if (i < scoreList.Length)
            {                
                _scoreTextList[i].text = scoreList[i]+"m";
            }
            else
            {
                _scoreTextList[i].enabled = false;
            }

        }
    }

}

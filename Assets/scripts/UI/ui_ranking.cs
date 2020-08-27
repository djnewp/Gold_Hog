using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ui_ranking : ui_base
{
    public Text[] _scoreTextList;

    public string[] GetScoreList()
    {
        List<string> scoreList = new List<string>();

        using (StreamReader sr = new StreamReader("HighScore.txt"))
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
        char[] delimiter = { ' ', ',' };

        strList = a.Split(delimiter);
        string scoreA = strList[1];

        strList = b.Split(delimiter);
        string scoreB = strList[1];


        //return scoreA.CompareTo(scoreB); //오름차순 정렬

        return scoreB.CompareTo(scoreA); // 내림차순 정렬
    }

    public override void Show(bool Show)
    {
        base.Show(Show);
        string[] scoreList = GetScoreList();
        for (int i = 0; i < 5; i++)
        {
            if (i < scoreList.Length)
            {
                _scoreTextList[i].text = scoreList[i];
            }
            else
            {
                _scoreTextList[i].enabled = false;
            }

        }
    }
}

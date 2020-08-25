using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserData : MonoBehaviour
{
    [HideInInspector]
    const string USER_NAME  = "_username";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore(float score)
    {
        using (StreamWriter sw = new StreamWriter("HighScore.txt", true))
        {
            sw.WriteLine(USER_NAME + ":" + score);
        }
    }

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

        scoreList.Sort(CompareScore);

        return scoreList.ToArray();
    }

    int CompareScore(string a, string b)
    {
        string[] strList;
        char[] delimiter = {' ' , ':' };

        strList = a.Split(delimiter);
        string scoreA = strList[2];

        strList = b.Split(delimiter);
        string scoreB = strList[2];

        return scoreB.CompareTo(scoreA);
    }
    public void SaveUserId(string userId)
    {
        PlayerPrefs.SetString(USER_NAME, userId);
    }
    public string GetUserId()
    {
        string userId = PlayerPrefs.GetString(USER_NAME);
        return userId;
    }

}

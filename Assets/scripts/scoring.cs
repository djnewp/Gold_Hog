using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class scoring : MonoBehaviour
{
    GameManage _game;
    Text scoreboard;
    int result = 0;
    float highScore = 0;
    float newScore = 0;
    private const string HIGH_SCORE = "old_high_score";
    float compareScore = 0.0f;
    public Text ComparedScore;
    public Text[] HighScores;
    
    [HideInInspector]
    public bool IsRecorded = false;

    public UserData _userData;
    public naming _name;

    // Start is called before the first frame update
    void Start()
    {
        _game = GameManage.Instance;
        scoreboard = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_game.IsGameOver == true)
        {
            scoreboard.text = _game.Score.ToString("N1") + "m";

            if (IsRecorded == false)

            {
                _userData.SaveScore(_game.Score);

                string[] HighScoreBoard = _userData.GetScoreList();
                string userid = PlayerPrefs.GetString("username");
                for (int i = 0; i < 3; i++)
                {
                    if (i < HighScoreBoard.Length)
                        HighScores[i].text = userid + HighScoreBoard[i];

                    else
                    {
                        HighScores[i].enabled = false;
                    }
                }
            }

            else return;

            IsRecorded = true;

        }
    }
}

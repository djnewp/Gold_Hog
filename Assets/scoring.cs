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
<<<<<<< HEAD:Assets/scripts/scoring.cs
    public Text[] HighScores;
    
    [HideInInspector]
    public bool IsRecorded = false;
=======
>>>>>>> parent of 2b241fe... asdf:Assets/scoring.cs


    // Start is called before the first frame update
    void Start()
    {
        _game = GameManage.Instance;
        scoreboard = GetComponent<Text>();
        if (!PlayerPrefs.HasKey(HIGH_SCORE))
        {
            highScore = PlayerPrefs.GetFloat(HIGH_SCORE, compareScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_game.IsGameOver == true)
        {
            scoreboard.text = _game.Score.ToString("N1") + "m";

<<<<<<< HEAD:Assets/scripts/scoring.cs
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

=======
            newScore = _game.Score;
            if (PlayerPrefs.HasKey(HIGH_SCORE))
            {
                highScore = PlayerPrefs.GetFloat(HIGH_SCORE);
                compareScore = Mathf.Max(newScore, highScore);
                if (newScore > highScore)
                {
                    PlayerPrefs.SetFloat(HIGH_SCORE, newScore);
                }
            }

            else
                PlayerPrefs.SetFloat(HIGH_SCORE, newScore);

            

            ComparedScore.text = compareScore.ToString("N1") + "m";
                
>>>>>>> parent of 2b241fe... asdf:Assets/scoring.cs
        }
    }
}

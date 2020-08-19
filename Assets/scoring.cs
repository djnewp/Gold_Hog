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
            string sContents = File.ReadAllText("HighScore.txt", Encoding.Default);
            result = sContents.IndexOf("High Score:");
            if (result == 0)
            {
                scoreboard.text = _game.Score.ToString("N1") + "m";


                using (StreamWriter sw = File.AppendText("HighScore.txt"))
                {
                    sw.WriteLine("High Score:" + _game.Score.ToString("N1"));
                }
            }

            else
            { 

            }
        }
    }
}

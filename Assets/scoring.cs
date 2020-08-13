using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class scoring : MonoBehaviour
{
    GameManage _game;
    Text scoreboard;

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

            using (StreamWriter sw = new StreamWriter("HighScore.txt"))
            {
                sw.WriteLine("High Score:" + _game.Score);
            }
        }
    }
}

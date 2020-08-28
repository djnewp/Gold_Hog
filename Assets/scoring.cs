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
    [HideInInspector]
    public float newScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        _game = GameManage.Instance;
        scoreboard = GetComponent<Text>();

    }

        // Update is called once per frame
  void Update()
   {
     if (_game.IsGameOver == true)
        {


         scoreboard.text = _game.Score.ToString("N1") + "m";
         newScore = _game.Score;

        }
   }
    
}

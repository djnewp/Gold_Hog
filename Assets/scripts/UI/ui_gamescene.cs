﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_gamescene : ui_base
{
    // Start is called before the first frame update
    

    public override void OnButtonClick(GameObject buttonObj)
    {
        base.OnButtonClick(buttonObj);
        SceneManager.LoadScene((int)SCENE.GAME);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : scene_base
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

}

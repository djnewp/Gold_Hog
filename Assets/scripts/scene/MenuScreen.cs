﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("hog_main");
    }
}

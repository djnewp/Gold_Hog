using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_gameover : ui_base
{

    public override void OnButtonClick(GameObject buttonObj)
    {
        base.OnButtonClick(buttonObj);
        if (buttonObj.name == "retry")
        {
            SceneManager.LoadScene(sceneName:"stage01");
        }
    }

}

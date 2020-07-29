using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_gamescene : ui_base
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnButtonClick(GameObject buttonObj)
    {
        base.OnButtonClick(buttonObj);
        SceneManager.LoadScene((int)SCENE.GAME);
    }
}

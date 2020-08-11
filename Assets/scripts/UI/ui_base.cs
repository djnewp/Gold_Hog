using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_base : MonoBehaviour
{

    public SoundManager _sndMng;
    public GameObject _gameobj;
    public GameManage _gameMng;
    // Start is called before the first frame update
    public virtual void Init()
    {
        _sndMng = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnButtonClick(GameObject buttonObj)
    {
        _sndMng.Play("click");

        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class test_lobbyscene : scene_base
{
    public GameObject ekey;
    public GameObject _dialogui;

    //public GameObject canvas;
    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();

        ekey.SetActive(false);
        _dialogui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (ekey.activeSelf == true)
            {
                
                if (_dialogui.activeSelf == true)
                {
                    _dialogui.SetActive(false);

                
                }

                else
                {
                    _dialogui.SetActive(true);
                    UITextTypeWriter uitextype = _dialogui.GetComponentInChildren<UITextTypeWriter>();
                    uitextype.Play();
                }


            }
        }
       
    }

    public void keyshow(actor who, Transform target, Vector3 offset)
    {
        /*ekey = Instantiate(keyprefab) as GameObject;
        ekey.transform.parent = canvas.transform;
        ekey.transform.position = new Vector3(0, 0, 0);*/
        ekey.SetActive(true);

        RectTransform rect = ekey.GetComponent<RectTransform>();
        rect.position = offset + Camera.main.WorldToScreenPoint(target.position);
        Text speak = _dialogui.GetComponentInChildren<Text>(true);
        speak.text = "";

        if (who is NPC)
        {
            NPC npc = who as NPC;
            //NPC npc = (NPC)who;
            string dialog = npc._dialogstr;
            speak.text = dialog;
            
        }
        
    }

    public void keyhide()
    {
        //Destroy(keyprefab);
        ekey.SetActive(false);
    }
    public void dialoghide()
    {
        _dialogui.SetActive(false);
    }
}

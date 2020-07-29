using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_hpbar : MonoBehaviour
{
    public character _char;
    public Image _p;
    public RectTransform _rectT;
    public float offsetY = 10.0f;
    // Start is called before the first frame update
    public void Init()
    {
        _rectT = GetComponent<RectTransform>();

        if (_char == null)
        {
            //GameObject plpref = Resources.Load("guy") as GameObject;
            //GameObject player = Instantiate(plpref);
            //파일을 바로 올릴 수도 있음
            GameObject plchar = GameObject.Find("guy");
            _char = plchar.GetComponent<mainchar>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        float hp = _char._hp;
        float maxhp = _char._maxhp;
        _p.fillAmount = hp / maxhp;

        if (_char.name != "guy")
        {
            Vector3 charpos = _char.transform.position;
            Vector3 scrpos = Camera.main.WorldToScreenPoint(charpos);
            _rectT.position = scrpos + new Vector3(0, offsetY, 0);
        }
        
    }
}

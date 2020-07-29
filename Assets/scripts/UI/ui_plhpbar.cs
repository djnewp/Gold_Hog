using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_plhpbar : MonoBehaviour
{
    public mainchar _mychar;
    public Image _p;
    public RectTransform _rectT;
    public float offsetY = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rectT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float hp = _mychar._hp;
        float maxhp = _mychar._maxhp;

        _p.fillAmount = hp / maxhp;
        Vector3 enempos = _mychar.transform.position;
        Vector3 scrpos = Camera.main.WorldToScreenPoint(enempos);
        _rectT.position = scrpos + new Vector3(0, offsetY, 0);
        
    }
}

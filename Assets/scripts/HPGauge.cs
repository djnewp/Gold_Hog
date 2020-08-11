using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    Image _p;
    mainchar _mychar;

    // Start is called before the first frame update
    void Start()
    {
        _p = gameObject.GetComponentInChildren<Image>();
        _mychar = mainchar.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        float hp = _mychar._hp;
        float maxhp = _mychar._maxhp;
        _p.fillAmount = hp / maxhp;
    }
}

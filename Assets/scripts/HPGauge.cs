using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    mainchar _mainc;
    Image _p;

    // Start is called before the first frame update
    void Start()
    {
        _p = gameObject.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float hp = _mainc._hp;
        float maxhp = _mainc._maxhp;
        _p.fillAmount = hp / maxhp;
    }
}

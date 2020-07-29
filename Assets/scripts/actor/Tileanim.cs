using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tileanim : MonoBehaviour
{
    public SpriteRenderer _renderer;
    public Sprite _spr1;
    public Sprite _spr2;
    float _delta;
    float _span = 0.5f;
    // Update is called once per frame

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _delta += Time.deltaTime;

        if(_delta > _span)
        {
            _renderer.sprite = _spr1;
        }

        if(_delta > _span * 2.0f)
        {
            _renderer.sprite = _spr2;
            _delta = 0.0f;
        }
    }
}

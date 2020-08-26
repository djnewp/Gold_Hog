using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleDrop : obstacle
{
    Rigidbody2D _rigbd;
    [SerializeField] float _gravity = 9.8f;

    //private float _speedY = 0.0f;

    private float _origX = 0.0f;

    public override void Init()
    {
        

        _rigbd = gameObject.GetComponent<Rigidbody2D>();
        _rigbd.bodyType = RigidbodyType2D.Kinematic;
        _move = GameObject.Find("map").GetComponent<MapMovement>();

        base.Init();

        //_speedY = 0.0f;

        _origX = transform.localPosition.x;
    }


    private void Update()
    {
        if(_rigbd.bodyType == RigidbodyType2D.Dynamic )
        {
            Vector3 pos = transform.localPosition;

            transform.localPosition = new Vector3(_origX, pos.y, pos.z);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "guy")
        {
            _rigbd.bodyType = RigidbodyType2D.Dynamic;
        }
    }


    /*
    IEnumerator _MoveY()
    {
        while(true)
        {
            Vector3 pos = transform.position;

            float y = pos.y;

            _speedY += _gravity * Time.deltaTime;

            y -= Time.deltaTime * _speedY;

            transform.position = new Vector3(pos.x, y, pos.z);

            yield return null;
        }
        
    }*/
}

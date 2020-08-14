using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleDrop : obstacle
{
    Rigidbody2D _rigbd;
    [SerializeField] float _gravity;
    //MapMovement _move;

    public override void Init()
    {
        base.Init();

        _rigbd = gameObject.GetComponent<Rigidbody2D>();
        _rigbd.bodyType = RigidbodyType2D.Kinematic;
        
        //_move = GameObject.Find("map").GetComponent<MapMovement>();
        //.gravityScale = 0;
        //bodyType = RigidbodyType2D.Kinematic;
    }

    private void FixedUpdate()
    {
        //_rigbd.AddForce(new Vector2(_move._MoveSpeed, 0));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "guy")
        {

            

        }
    }

}

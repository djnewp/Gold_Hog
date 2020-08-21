using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleDrop : obstacle
{
    Rigidbody2D _rigbd;
    [SerializeField] float _gravity;
    MapMovement _move;

    public override void Init()
    {
        

        _rigbd = gameObject.GetComponent<Rigidbody2D>();
        _rigbd.bodyType = RigidbodyType2D.Kinematic;
        _move = GameObject.Find("map").GetComponent<MapMovement>();
        //.gravityScale = 0;
        //bodyType = RigidbodyType2D.Kinematic;
        base.Init();
    }


    private void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "guy")
        {
            this.transform.Translate(0, transform.position.y * _gravity * Time.deltaTime, 0,Space.World);



        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleDrop : obstacle
{
    Rigidbody2D _rigbd;

    protected override void Start()
    {
        base.Start();

        _rigbd = gameObject.GetComponent<Rigidbody2D>();
        _rigbd.bodyType = RigidbodyType2D.Kinematic;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "guy")
        {
            _rigbd.bodyType = RigidbodyType2D.Dynamic;

        }
    }
}

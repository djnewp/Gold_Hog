using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleDrop : obstacle
{
    Rigidbody2D _rigbd;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            _rigbd = gameObject.GetComponent<Rigidbody2D>();
        }
    }
}

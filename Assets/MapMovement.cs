using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public float _MoveSpeed = 100.0f;
    public float _MoveMax = 20.0f ;
    Rigidbody2D _rigbd;
    GameObject _guy;
    mainchar _char;

    // Start is called before the first frame update
    public void Init()
    {
        _rigbd = gameObject.GetComponent<Rigidbody2D>();
        _guy = GameObject.Find("guy");
        _char = _guy.GetComponent<mainchar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_char._hp>0) Movement();
        else return;

    }

    void Movement()
    {
        _rigbd.AddForce(new Vector2(_MoveSpeed, 0));
        Vector2 vel = _rigbd.velocity;
        float newVelX = Mathf.Min(_MoveSpeed, vel.x);
        newVelX = Mathf.Min(_MoveMax, newVelX);
        _rigbd.velocity = new Vector2(newVelX, vel.y);
    }
}

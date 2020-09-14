using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public float _MoveSpeed = -2.03f;
    public float _MoveMax = 4.11f ;
    Rigidbody2D _rigbd;
    public Vector2 StartPos;

    // Start is called before the first frame update
    public void Init()
    {
        _rigbd = gameObject.GetComponent<Rigidbody2D>();
        StartPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        

    }

    void Movement()
    {
        if (mainchar.Instance._hp > 0)
        {
            if (_rigbd.bodyType == RigidbodyType2D.Static)
                _rigbd.bodyType = RigidbodyType2D.Dynamic;
            
            _rigbd.AddForce(new Vector2(_MoveSpeed, 0));
            
            Vector2 vel = _rigbd.velocity;

            float newVelX = Mathf.Max(_MoveMax, vel.x);
            
            _rigbd.velocity = new Vector2(newVelX, vel.y);
        }

        else
        {
            _rigbd.bodyType = RigidbodyType2D.Static;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rundebilrun : MonoBehaviour
{
    public float _runspd = 20.0f;
    public float _maxspd = 2.0f;
    public Rigidbody2D _rigbd;
    public mainchar _mychar;

    // Update is called once per frame
    void Update()
    {
        _rigbd.AddForce(new Vector2(_runspd, 0));
        Vector2 vel = _rigbd.velocity;
        float newVelX = Mathf.Min(_runspd, vel.x);
        newVelX = Mathf.Max(-1 * _maxspd, newVelX);
        _rigbd.velocity = new Vector2(newVelX, vel.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _mychar.Jump();
        }
    }
}

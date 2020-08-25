using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    public Rigidbody2D _rigbd2;
    public float _height = 100.0f;
    public float _yLimit = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _rigbd2.AddForce(new Vector2(0.0f, _height));

        Vector2 vel = _rigbd2.velocity;

        float limit = Mathf.Min(_yLimit, vel.y);
        _rigbd2.velocity = new Vector2(vel.x, limit);
    }
}

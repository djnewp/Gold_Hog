using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * @class: My2DUserControl
 * @description: 유저의 키 입력 (나중에는 터치 입력까지) 처리
 */
public class My2DUserControl : MonoBehaviour
{
    public Rigidbody2D _rigid;
    public float _moveForce = 10.0f;
    public float _moveMax = 3.0f;
    public mainchar _myChar2D;
    public float _backForce = -3.0f;
    int dmg;
    obstacle Bang;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            _myChar2D.Jump();
        }

        Vector2 vel = _rigid.velocity;
        
        // x축으로의 속도가 _moveMax보다 커지지 않게 한다.
        float newVelX = Mathf.Min(_moveMax, vel.x);

        // x축으로의 속도가 -1 * _moveMax보다 작아지지 않게 한다.
        newVelX = Mathf.Max(-1 * _moveMax, newVelX);

        
        _rigid.velocity = new Vector2(newVelX, vel.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "obstacle")
        {
            Bang = collision.collider.GetComponent<obstacle>();
            dmg = Bang.DmgDeal();
            _rigid.velocity = new Vector2(_backForce, _rigid.position.y);
            _myChar2D.OnDmg(dmg);
            Debug.Log("현재 체력" + _myChar2D._hp);
        }
    }
}

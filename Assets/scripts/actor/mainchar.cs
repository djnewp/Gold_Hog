using System;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using TMPro.EditorUtilities;

#endif
public class mainchar : character
{
    public Rigidbody2D _rigid;
    public Animator _anim;
    public float _jumpForce = 500.0f;
    public float _jumpMax = 350.0f;
    public UIMng _uiM;
    public GameMng _gamem;
    public My2DUserControl _my2dcon;
    public GameObject _guy;
    int jump = 0;

    public AudioSource _jumpSnd;

    // Start is called before the first frame update
    void Start()
    {

        /*if (_uiM == null) 
        {
            GameObject uiMger = GameObject.Find("UIMng");
            _uiM = uiMger.GetComponent<UIMng>();
        }*/

        _hp = _maxhp;
        //_uiM.initHp(_hp);

        //_anim.SetInteger("hp", _hp);
        _my2dcon = FindObjectOfType<My2DUserControl>();
    }

    public void OnDmg(int dmg)
    {
        _hp -= dmg;
        _hp = Math.Max(0, _hp);
        //_hpVal.text = _hp.ToString();
        //_uiM.OnDmg(_hp);
        _anim.SetInteger("hp", _hp);
    }

    public void OnHeal(int heal)
    {
        _hp += heal;
        _hp = Math.Min(_maxhp, _hp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump()
    {
        //if (jump < 3)
        {
            jump++;
            _anim.SetBool("keyJump", true);
            _rigid.AddForce(new Vector2(0.0f, _jumpForce));

            Vector3 vel = _rigid.velocity;
            float limit = Mathf.Min(_jumpMax, vel.y);
            _rigid.velocity = new Vector2(vel.x, limit);
            if (_jumpSnd) _jumpSnd.Play();

        }
       // else return;
    }

    public void Reborn()
    {
        OnHeal(_maxhp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            _anim.SetBool("keyJump", false);
            jump = 0;
        }


    }


    
    }
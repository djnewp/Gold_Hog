using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq.Expressions;
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
    public GameManage _GameMana;
    public My2DUserControl _my2dcon;
    public GameObject _guy;
    public GameObject SP;
    CapsuleCollider2D _StdCol;
    CapsuleCollider2D _SldCol;
    Vector3 startPos;
    //int jump = 0;


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
        _anim.SetInteger("hp", _hp);
        _GameMana = FindObjectOfType<GameManage>();
        _my2dcon = GetComponent<My2DUserControl>();
        SP = GameObject.Find("StartPos");
        startPos = new Vector3(SP.transform.position.x, SP.transform.position.y, SP.transform.position.z);
        _StdCol = gameObject.GetComponent<CapsuleCollider2D>();
        _SldCol = gameObject.GetComponentInChildren<CapsuleCollider2D>();
    }

    public void OnDmg(int dmg)
    {
        _hp -= dmg;
        _hp = Math.Max(0, _hp);
        _anim.SetInteger("hp", _hp);
        if (_hp <= 0)
        {
            _GameMana.GameOver();
        }


    }

    public void OnHeal(int heal)
    {
        _hp += heal;
        _hp = Math.Min(_maxhp, _hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6) OnDmg(_maxhp);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Slide();
            if(Input.GetKey(KeyCode.LeftControl))
            {
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                _SldCol.enabled = false;
                _StdCol.enabled = true;
                _anim.SetBool("onslide", false);
                _anim.SetBool("IsStanding", true);

            }
        }

    }

    public void Jump()
    {
        //if (jump < 3)
        {
            //jump++;
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
        transform.position.Set(startPos.x, startPos.y, startPos.z);
    }

    public void Slide()
    {
        _StdCol.enabled = false;
        _SldCol.enabled = true;
        _anim.SetBool("onslide", true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            _anim.SetBool("keyJump", false);
            //jump = 0;
        }


    }


    
    }
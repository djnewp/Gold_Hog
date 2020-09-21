using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq.Expressions;
using JetBrains.Annotations;
#if UNITY_EDITOR
using TMPro.EditorUtilities;

#endif
public class mainchar : character
{
    public Rigidbody2D _rigid;
    public Animator _anim;
    public float _jumpForce = 500.0f;
    public float _jumpMax = 350.0f;
    public UIManage _uiM;
    public GameManage _GameMana;
    public My2DUserControl _my2dcon;
    public GameObject _guy;
    public GameObject SP;

    public float _backForce = -1.5f;

    CapsuleCollider2D _StdCol;
    CapsuleCollider2D _SldCol;
    obstacle Bang;
    int dmg;
    //int jump = 0;


    public AudioSource _jumpSnd;

    [HideInInspector]
    public static mainchar _instance;
    public static mainchar Instance
    {
        get
        {
            if(null==_instance)
            {
                _instance = FindObjectOfType(typeof(mainchar)) as mainchar;
                if(null ==_instance)
                {
                    Debug.LogError("mainchar 가져오기 실패");
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        /*if (_uiM == null) 
        {
            GameObject uiMger = GameObject.Find("UIMng");
            _uiM = uiMger.GetComponent<UIMng>();
        }*/
        _maxhp = 100;
        _rigid = GetComponent<Rigidbody2D>();
        _hp = _maxhp;
        _anim.SetInteger("hp", _hp);
        _my2dcon = GetComponent<My2DUserControl>();
        _StdCol = gameObject.GetComponent<CapsuleCollider2D>();
        _SldCol = gameObject.transform.Find("SlideCollider").GetComponent<CapsuleCollider2D>();
        _GameMana = GameManage.Instance;
        DontDestroyOnLoad(gameObject);
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
        _anim.SetInteger("hp", _hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp > 0)

        {
            //Move();

            if (transform.position.y <= -6) OnDmg(_maxhp);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Slide();
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                _SldCol.enabled = false;
                _StdCol.enabled = true;
                _anim.SetBool("onslide", false);
                _anim.SetBool("IsStanding", true);

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();

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

        if(collision.gameObject.name == "GameOverLine")
        {
            _GameMana.GameOver();
        }

        if (collision.collider.tag == "obstacle")
        {
            Bang = collision.collider.GetComponent<obstacle>();
            dmg = Bang.DmgDeal();
            _rigid.velocity = new Vector2(_backForce, _rigid.position.y);
            OnDmg(dmg);
            Debug.Log("현재 체력" + _hp);
        }
    }    
}
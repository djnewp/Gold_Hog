using UnityEngine;
#if UNITY_editor
using TMPro.EditorUtilities;
#endif
public class GameMng : MonoBehaviour
{
    public GameObject _guy;
    public UIMng _ui;
    public mainchar _mychar;
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        //_ui = FindObjectOfType<UIMng>();
        _mychar = FindObjectOfType<mainchar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mychar._hp <= 0 || _mychar.transform.position.y <= -6) GameOver();
    }

    public void GameOver()
    {
        //_ui.Show("ui_gameover", true);
    }

    public void Respawn()
    {
        //GameObject sp = _SPList[_curStg];
        //Vector3 pos = sp.transform.position;
        //Vector3 charpos = _guy.transform.position;

        //_guy.transform.position = new Vector3(pos.x, pos.y, charpos.z);
        _mychar.Reborn();
        _ui.Show("ui_play", true);
        _anim.SetBool("restarted", true);



    }

}

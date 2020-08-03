using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage : MonoBehaviour
{
    GameObject _guy;
    Rigidbody2D _rigbd;
    // Start is called before the first frame update
    void Start()
    {
        _guy = GameObject.Find("guy");
        _rigbd = _guy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actor : MonoBehaviour
{
    test_lobbyscene _lobby;
    public Vector3 offset;

    void Start()
    {
        GameObject lobbysceneobj = GameObject.Find("lobbyscene");
        _lobby = lobbysceneobj.GetComponent<test_lobbyscene>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _lobby.keyshow(this, transform, offset);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lobby.keyhide();
        _lobby.dialoghide();
    }
}

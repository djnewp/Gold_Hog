using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public int dmg = 10;
    GameObject _guy;
    float pos;
    float dist = 0;
    public bool _IsInitialized = false;

    public virtual void Init()
    {
        GameObject pl = GameObject.Find("guy");
        if (pl != null)
            _guy = pl;
        else Debug.LogError("_guy is null");
        pos = gameObject.transform.position.x;
        _IsInitialized = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "guy" || collision.collider.name == "GameOverLine")
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public int DmgDeal()
    {
        return dmg;
    }

    private void Update()
    {
        dist = _guy.transform.position.x;
        if(dist - pos > 10.0f)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

}

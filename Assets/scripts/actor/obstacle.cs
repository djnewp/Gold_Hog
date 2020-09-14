using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : Turrain
{
    public int dmg = 10;
    public bool _IsInitialized = false;

    public virtual void Init()
    {
        Vector3 StartPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        gameObject.SetActive(true);
        gameObject.transform.position = StartPos;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "guy" || collision.collider.name == "GameOverLine")
        {
            Gone();
        }
    }

    public int DmgDeal()
    {
        return dmg;
    }

    private void Update()
    {
        if (gameObject.transform.position.x <= -14)
        {
            GameObject g = transform.parent.gameObject;

            if (g.name == "map")
            {
                Gone();
            }

        }
    }

    protected override void Gone()
    {
        gameObject.SetActive(false);
        _IsInitialized = false;
    }
}

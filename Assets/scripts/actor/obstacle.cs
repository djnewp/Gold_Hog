using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : Turrain
{
    public int dmg = 10;
    public bool _IsInitialized = false;

    public virtual void Init()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : Turrain
{
    public int dmg = 10;
    public bool _IsInitialized = false;

    public virtual void Init()
    {
        
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
        if (gameObject.transform.position.x <= -14)
        {
            if(gameObject.name != "Starting")
            {
                Gone();
            }
        }
    }

    protected override void Gone()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public int dmg = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "guy") Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public int DmgDeal()
    {
        return dmg;
    }

}

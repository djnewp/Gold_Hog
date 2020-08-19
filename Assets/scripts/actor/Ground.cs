using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Turrain
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x <= -14)
        {
            GameObject g = transform.parent.gameObject;

            if (g.name == "map")
            {
                Gone();
            }
            else
                gameObject.SetActive(false);
        }
    }

    protected override void Gone()
    {
        Destroy(gameObject);
    }
}

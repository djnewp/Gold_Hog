using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float _movspd;
    public float _destPoint;
    public float _origPoint;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float move = Time.deltaTime * _movspd;
        transform.Translate(new Vector3(move, 0, 0));

        if (pos.x  >_destPoint)
        {
            transform.position = new Vector3(_origPoint, pos.y, pos.z);
        }
    }
}

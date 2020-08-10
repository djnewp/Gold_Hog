using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float _movSpd = 20.0f;
    public GameObject _cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Repeat(-Time.time * _movSpd, 50.0f);
        transform.position = newPosition;


    }
}

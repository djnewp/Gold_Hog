using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float _movSpd = 20.0f;

    public float _startPos;
    public float _endPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Repeat : 0과 두번째 인자 사이를 루프(반복)하는 함수
        float x = Mathf.Repeat(-Time.time * _movSpd, -1 * (_endPos - _startPos));
        Debug.Log("repeat: " + x);

        Vector3 pos = transform.localPosition;
        Vector3 newPosition = new Vector3(_endPos + x, pos.y, pos.z);
        transform.localPosition = newPosition;
    }


}

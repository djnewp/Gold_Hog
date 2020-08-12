using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	float _SpdDefalt;
	private float x;
	public float DestPos;
	public float StartPos;
	GameManage _gamemng;




	// Use this for initialization
	void Start () {
		//StartPos = transform.position.x;
		_gamemng = GameManage.Instance;
		_SpdDefalt = speed;
	}
	
	// Update is called once per frame
	void Update () {


		if (_gamemng.IsGameOver != true)
		{
			speed = _SpdDefalt;
			x = transform.position.x;
			x += speed * Time.deltaTime;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);



			if (x <= DestPos)
			{
				
				//Debug.Log("hhhh");
				x = StartPos;
				transform.position = new Vector3(x, transform.position.y, transform.position.z);
			}

		}

		if (_gamemng.IsGameOver == true)
        {
			speed = 0;
        }
	}
}

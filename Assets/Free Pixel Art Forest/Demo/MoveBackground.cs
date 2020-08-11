using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float DestPos;
	public float StartPos;




	// Use this for initialization
	void Start () {
		//StartPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {


		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= DestPos){

			Debug.Log ("hhhh");
			x = StartPos;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}

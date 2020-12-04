using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController1 : NetworkBehaviour {

	public int Speed = 5;
	public int Sensi = 5;

	GameObject Tank1;
	GameObject Tank2;
	GameObject Tank3;

	GameObject MyTank;

	GameObject Spawn01;
	GameObject Spawn02;
	GameObject Spawn03;
	GameObject Spawn04;
	GameObject Spawn05;
	GameObject Spawn06;

	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public int FirePower = 50;

	public float SpawnX =0f;

//	private Vector3 DirectionDeplacement = Vector3.zero;
//	private CharacterController Player;

	Vector2 lastPos;
	Vector2 currentPos;

	//private Vector3 SherManPos = GameObject.Find("ShermanA");
	Vector3 SherManPos;

	GameObject MonTankPosition;

    // Use this for initialization
    void Start () {
		//Player = GetComponent<CharacterController> ();
		Tank1 	=  GameObject.Find("ShermanA");
		Tank2 	=  GameObject.Find("ShermanB");
		Tank3 	=  GameObject.Find("ShermanC");
		Spawn01 =  GameObject.Find("SpawnPos01");
		Spawn02 =  GameObject.Find("SpawnPos02");
		Spawn03 =  GameObject.Find("SpawnPos03");
		Spawn04 =  GameObject.Find("SpawnPos04");
		Spawn05 =  GameObject.Find("SpawnPos05");
		Spawn06 =  GameObject.Find("SpawnPos06");

//		Debug.Log(Tank1.name);
//		Debug.Log(Tank1.transform.position);
//		Debug.Log(Tank1.transform.position.x);
//		Debug.Log(Tank1.transform.position.y);
//		Debug.Log(Tank1.transform.position.z);
//		Debug.Log(Spawn01.name);
//		Debug.Log(Spawn01.transform.position);
//		Debug.Log(Spawn01.transform.position.x);
//		Debug.Log(Spawn01.transform.position.y);
//		Debug.Log(Spawn01.transform.position.z);
//
//		Debug.Log(this.name);
//		Debug.Log(this.transform.position);
//		Debug.Log(this.transform.position.x);
//		Debug.Log(this.transform.position.y);
//		Debug.Log(this.transform.position.z);

	}

	// Update is called once per frame
	void Update () {

		if (isLocalPlayer) 
		{
//
//			DirectionDeplacement.z = Input.GetAxisRaw ("Vertical");
//			DirectionDeplacement.x = Input.GetAxisRaw ("Horizontal");
//			DirectionDeplacement = transform.TransformDirection (DirectionDeplacement);
//			Player.Move (DirectionDeplacement * Time.deltaTime * Speed);

			transform.Rotate (0, Input.GetAxisRaw ("Mouse X") * Sensi, 0);

			if (this.transform.position.x == Spawn01.transform.position.x) {

							
							
							if(Input.GetKey(KeyCode.UpArrow))
								MyTank.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
				
							if(Input.GetKey(KeyCode.DownArrow))
								MyTank.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
				
							if(Input.GetKey(KeyCode.LeftArrow))
								MyTank.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
				
							if(Input.GetKey(KeyCode.RightArrow))
								MyTank.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			}
			//				MyTank = Tank1;
//
//			if (this.transform.position == Spawn02.transform.position)
//				MyTank = Tank1;
//


		}
	}
}
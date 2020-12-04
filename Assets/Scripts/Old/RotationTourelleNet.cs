﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RotationTourelleNet : NetworkBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;


	void Update ()
	{
		if (isLocalPlayer) 
		{

			if(Input.GetKey(KeyCode.PageDown))
				transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

			if(Input.GetKey(KeyCode.PageUp))
				transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		}
	}
}
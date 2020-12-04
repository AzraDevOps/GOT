﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public Rigidbody projectile;
	public Transform Spawnpoint;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButton(0))
			{
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

			clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*20);
			}
	}

}
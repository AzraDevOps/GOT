using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RotationTourelleNetChar : NetworkBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public GameObject Tourelle;

	void Update ()
	{
		if (isLocalPlayer) 
		{

			if(Input.GetKey(KeyCode.PageDown))
				Tourelle.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

			if (Input.GetKey (KeyCode.PageUp))
				Tourelle.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		}
	}
}
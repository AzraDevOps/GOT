using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RotationTourelleNetChar1 : NetworkBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public GameObject Tourelle;
	public GameObject Canon;

	void Update ()
	{
		if (isLocalPlayer) 
		{

			if(Input.GetKey(KeyCode.PageDown))
				Canon.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

			if (Input.GetKey (KeyCode.PageUp))
			//	Canon.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
				Canon.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);


			if(Input.GetKey(KeyCode.LeftArrow))
				Tourelle.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

			if(Input.GetKey(KeyCode.RightArrow))
				Tourelle.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);


		}
	}
}
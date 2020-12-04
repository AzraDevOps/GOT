using UnityEngine;
using System.Collections;

public class RotationTourelle : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;


	void Update ()
	{
		if(Input.GetKey(KeyCode.PageDown))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.PageUp))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}
}
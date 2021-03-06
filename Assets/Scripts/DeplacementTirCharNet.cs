using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DeplacementTirCharNet : NetworkBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public int FirePower = 50;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;


	void Update ()
	{
		if (isLocalPlayer) 
		{
			if(Input.GetKey(KeyCode.UpArrow))
				transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

			if(Input.GetKey(KeyCode.DownArrow))
				transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

			if(Input.GetKey(KeyCode.LeftArrow))
				transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

			if(Input.GetKey(KeyCode.RightArrow))
				transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

			if (Input.GetKeyDown (KeyCode.Space))
				CmdFire ();
		}
	}

	[Command]
	void CmdFire()
	{
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * FirePower;

		NetworkServer.Spawn (bullet);

		Destroy (bullet, 2.0f);

	}
}
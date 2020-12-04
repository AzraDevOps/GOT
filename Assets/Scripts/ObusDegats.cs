using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObusDegats : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision collision) 
	{

		var hit = collision.gameObject;

		var healthCube = hit.GetComponent<HealthNetCube> ();
		if (healthCube != null) healthCube.TakeDamage (10);
	
		var healthChar = hit.GetComponent<HealthNet> ();
		if (healthChar != null) healthChar.TakeDamage (10);

		Destroy (gameObject);
	}

}

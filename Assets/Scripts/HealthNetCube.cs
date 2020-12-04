using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class HealthNetCube : MonoBehaviour {

	public const int maxHealthCube = 100;

	public RectTransform healthBarCube;

	public int currentHealthCube = maxHealthCube;

	public void TakeDamage(int amount)
	{
		currentHealthCube -= amount;
		healthBarCube.sizeDelta = new Vector2(currentHealthCube , healthBarCube.sizeDelta.y);

		if (currentHealthCube <= 0)
		{
			currentHealthCube = 0;
			Debug.Log("Dead!");
			Destroy(gameObject);
		} 
	


	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour 
{

	// Déclarations pour affecter les GO 
	public GameObject SpwnChauffeur, MyTank, SpwnCanonier, MyTourelle, MyCanon, MyPivotCanon;
	
	// Permets de savoir où est le joueur
	public Button BoutonChauffeur, BoutonCanonnier;
	string MaPosition = ""; 

	// Variables actions du char (déplacement, rotation, tir)
	public float moveSpeedChar = 0f;
	public float turnSpeedChar = 50f;
	public float turnSpeedTourelle = 20f;
	public float turnSpeedHausseCanon = 5f;
	public int FirePower = 50;

	// Variables pour le tir
	public Rigidbody projectile;
	public Transform Spawnpoint;

	// Flags pour le déplacement du char
	private bool enDeplacement = false;
	private bool marcheAvant = false;

	// Use this for initialization
	void Start () 
	{
		TaskOnClickButtonChauffeur(); // On lance le game avec la position CHAUFFEUR par défaut
	} // FIN START

	// Update is called once per frame
	void Update () 
	{

		// Fix d'un bug qui fait qu'on dépasse 50
		if (moveSpeedChar > 50)
			moveSpeedChar = 50;

		if (SpwnChauffeur.active == true)
		{
			SpwnCanonier.SetActive(false);
			MaPosition = "ChauffeurChar";
		}
		if (SpwnCanonier.active == true)
		{
			SpwnChauffeur.SetActive(false);
			MaPosition = "CannonierChar";
		}

		if (MaPosition == "ChauffeurChar") // Si le joueur est CHAUFFEUR
			{
				if (Input.GetKey(KeyCode.UpArrow)) // Si on appuie sur la touche FLECHE HAUT
				{
					if (moveSpeedChar < 50) // Si la vitesse du char est strictement inférieur à 50
					{
						moveSpeedChar = moveSpeedChar + 1; // Le char augmente sa vitesse de 1
					}
					MyTank.transform.Translate(Vector3.forward * moveSpeedChar * Time.deltaTime); // On applique le déplacement au char
					marcheAvant = true; // On mémorise que le char est en marche avant
				}

				if (Input.GetKey(KeyCode.DownArrow)) // Si on appuie sur la touche FLECHE BAS
				{
					if (moveSpeedChar <= 50 && moveSpeedChar > -30) // Si la vitesse du char est strictement inférieur à 50 et strictement supérieure à -30
					{
						moveSpeedChar = moveSpeedChar - 1; // Le char réduit sa vitesse de 1, si sa vitesse arrive à zéro elle passe en -1, -2 etc...
					}
					MyTank.transform.Translate(Vector3.forward * moveSpeedChar * Time.deltaTime);// On applique le déplacement au char
					marcheAvant = false; // On mémorise que le char est en marche arrière
				}

				
				if (Input.GetKey(KeyCode.DownArrow) != true && Input.GetKey(KeyCode.UpArrow) != true) // Si aucunes touches FLECHE HAUT et FLECHE BAS sont appuyées
				{
					if (moveSpeedChar != 0) // Si la vitesse du char est différente de zéro
					{
						if (marcheAvant == true) // Si le char est actuellement en marche avant
						{
							if (moveSpeedChar <= 50 && moveSpeedChar > 0) // Si la vitesse du char est supérieur ou égale à 50 mais strictement supérieure à 0
								moveSpeedChar = moveSpeedChar - 0.25f; // On réduite la vitesse du char de 0.25
						}
						else // Sinon (si le char est en marche arrière)
						{
							if (moveSpeedChar < 0) // Si la vitesse du char est strictement supérieure à 0
								moveSpeedChar = moveSpeedChar + 0.25f; // On réduit la vitesse (de la marche arrière) de 0.25
						}
						MyTank.transform.Translate(Vector3.forward * moveSpeedChar * Time.deltaTime); // On applique le déplacement au char
					}
				}
					
				if (Input.GetKey (KeyCode.LeftArrow)) // Tourne ton char à gauche ben
					MyTank.transform.Rotate (Vector3.up, -turnSpeedChar * Time.deltaTime);

				if (Input.GetKey (KeyCode.RightArrow)) // Tourne ton char à drpite ben
					MyTank.transform.Rotate (Vector3.up, turnSpeedChar * Time.deltaTime);

		} // FIN IF CHAUFFEURCHAR

		if (MaPosition == "CannonierChar") // Si le joueur est CANONIER
		{
			if (Input.GetKey(KeyCode.UpArrow)) // Hausse le canon ben
			{ 
				if (Mathf.Round((MyPivotCanon.transform.rotation.z * 10.0f)) >= -2 || Mathf.Round((MyPivotCanon.transform.rotation.z * 10.0f)) >= 1)
				{
					MyPivotCanon.transform.Rotate(Vector3.right, -turnSpeedHausseCanon * Time.deltaTime);
				}
			}
	
			if (Input.GetKey (KeyCode.DownArrow)) // Baisse le canon ben
			{
				if (Mathf.Round((MyPivotCanon.transform.rotation.z * 10.0f)) >= -2 || Mathf.Round((MyPivotCanon.transform.rotation.z * 10.0f)) >= 1)
				{
					MyPivotCanon.transform.Rotate(Vector3.up, turnSpeedHausseCanon * Time.deltaTime);
				}
			}
		
			if (Input.GetKey(KeyCode.LeftArrow)) // Tourne la tourelle à gauche ben
			{
				MyTourelle.transform.Rotate(Vector3.up, -turnSpeedTourelle * Time.deltaTime);
			}
				
			if(Input.GetKey(KeyCode.RightArrow)) // Tourne la tourelle à droite ben
			{
				MyTourelle.transform.Rotate(Vector3.up, turnSpeedTourelle * Time.deltaTime);
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Rigidbody clone;
				clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

				clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * 20);

				Destroy(clone, 2.0f);
			}

		} // FIN If CANNONIERCHAR

	} // Fin Update

	public void TaskOnClickButtonChauffeur() 
	{
		BoutonChauffeur.GetComponent<Image>().color = Color.yellow;
		BoutonCanonnier.GetComponent<Image>().color = Color.white;
		SpwnCanonier.SetActive(false);
		SpwnChauffeur.SetActive(true);
	}
	
	public void TaskOnClickButtonCanonnier()
	{
		BoutonCanonnier.GetComponent<Image>().color = Color.yellow;
		BoutonChauffeur.GetComponent<Image>().color = Color.white;
		SpwnChauffeur.SetActive(false);
		SpwnCanonier.SetActive(true);
	}
	
	//public void ClicOnButtonChauffeur()
	//{
	//	BoutonChauffeur.GetComponent<Image>().color = Color.yellow;;
	//	SpwnChauffeur.SetActive(false);
	//	SpwnCanonier.SetActive(true);
	//}



} // Fin Script


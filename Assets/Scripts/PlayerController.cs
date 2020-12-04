using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour {

	public int Speed = 5;
	public int Sensi = 5;

	private bool enDeplacement = false;
	private bool marcheAvant = false;
	private bool onDown = false;

	public string MaPosition = "";

	GameObject Tank1, Tank2, Tank3;
	GameObject Tourelle1, Tourelle2 , Tourelle3;
	GameObject Canon1, Canon2, Canon3;
	GameObject PivotCanon1, PivotCanon2, PivotCanon3;

	GameObject Spawn01, Spawn02, Spawn03, Spawn04, Spawn05, Spawn06;

	GameObject MyTank;
	GameObject MyTourelle;
	GameObject MyCanon;
	GameObject MyPivotCanon;

	public float moveSpeedChar = 1f;
	public float turnSpeedChar = 10f;

	public float turnSpeedTourelle = 20f;
	public float turnSpeedHausseCanon = 5f;

	public int FirePower = 50;

    // Use this for initialization
    void Start () 
	{


		//Player = GetComponent<CharacterController> ();
		Tank1 	=  GameObject.Find("Sherman3A");
//		Tank2 	=  GameObject.Find("Sherman3B");
//		Tank3 	=  GameObject.Find("Sherman3C");
		Tourelle1 = GameObject.Find("TourelleA");	
//		Tourelle2 = GameObject.Find("TourelleB");	
//		Tourelle3 = GameObject.Find("TourelleC");
		Canon1 = GameObject.Find("CanonA");	
//		Canon2 = GameObject.Find("CanonB");	
//		Canon3 = GameObject.Find("CanonC");	
		PivotCanon1 = GameObject.Find("PivotCanonA");	
//		PivotCanon2 = GameObject.Find("PivotCanonB");	
//		PivotCanon3 = GameObject.Find("PivotCanonC");	
		Spawn01 =  GameObject.Find("SpawnPos01");
		Spawn02 =  GameObject.Find("SpawnPos02");
//		Spawn03 =  GameObject.Find("SpawnPos03");
//		Spawn04 =  GameObject.Find("SpawnPos04");
//		Spawn05 =  GameObject.Find("SpawnPos05");
//		Spawn06 =  GameObject.Find("SpawnPos06");


//		// ------------------ CHAR 1 -----------------------------------
		if (this.transform.position.x == Spawn01.transform.position.x ||
		    this.transform.position.x == Spawn01.transform.position.y ||
		    this.transform.position.x == Spawn01.transform.position.z) 
		{
			this.transform.parent = Tank1.transform;
			MyTank = Tank1;
			MyTourelle = Tourelle1;
			MyCanon = Canon1;
			MyPivotCanon = PivotCanon1;
			MaPosition = "ChauffeurChar";
//		Spawn01.SetActive (false);
		}
		if (this.transform.position.x == Spawn02.transform.position.x ||
			this.transform.position.x == Spawn02.transform.position.y ||
			this.transform.position.x == Spawn02.transform.position.z) 
		{
			this.transform.parent = Tourelle1.transform;
			MyTourelle = Tourelle1;
			MyCanon = Canon1;
			MyPivotCanon = PivotCanon1;
			MaPosition = "CannonierChar";
		}

//		// ------------------ CHAR 2 -----------------------------------
//		if (this.transform.position.x == Spawn03.transform.position.x ||
//			this.transform.position.x == Spawn03.transform.position.y ||
//			this.transform.position.x == Spawn03.transform.position.z) 
//		{
//			this.transform.parent = Tank2.transform;
//			MyTank = Tank2;
//			MyTourelle = Tourelle2;
//			MyCanon = Canon2;
//			MaPosition = "ChauffeurChar";
//			//				Spawn01.SetActive (false);
//		}
//		if (this.transform.position.x == Spawn04.transform.position.x ||
//			this.transform.position.x == Spawn04.transform.position.y ||
//			this.transform.position.x == Spawn04.transform.position.z) 
//		{
//			this.transform.parent = Tourelle2.transform;
//			MyTourelle = Tourelle2;
//			MyCanon = Canon2;
//			MaPosition = "CannonierChar";
//		}
//
//		// ------------------ CHAR 3 -----------------------------------
//		if (this.transform.position.x == Spawn05.transform.position.x ||
//			this.transform.position.x == Spawn05.transform.position.y ||
//			this.transform.position.x == Spawn05.transform.position.z) 
//		{
//			this.transform.parent = Tank3.transform;
//			MyTank = Tank3;
//			MyTourelle = Tourelle3;
//			MyCanon = Canon3;
//			MaPosition = "ChauffeurChar";
//			//				Spawn01.SetActive (false);
//		}
//		if (this.transform.position.x == Spawn06.transform.position.x ||
//			this.transform.position.x == Spawn06.transform.position.y ||
//			this.transform.position.x == Spawn06.transform.position.z) 
//		{
//			this.transform.parent = Tourelle3.transform;
//			MyTourelle = Tourelle3;
//			MyCanon = Canon3;
//			MaPosition = "CannonierChar";
//		}

	} // FIN START

	// Update is called once per frame
	void Update () 
	{
		

		if (isLocalPlayer) 
		{
			if (MaPosition == "ChauffeurChar") 
			{
				if (Input.GetKey(KeyCode.UpArrow)) // Avance ton char ben
				{
					if (moveSpeedChar < 50)
						moveSpeedChar = moveSpeedChar + 1;
					CmdTranslateTonCharBen(Vector3.forward * moveSpeedChar * Time.deltaTime);

					marcheAvant = true;
				}

				if (Input.GetKey(KeyCode.DownArrow)) // Recule ton char ben
				{

					if (moveSpeedChar <= 50 && moveSpeedChar > -30)
						moveSpeedChar = moveSpeedChar - 1;

					CmdTranslateTonCharBen(Vector3.forward * moveSpeedChar * Time.deltaTime);

					marcheAvant = false;
				}

				
				if (Input.GetKey(KeyCode.DownArrow) != true && Input.GetKey(KeyCode.UpArrow) != true)
				{
					if (moveSpeedChar != 0)
					{
						if (marcheAvant == true)
						{
							if (moveSpeedChar <= 50 && moveSpeedChar > 0)
								moveSpeedChar = moveSpeedChar - 1;

							CmdTranslateTonCharBen(Vector3.forward * moveSpeedChar * Time.deltaTime);
						}
						else
						{
							if (moveSpeedChar < 0)
								moveSpeedChar = moveSpeedChar + 1;

							CmdTranslateTonCharBen(Vector3.forward * moveSpeedChar * Time.deltaTime);
						}
					}
				}

				if (Input.GetKey (KeyCode.LeftArrow)) // Tourne ton char à gauche ben
					CmdRotateTonCharBen (Vector3.up, -turnSpeedChar * Time.deltaTime);

				if (Input.GetKey (KeyCode.RightArrow)) // Tourne ton char à drpite ben
					CmdRotateTonCharBen (Vector3.up, turnSpeedChar * Time.deltaTime);

				//if (Input.anyKeyDown)
				//{
				//	onDown = true;
				//}

				Debug.Log("Touche : " + onDown + " DPL : " + enDeplacement + " MA : " + marcheAvant);
			} // FIN IF CHAUFFEURCHAR

			if (MaPosition == "CannonierChar") 
			{
//				if (Input.GetKey (KeyCode.PageUp)) // Hausse le canon ben
//					MyPivotCanon.transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);
				if (Input.GetKey (KeyCode.UpArrow)) // Hausse le canon ben
					CmdHausseTonCanonBen(Vector3.right, -turnSpeedHausseCanon * Time.deltaTime);

//				if (Input.GetKey (KeyCode.PageDown)) // Baisse le canon ben
//					MyPivotCanon.transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
				if (Input.GetKey (KeyCode.DownArrow)) // Baisse le canon ben
					CmdHausseTonCanonBen(Vector3.right, turnSpeedHausseCanon * Time.deltaTime);

				if(Input.GetKey(KeyCode.LeftArrow)) // Tourne la tourelle à gauche ben
//					MyTourelle.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
					CmdRotateTaTourelleBen (Vector3.up, -turnSpeedTourelle * Time.deltaTime);

				if(Input.GetKey(KeyCode.RightArrow)) // Tourne la tourelle à droite ben
//					MyTourelle.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
					CmdRotateTaTourelleBen (Vector3.up, turnSpeedTourelle * Time.deltaTime);
				
			} // FIN If CANNONIERCHAR

		} // FIN If LOCAL PLAYER

	} // Fin Update

	[Command]
	void CmdRotateTonCharBen (Vector3 VecteurRotateChar, float VitesseRotateChar)
	{
		MyTank.transform.Rotate (VecteurRotateChar, VitesseRotateChar);
	}
	void CmdTranslateTonCharBen (Vector3 VecteurTranslateChar)
	{
		MyTank.transform.Translate (VecteurTranslateChar);
	}
	void CmdRotateTaTourelleBen (Vector3 VecteurRotateTourelle, float VitesseRotateTourelle)
	{
		MyTourelle.transform.Rotate (VecteurRotateTourelle, VitesseRotateTourelle);
	}
	void CmdHausseTonCanonBen (Vector3 VecteurHausseCanon, float VitesseHausseCanon)
	{

		Debug.Log ("Pivot X : " + Mathf.Round( (MyPivotCanon.transform.rotation.x * 10.0f) ));

		if (Mathf.Round( (MyPivotCanon.transform.rotation.x * 10.0f) ) >= -2 || Mathf.Round( (MyPivotCanon.transform.rotation.x * 10.0f) ) >= 1) 
		{
			MyPivotCanon.transform.Rotate (VecteurHausseCanon, VitesseHausseCanon);
		}

	}



//	void CmdTranslateTonCharBen (Vector3 VecteurTranslateChar)
//	{
//		//		MyTank.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
//		MyTank.transform.Translate (VecteurTranslateChar);
//		//		MyTank.GetComponent<NetworkIdentity>().RemoveClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
//		//		MyTank.transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
//	}



}

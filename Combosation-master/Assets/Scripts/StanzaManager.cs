using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanzaManager : MonoBehaviour {
	public GameObject Stanza1;
	public GameObject Stanza2;
	public GameObject Stanza3;
	public GameObject Stanza4;
	public GameObject Couplet;
	public static bool Stanza1Active;
	public static bool Stanza2Active;
	public static bool Stanza3Active;
	public static bool Stanza4Active;
	//public static bool CoupletActive;
	// Use this for initialization
	void Start () {
		Stanza1Active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Stanza1Active == true) {
			Stanza1.SetActive (true);
			Stanza2.SetActive (false);
			Stanza3.SetActive (false);
			Stanza4.SetActive (false);
			//Couplet.SetActive (false);

		}
		if (Stanza2Active == true) {
			Stanza2.SetActive (true);
			Stanza1.SetActive (false);
			Stanza3.SetActive (false);
			Stanza4.SetActive (false);
			//Couplet.SetActive (false);

		}
		if (Stanza3Active == true) {
			Stanza3.SetActive (true);
			Stanza2.SetActive (false);
			Stanza1.SetActive (false);
			Stanza4.SetActive (false);
			//Couplet.SetActive (false);

		}
		if (Stanza4Active == true) {
			Stanza4.SetActive (true);
			Stanza2.SetActive (false);
			Stanza3.SetActive (false);
			Stanza1.SetActive (false);
			//Couplet.SetActive (false);

		}
		//if (CoupletActive == true) {
			//Couplet.SetActive (true);
			//Stanza2.SetActive (false);
			//Stanza3.SetActive (false);
			//Stanza4.SetActive (false);
			//Stanza1.SetActive (false);

		//}
	}
}

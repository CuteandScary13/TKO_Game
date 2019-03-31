using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempInput : MonoBehaviour {
	/*
	 * 
	 * 
	 * Only using this temporarily! 11/13-
	 * 
	 * 
	 */
	public string inputCombo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(inputCombo.Length < 5 )
		{
			if (Input.GetKeyDown (KeyCode.A)) {
				inputCombo += "A";			
				print ("Combo so far:" + inputCombo);


			} else if (Input.GetKeyDown (KeyCode.W)) {
				inputCombo += "W";
				print ("Combo so far:" + inputCombo);


			} else if (Input.GetKeyDown (KeyCode.S)) {
				inputCombo += "S";			
				print ("Combo so far:" + inputCombo);


			} else if (Input.GetKeyDown (KeyCode.D)) {
				inputCombo += "D";
				print ("Combo so far:" + inputCombo);
			}
		}

		if(Input.GetKeyDown(KeyCode.Space) ){
			print ("YOU ENTERED>>"+inputCombo);

			print("Here you go: "+GetComponent<comboManager>().readCombo(inputCombo));
			inputCombo = "";

			//GetComponentInParent<comboReader> ().Source = inputCombo;
			//Debug.Log ("Press [R] to reset: Info>> " + compareCombo (preferedLength, inputCombo, premadeCombos));
			//print ("Press [R] to reset: Info>> " + compareCombo (preferedLength, inputCombo, premadeCombos, comboUsage));
		}
		if(Input.GetKeyDown(KeyCode.R)){
			inputCombo = "";
			print ("reset combo");

		}

	}
}

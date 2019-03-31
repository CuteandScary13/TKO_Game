using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaFourCouplet : MonoBehaviour {

	bool PickedRight;
	//bool PickedWrong;
	string FourthStanza = "So long as men can breathe, or eyes can see,";
	string LastLine4 = "So long lives this, and this gives life to thee. \nTHE END!";

	string One4 = "1.) So long lives this, and this gives life to thee. \nA+A+X+X+UP+RIGHT+A";
	string Two4 = "2.) So long lives thee, and this gives thee to me \nB+B+Up+Left+A";
	string Three4 = "3.) In her tomb by the sounding sea \nX+X+B";
	public float TimeToSwitch;
	// Use this for initialization
	void Start () {
		PickedRight = false;
		//PickedWrong = false;
		//TimeToSwitch = 50;
		ReadPoetry.activeString = FourthStanza;
		SetOptions.optionOneActive = One4;
		SetOptions.optionTwoActive = Two4;
		SetOptions.optionThreeActive = Three4;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("" + TimeToSwitch);
		//if(Input.GetButton("Submit")){
			//ReadPoetry.activeString =FourthStanza;
		//}
		if (COMBOLIST.RomanceCombo3.Check ()) {
			PickedRight = true;
			//Debug.Log ("Hit");
		}
		//if (COMBOLIST.SincereCombo2.Check ()) {
			//PickedWrong = true;
		//}
		//if (COMBOLIST.JokingCombo1.Check ()) {
			//PickedWrong = true;
		//}

		if (PickedRight == true) {
			TimeToSwitch--;
			ReadCorrect.correctString = LastLine4;
			// Debug.Log ("" + PickedRight);

		}
		//if (TimeToSwitch == 0) {
			//ReadCorrect.correctString = "" + "";
		//}
	}
}

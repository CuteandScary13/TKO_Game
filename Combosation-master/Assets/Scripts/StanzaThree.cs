using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaThree : MonoBehaviour {

	bool PickedRight;
	//bool PickedWrong;
	string ThirdStanza = "But thy eternal summer shall not fade,\nNor lose possession of that fair thou ow’st,\nNor shall death brag thou wand’rest in his shade,";
	string LastLine3 = "When in eternal lines to Time thou grow’st.";

	string One3 = "1.) When in herbal lines do Thyme doth grow’st \nB+Y+B+Y+DOWN+RIGHT+B";
	string Two3 = "2.) When in eternal lines to Time thou grow’st \nA+A+X+X+UP+RIGHT+A";
	string Three3 = "3.) May I offer thee a bowl of these oats \nX+X+A+B+DOWN+RIGHT+X";
	public float TimeToSwitch;
	// Use this for initialization
	void Start () {
		PickedRight = false;
		//PickedWrong = false;
		//TimeToSwitch = 50;
		ReadPoetry.activeString = ThirdStanza;
		SetOptions.optionOneActive = One3;
		SetOptions.optionTwoActive = Two3;
		SetOptions.optionThreeActive = Three3;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("" + TimeToSwitch);
		//if(Input.GetButton("Submit")){
			//ReadPoetry.activeString = ThirdStanza;
		//}
		if (COMBOLIST.RomanceCombo3.Check ()) {
			PickedRight = true;
			//Debug.Log ("Hit");
		}
		//if (COMBOLIST.SincereCombo3.Check ()) {
			//PickedWrong = true;
		//}
		//if (COMBOLIST.JokingCombo3.Check ()) {
			//PickedWrong = true;
		//}

		if (PickedRight == true) {
			TimeToSwitch--;
			ReadCorrect.correctString = LastLine3;
			// Debug.Log ("" + PickedRight);

		}
		if (TimeToSwitch == 0) {
			ReadCorrect.correctString = "";
			ReadPoetry.textPercentage = 0;
			//ReadCorrect.textPercentage = 0;
			StanzaManager.Stanza4Active = true;
			StanzaManager.Stanza3Active = false;
		}
	}
}

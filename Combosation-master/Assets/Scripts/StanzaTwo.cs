using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanzaTwo : MonoBehaviour {

	bool PickedRight;
	//bool PickedWrong;
	string SecondStanza = "Sometime too hot the eye of heaven shines,\nAnd often is his gold complexion dimmed;\nAnd every fair from fair sometime declines,";
	string LastLine2 = "By chance, or nature’s changing course, untrimmed;";

	string One2 = "1.) I did not memorize this sonnet, just skimmed \nX+A+DOWN+UP+Y";
	string Two2 = "2.) By chance, Nature’s changing horse, such whims \nB+B+UP+LEFT+A";
	string Three2 = "3.) By chance, or nature’s changing course, untrimmed \nA+X+DOWN+RIGHT+Y";
	public float TimeToSwitch;
	// Use this for initialization
	void Start () {
		PickedRight = false;
		//PickedWrong = false;
		//TimeToSwitch = 50;
		ReadPoetry.activeString = SecondStanza;
		SetOptions.optionOneActive = One2;
		SetOptions.optionTwoActive = Two2;
		SetOptions.optionThreeActive = Three2;
		Debug.Log ("WE STARTED AHH!!");
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Go Update");
		//Debug.Log ("" + TimeToSwitch);

		if (COMBOLIST.RomanceCombo2.Check ()) {
			PickedRight = true;
			Debug.Log ("Hit");
		}
		//if (COMBOLIST.SincereCombo2.Check ()) {
			//PickedWrong = true;
		//}
		//if (COMBOLIST.JokingCombo2.Check ()) {
			//PickedWrong = true;
		//}

		if (PickedRight == true) {
			TimeToSwitch--;
			ReadCorrect.correctString = LastLine2;
			// Debug.Log ("" + PickedRight);

		}
		if (TimeToSwitch == 0) {
			ReadCorrect.correctString = "";
			ReadPoetry.textPercentage = 0;
			//ReadCorrect.textPercentage = 0;
			StanzaManager.Stanza3Active = true;
			StanzaManager.Stanza2Active = false;
		}
	}
}


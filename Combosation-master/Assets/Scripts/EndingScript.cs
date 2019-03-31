using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {
	public Text endText;
	public TextAsset EndDialogue;
	public string[] textLines;
	public int currentLine;

	public Animator sakiFace;
	public GameObject saki;
	// Use this for initialization
	void Start () {
		if (EndDialogue != null) {
			textLines = (EndDialogue.text.Split ('\n'));
		}
		sakiFace = saki.GetComponent<Animator> ();

		if (comboReader.statChecker <= -24) {
			//F RANK
			currentLine = 38;
		}
		if (comboReader.statChecker > -24 && comboReader.statChecker <= 9) {
			//D RANK
			currentLine = 31;
		}
		if (comboReader.statChecker > 8 && comboReader.statChecker <= 24) {
			//C RANK
			currentLine = 24;
		}
		if (comboReader.statChecker > 24 && comboReader.statChecker <= 40) {
			//B RANK
			currentLine = 16;
		}
		if (comboReader.statChecker > 40 && comboReader.statChecker <= 56) {
			//A RANK
			currentLine = 9;
		}
		if (comboReader.statChecker > 56 && comboReader.statChecker <= 72) {
			//S RANK
			currentLine = 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		endText.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.RightArrow)||(Input.GetKeyDown(KeyCode.Space))) {
			currentLine++;
		}



		if (currentLine == 2 || currentLine == 3 || currentLine == 9 || currentLine == 10) {
			sakiFace.Play ("blush");
		}
		if (currentLine == 4 || currentLine == 11) {
			sakiFace.Play ("love");
		}
		if (currentLine == 5 || currentLine == 12 || currentLine == 18 || currentLine == 20) {
			sakiFace.Play ("happy");
		}
		if (currentLine == 16 || currentLine == 17 || currentLine == 26 || currentLine == 27) {
			sakiFace.Play ("neutral");
		}
		if(currentLine == 24 || currentLine == 25 || currentLine == 31 || currentLine == 32){
			sakiFace.Play ("mehREACT");
		}
		if (currentLine == 33 || currentLine == 34 || currentLine == 38 || currentLine == 39 || currentLine == 40) {
			sakiFace.Play ("unimpressed");
		}
		if (currentLine == 41) {
			sakiFace.Play ("angry");
		}

		if (currentLine == 6) {
			sakiFace.Play ("Srank");
		}
		if (currentLine == 13) {
			sakiFace.Play ("Arank");
		}
		if (currentLine == 21) {
			sakiFace.Play ("Brank");
		}
		if (currentLine == 28) {
			sakiFace.Play ("Crank");
		}
		if (currentLine == 35) {
			sakiFace.Play ("Drank");
		}
		if (currentLine == 42) {
			sakiFace.Play ("Frank");
		}

		if (currentLine == 7 || currentLine == 14 || currentLine == 22 || currentLine == 29 || currentLine == 36 || currentLine == 43) {
			SceneManager.LoadScene ("MasterScene");
		}
	}
}

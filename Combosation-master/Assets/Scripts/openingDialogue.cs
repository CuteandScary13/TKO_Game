using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class openingDialogue : MonoBehaviour {
	public GameObject textBox;
	public Text theText;



	public TextAsset textFile;
	public string[] textLines;
	public int currentLine;
	public int lastLine;

	public GameObject button;

	public ButtonSelection selectionScript;
	public AudioSource select;
	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		button.SetActive(false);
		select = GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void Update () {
			theText.text = textLines [currentLine];
		lastLine = textLines.Length;
		string s = textLines [currentLine];
		if (s.Contains ("Saki")) {//check if string contains a word*
			theText.color = Color.black;
		} else {
			theText.color = Color.white;
		}
		if (s.Contains ("C O M B O S A T I O N")) {
			Application.LoadLevel ("dellapisoundscene");
			button.SetActive(true);
		} 

//		if((currentLine>10)&&(selectionScript.sadnessBar.value>50)&&(selectionScript.sadnessBar.value>selectionScript.friendlyBar.value)){
//			theText.text="I'm really sad.";
//		}
//		if((currentLine>10)&&(selectionScript.lovelyBar.value>50)&&(selectionScript.lovelyBar.value>selectionScript.friendlyBar.value)){
//			theText.text="Maybe the right fighter was right in front of me all along...";
//		}
//		if((currentLine>10)&&(selectionScript.friendlyBar.value>50)&&(selectionScript.friendlyBar.value>selectionScript.lovelyBar.value)){
//			theText.text="Ya know, you are always there for me!";
//		}

		if (Input.GetKeyDown (KeyCode.Space)) {
				currentLine += 1;
			select.Play ();
			}

			
		if(Input.GetKeyDown(KeyCode.RightArrow)&& currentLine==lastLine){	
			currentLine=0;
		}
		}
	}


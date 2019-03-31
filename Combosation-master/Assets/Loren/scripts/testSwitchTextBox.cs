using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testSwitchTextBox : MonoBehaviour {
	public Text questionText;
	public Text dialogueText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			switchTextBoxes ();
			print ("weswitched!");
		}
	}
	public void switchTextBoxes(){//A=Question, b= dialogue
		if(questionText.gameObject.activeInHierarchy ==true){
			questionText.gameObject.SetActive(false);
			dialogueText.gameObject.SetActive(true);
		}
		else{
			questionText.gameObject.SetActive(true);
			dialogueText.gameObject.SetActive(false);
		}
	}
}

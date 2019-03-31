using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endSceneFinal : MonoBehaviour {

	public GameObject grade;
	public GameObject medal;

	public Sprite S;
	public Sprite A;
	public Sprite B;
	public Sprite C;
	public Sprite D;
	public Sprite F;
	public Sprite chatMedal;
	public Sprite flatterMedal;
	public Sprite flirtMedal;
	public Sprite jokeMedal;

	public Text gradeText;
	public Text medalText;
	public Text textText;

	float gradeTimer = 1f;
	float medalTimer = 2f;
	float textTimer = 3f;

	bool gradeSet;
	bool medalSet;
	bool textSet;

	public AudioSource gradeMedalSource;
	public AudioSource textSource;

	// Use this for initialization
	void Start () {

		//comboReader.statChecker = 60;
		//comboReader.mostUsedInput = 3;


	}
	
	// Update is called once per frame
	void Update () {
		gradeTimer -= Time.deltaTime;
		medalTimer -= Time.deltaTime;
		textTimer -= Time.deltaTime;

		if (gradeTimer <= 0 && gradeSet == false) {
			if (comboReader.statChecker <= -24) {
				//F RANK
				grade.GetComponent<SpriteRenderer> ().sprite = F;
				gradeText.text = "You got an F!  Ouch...";

			}
			if (comboReader.statChecker > -24 && comboReader.statChecker <= 9) {
				//D RANK
				grade.GetComponent<SpriteRenderer> ().sprite = D;
				gradeText.text = "You got a D!  You need some practice.";
			}
			if (comboReader.statChecker > 8 && comboReader.statChecker <= 24) {
				//C RANK
				grade.GetComponent<SpriteRenderer> ().sprite = C;
				gradeText.text = "You got a C!  Could be worse.";
			}
			if (comboReader.statChecker > 24 && comboReader.statChecker <= 40) {
				//B RANK
				grade.GetComponent<SpriteRenderer> ().sprite = B;
				gradeText.text = "You got a B!      Not bad.";
			}
			if (comboReader.statChecker > 40 && comboReader.statChecker <= 56) {
				//A RANK
				grade.GetComponent<SpriteRenderer> ().sprite = A;
				gradeText.text = "You got an A!  Great job!";
			}
			if (comboReader.statChecker > 56 && comboReader.statChecker <= 72) {
				//S RANK
				grade.GetComponent<SpriteRenderer> ().sprite = S;
				gradeText.text = "You got an S!  That's amazing!";
			}
			gradeMedalSource.Play ();
			gradeSet = true;
		}
	//---------------------------------------
		if (medalTimer <= 0 && medalSet == false) {
			if (comboReader.mostUsedInput == 0) {
				medal.GetComponent<SpriteRenderer> ().sprite = chatMedal;
				medalText.text = "You were talkitive!";
			}
			if (comboReader.mostUsedInput == 1) {
				medal.GetComponent<SpriteRenderer> ().sprite = flatterMedal;
				medalText.text = "You were flattering!";
			}
			if (comboReader.mostUsedInput == 2) {
				medal.GetComponent<SpriteRenderer> ().sprite = jokeMedal;
				medalText.text = "You were a jokester!";
			}
			if (comboReader.mostUsedInput == 3) {
				medal.GetComponent<SpriteRenderer> ().sprite = flirtMedal;
				medalText.text = "You were flirty!";
			}
			gradeMedalSource.Play ();
			medalSet = true;
		}
	
	//----------------------------------------
		if (textTimer <= 0 && textSet == false) {
			textText.text = "Press Space to return to the main menu";
			textSource.Play ();
			textSet = true;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("titleScreen");
		}
	}
}

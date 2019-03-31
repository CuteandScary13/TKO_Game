using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInput : MonoBehaviour {
	public bool usingComboReader;

	public string inputCombo="";//store inputCombo as the player puts 



//	public GameObject happyFace, sadFace, loveFace;
//	public GameObject flatter, joke, wink, chat, neutral;
//	public Text meterText;
	public Text timeText;
	public Text iTExt;
	public Text DictrionaryText;

	public GameObject notepad;

	public float Timer;
	public float TimerLength;

	int buttonSlotSelection = 0;//slot of the button "dialogue bar"


	public bool canPlayerSpeak = true;//controls when the player can input a combo
	public bool StopButtons;
	public bool resetSlots = false;
	bool lengthChimePlayed; //detects if the sound for combo length has already played
	public int preferedLength;
	public int maxUsage;//max usage of a combo before "overused"

	List<Combo> comboUsage = new List<Combo> ();

	public Sprite blankSlotSprite; //sprites and array to control the button icons
	public Sprite flatterSlotSprite;
	public Sprite flirtSlotSprite;
	public Sprite chatSlotSprite;
	public Sprite jokeSlotSprite;
	public Sprite spaceOff;
	public Sprite spaceOn;
	public GameObject [] buttonSlots;
	public GameObject spaceButton;
	public GameObject dots;
	public GameObject notepadIcon;
	//public soundScript audio;
	public AudioSource buttonSoundSource;
	public AudioSource musicSource;
	public AudioSource comboInputSource;
	public AudioSource notepadSource;
	public AudioClip flatterSound;
	public AudioClip flirtSound;
	public AudioClip chatSound;
	public AudioClip jokeSound;
	public AudioClip music;
	public AudioClip comboReadySound;
	public AudioClip comboInputSound;
	public AudioClip notepadOpen;
	public AudioClip notepadClose;
	public Animator heartAnimator;


	int i = 8;//keeps track of space button action
	int index=0;

	//Dictionary<string, int> comboUsage;
	// Use this for initialization
	void Start () {
		
		Timer = 8;

		musicSource.Play ();
		canPlayerSpeak = true; 
		dots.SetActive (false);

		notepad.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (canPlayerSpeak);

		heartAnimator.Play ("heartBreaker", 0, 1 - Timer / TimerLength);

	
		//Get player input. 
		if (canPlayerSpeak == true ) {
			if(inputCombo.Length < 5  && i ==1  )
			{
				if (Input.GetKeyDown (KeyCode.A)) {
					inputCombo += "A";
					buttonSoundSource.clip = flatterSound;
					buttonSoundSource.Play ();
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = flatterSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.W)) {
					inputCombo += "W";
					buttonSoundSource.clip = chatSound;
					buttonSoundSource.Play ();
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = chatSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					inputCombo += "S";
					buttonSoundSource.clip = jokeSound;
					buttonSoundSource.Play ();
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = jokeSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.D)) {
					inputCombo += "D";
					buttonSoundSource.clip = flirtSound;
					buttonSoundSource.Play ();
					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = flirtSlotSprite;
					buttonSlotSelection++;
				}
			}
			if(Input.GetKeyDown(KeyCode.Space) ){

				if (i == 0) {
					if(usingComboReader==true){
						GetComponent<comboReader> ().switchTextBoxes ();//this means we should initialize question off.
						GetComponent<comboReader> ().callQuestion ();
					}else{
						GetComponent<tutorialReader> ().switchTextBoxes ();//this means we should initialize question off.
						GetComponent<tutorialReader> ().callQuestion ();
					}

					i = 1;
				} else if (i == 1 && inputCombo.Length >= 3) { //this prevents the player from entering a combo till it's at least 3
					comboInputSource.clip = comboInputSound;
					comboInputSource.Play ();

					//canPlayerSpeak = false;
					//readCombo was being called multiple times, setting it to nothing (reset)
					if (usingComboReader == true) {
						GetComponent<comboReader> ().switchTextBoxes ();
						GetComponent<comboReader> ().callDialogue (GetComponent<comboManager> ().readCombo (inputCombo));
						GetComponent<comboReader> ().readCombo (inputCombo);
					}else
					{
						GetComponent<tutorialReader> ().switchTextBoxes ();
						GetComponent<tutorialReader> ().callDialogue (GetComponent<comboManager> ().readCombo (inputCombo));
						GetComponent<tutorialReader> ().readCombo (inputCombo);	
					}
						Timer = TimerLength;
					i = 0;
					resetSlots = true;
				} else if (i == 8) {//starts here.
					if(usingComboReader==true){
						GetComponent<comboReader> ().callQuestion ();
					}
					else{
						GetComponent<tutorialReader> ().callQuestion ();
					}

					resetSlots = true;
					i = 1;
				}


			}

			if (inputCombo.Length >= 3) { 
				//this changes the space button ui
				spaceButton.GetComponent<SpriteRenderer> ().sprite = spaceOn;
				if (lengthChimePlayed == false) { //plays sound but only once
					comboInputSource.clip = comboReadySound;
					comboInputSource.Play ();
					lengthChimePlayed = true;
				}
			} else if (inputCombo.Length < 3) {
				spaceButton.GetComponent<SpriteRenderer> ().sprite = spaceOff;
				lengthChimePlayed = false;
			}

			if (i == 1 && inputCombo.Length == 0) {
				dots.gameObject.SetActive (true);
			} else {
				dots.gameObject.SetActive (false);
			}

			
			if (Input.GetKeyDown (KeyCode.J)) {
				if (
					notepad.gameObject.activeInHierarchy == true

				) {
					notepadSource.clip = notepadClose;
					notepadSource.Play ();
					notepad.gameObject.SetActive(false);
					notepadIcon.gameObject.SetActive (true);


				} else {
					notepad.gameObject.SetActive(true);
					notepadSource.clip = notepadOpen;
					notepadSource.Play ();
					notepadIcon.gameObject.SetActive (false);

					DictrionaryText.text = ""+ GetComponent<comboManager> ().displayDictionary (true); 
				}
			}
			if(Input.GetKeyDown(KeyCode.L)){//move forwards
				DictrionaryText.text= GetComponent<comboManager> ().displayDictionary (true);
			}
			if(Input.GetKeyDown(KeyCode.K)){//move backwards
				DictrionaryText.text=GetComponent<comboManager> ().displayDictionary (false);
			}
//			
		else { 
			if(Input.GetKeyDown(KeyCode.Space) && canPlayerSpeak == false){ 
				resetSlots = true;

				timeText.text = "" + Mathf.Floor (Timer);
				Timer = TimerLength;
				inputCombo = "";

			}
		}

		if (resetSlots == true) {
			buttonSlots [0].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [1].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [2].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [3].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlots [4].GetComponent<SpriteRenderer> ().sprite = blankSlotSprite;
			buttonSlotSelection = 0;
			resetSlots = false;
		}

		timeText.text = "" + Mathf.Floor (Timer);
	
			if (Timer >= 0 && i == 1) {
			Timer -= Time.deltaTime;
			//	
		}
		if (Timer < 0) {
				if(usingComboReader==true){GetComponent<comboReader> ().annoyanceCounter++;}
				else{
					GetComponent<tutorialReader> ().annoyanceCounter++;
				}
			
			
				Timer = 10;
		}
	}

}
}






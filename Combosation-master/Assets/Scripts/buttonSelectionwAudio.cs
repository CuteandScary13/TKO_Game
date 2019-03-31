using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSelectionwAudio : MonoBehaviour
{
	 int MaxButtons;
	//max number of buttons needed to be pressed for this instance
	 int ButtonsPressed;
	//number of buttons that have been pressed
	 float Timer;
	 float TimeToChange;
	//time players have to press buttons
	 int RoundNumber;

	public Text timeText;
	//the timer text display
	public Text meterText;
	 bool StopButtons; //determines whether the player can input stuff

	public GameObject roundButton;
	float sadUp, loveUp, friendUp, sadChange, friendChange, loveChange;
	public Slider sadnessBar,lovelyBar,friendlyBar;//sliders for the bars

	public soundScript sound;
	public AudioClip flatterSound;
	public AudioClip winkSound;
	public AudioClip chatSound;
	public AudioClip jokeSound;
	public AudioClip endSound;
	public AudioClip music;
	public AudioClip endMusic;

	float buttonPitch = 1;
	float baseButtonPitch;

	public GameObject happyFace, sadFace, loveFace;
	public GameObject flatter, joke, wink, chat, neutral;

	public Sprite blankSprite; //sprites and array to control the button icons
	public Sprite flatterSprite;
	public Sprite winkSprite;
	public Sprite chatSprite;
	public Sprite jokeSprite;
	public GameObject [] buttons;	

	bool resetIcons = false; //sets the button icons back to blank

	bool clearButtons=false;//clears previous player inputs

	bool playedEndAudio = false; //this is some caveman shit to make the round end audio work



	// Use this for initialization
	void Start ()
	{
		sound.Play (music);
		MaxButtons = 3;
		StopButtons = false;
		RoundNumber = 1;
		TimeToChange = 2f;
		Timer = 11f;
		//baseButtonPitch = audioButton.pitch;

		//		RoundNumber = 1;


		happyFace.SetActive (false);
		sadFace.SetActive (false);
		loveFace.SetActive (false);

		roundButton.SetActive (false);

		flatter.SetActive (false);
		joke.SetActive (false);
		wink.SetActive (false);
		chat.SetActive (false);
		neutral.SetActive (true);

		buttons [3].GetComponent<SpriteRenderer> ().enabled = false;
		buttons [4].GetComponent<SpriteRenderer> ().enabled = false;

	}

	// Update is called once per frame
	void Update ()
	{


		Debug.Log ("" + TimeToChange);

		sadnessBar.value = sadChange;
		lovelyBar.value = loveChange;
		friendlyBar.value = friendChange;

		if((sadnessBar.value>75)&&(sadnessBar.value>friendlyBar.value)){
			meterText.text="I'm really sad.";
			sadFace.SetActive (true);
			happyFace.SetActive (false);
			loveFace.SetActive (false);
		}
		if((lovelyBar.value>50)&&(lovelyBar.value>friendlyBar.value)&&(sadnessBar.value<50)){
			meterText.text="Maybe the right fighter was right in front of me all along...";
			loveFace.SetActive (true);
			happyFace.SetActive (false);
			sadFace.SetActive (false);
		}
		if((friendlyBar.value>50)&&(friendlyBar.value>lovelyBar.value)){
			meterText.text="Ya know, you are always there for me!";
			happyFace.SetActive (true);
			sadFace.SetActive (false);
			loveFace.SetActive (false);
		}
		if(Input.anyKey==false){
			clearButtons=true;
		}
		if (clearButtons == true) {
			flatter.SetActive (false);
			joke.SetActive (false);
			chat.SetActive (false);
			wink.SetActive (false);
			neutral.SetActive (true);
		}


		sadUp = Mathf.Clamp(sadUp, 0f, 100f);
		sadChange = Mathf.Clamp(sadChange, 0f, 100f);
		loveUp = Mathf.Clamp(loveUp, 0f, 100f);
		loveChange = Mathf.Clamp(loveChange, 0f, 100f);
		friendUp = Mathf.Clamp(friendUp, 0f, 100f);
		friendChange = Mathf.Clamp(friendChange, 0f, 100f);

		if (RoundNumber == 1) {
			MaxButtons = 3;
			//Timer = 16f;
		}
		if (RoundNumber == 2) {
			MaxButtons = 3;
			//Timer = 16f;
		}
		if (RoundNumber == 3) {
			MaxButtons = 3;
			//Timer = 16f;
		}
		if (RoundNumber == 4) {
			MaxButtons = 4;
			buttons [3].GetComponent<SpriteRenderer> ().enabled = true;
			//Timer = 11f;
		} 
		if (RoundNumber == 5) {
			MaxButtons = 4;
			//Timer = 11f;
		}
		if (RoundNumber == 6) {
			MaxButtons = 5;
			buttons [4].GetComponent<SpriteRenderer> ().enabled = true;

			//Timer = 6f;
		}


		Debug.Log ("" + StopButtons);
		//meterText.text = "Sad: " + DisplaySad + "\nFriend: " + DisplayFriend + "\nLove: " + DisplayLove;
		//Mathf.Round (Timer);
		timeText.text = "Time: " + Mathf.Floor (Timer); //rounds the timer display so thta you dont see shitty decimals
		if (Timer >= 0) {

			Timer -= Time.deltaTime;
		}


		//if (StopButtons == false) {
		if (Input.GetKeyDown (KeyCode.W) && StopButtons == false) { //Chat. ups friend by 1, lowers love by 1, lowers sad by 1
			sound.Play(chatSound);
			//buttonPitch+=0.075f;
			buttons [ButtonsPressed].GetComponent<SpriteRenderer> ().sprite = chatSprite;
			ButtonsPressed++;
			//friend++;
			//love--;
			//sad--;
			clearButtons = false;
			neutral.SetActive (false);
			chat.SetActive(true);

			friendUp+=10;
			//loveUp -= 5;
			sadUp -= 5;
		}
		if (Input.GetKeyDown (KeyCode.A) && StopButtons == false) { //Compliment. Ups love meter by 2, lowers sad by 1
			
			sound.Play(flatterSound);
			buttons [ButtonsPressed].GetComponent<SpriteRenderer> ().sprite = flatterSprite;
			ButtonsPressed++;
			//love += 2;
			//sad--;
			loveUp += 10;
			sadUp -= 5;
			flatter.SetActive (true);
			neutral.SetActive (false);
			clearButtons = false;

			if (sadnessBar.value >= 50) {
				sadUp += 5;
			}

		}


		if (Input.GetKeyDown (KeyCode.S) && StopButtons == false) { //Joke. Ups friend meter 2, lowers sad by 1
			
			sound.Play(jokeSound);
			buttonPitch+=0.075f;
			buttons [ButtonsPressed].GetComponent<SpriteRenderer> ().sprite = jokeSprite;
			ButtonsPressed++;
			//friend += 2;
			//sad--;
			//friendliness+=friendUp;
			//sadness -= friendDown;
			joke.SetActive(true);
			neutral.SetActive (false);
			clearButtons = false;
			friendUp += 10;
			sadUp -= 10;

		}

		if (Input.GetKeyDown (KeyCode.D) && StopButtons == false) { //Wink. Ups sad and love by 1
			sound.Play(winkSound);

			buttons [ButtonsPressed].GetComponent<SpriteRenderer> ().sprite = winkSprite;
			ButtonsPressed++;
			//sad++;
			//love++;
			//sadness+=sadUp;
			//loveliness += loveUp;
			wink.SetActive(true);
			neutral.SetActive (false);
			clearButtons = false;
			if (sadnessBar.value < 75) {
				loveUp += 20;
				friendUp -= 10;
			}if (sadnessBar.value >= 75) {
				sadUp += 5;
			}
		}

		if (resetIcons == true) { //resets the button icons to blank
			buttons [0].GetComponent<SpriteRenderer> ().sprite = blankSprite;
			buttons [1].GetComponent<SpriteRenderer> ().sprite = blankSprite;
			buttons [2].GetComponent<SpriteRenderer> ().sprite = blankSprite;
			buttons [3].GetComponent<SpriteRenderer> ().sprite = blankSprite;
			buttons [4].GetComponent<SpriteRenderer> ().sprite = blankSprite;

			resetIcons = false;
		}

		if (ButtonsPressed >= MaxButtons) {
			Timer = 0;
			StopButtons = true;
			if (playedEndAudio == false) {
				sound.Play (endMusic);
			}
			playedEndAudio = true;
			friendChange = friendUp;
			loveChange = loveUp;
			sadChange = sadUp;
			TimeToChange -= Time.deltaTime;
		}
		if (Timer < 0 && ButtonsPressed < MaxButtons) {
			timeText.text = "Time Over";
			//TimeToChange -= Time.deltaTime;

		}
		if (TimeToChange < 0) {

			ButtonsPressed = 0;
			playedEndAudio = false;
			RoundNumber++;
			resetIcons = true;
			TimeToChange = 2f;
			Timer = 11f;
			StopButtons = false;
		}
		if (StopButtons == true) {
			roundButton.SetActive (true);

		}else{
			roundButton.SetActive(false);
		}

	}
	//	void RoundChange(){
	//		if (RoundNumber < 4) {
	//			ButtonSelection.MaxButtons = 3;
	//			ButtonSelection.Timer = 16f;
	//		} else if (RoundNumber < 6) {
	//			ButtonSelection.MaxButtons = 4;
	//			ButtonSelection.Timer = 11f;
	//		} if (RoundNumber == 6) {
	//			ButtonSelection.MaxButtons = 5;
	//			ButtonSelection.Timer = 6f;
	//		}
	//	}
	//void FixedUpdate (){

	//}
}
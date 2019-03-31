using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInput1 : MonoBehaviour {
	public string inputCombo="";



//	public GameObject happyFace, sadFace, loveFace;
//	public GameObject flatter, joke, wink, chat, neutral;
//	public Text meterText;
	public Text timeText;

	float Timer;

	public int buttonSlotSelection = 0;


	public bool canPlayerSpeak = true;//controls when the player can input a combo
	public bool StopButtons;
	public bool resetSlots = false;
	public int preferedLength;
	public int maxUsage;//max usage of a combo before "overused"
	public List<string> preMadeCombos;
	public Combo[] premadeCombos;
	List<Combo> comboUsage = new List<Combo> ();
	Dictionary<string,Combo> dictionaryCombos = new Dictionary<string,Combo> ();


	public Sprite blankSlotSprite; //sprites and array to control the button icons
	public Sprite flatterSlotSprite;
	public Sprite flirtSlotSprite;
	public Sprite chatSlotSprite;
	public Sprite jokeSlotSprite;
	public GameObject [] buttonSlots;	
	public soundScript audio;
	public AudioClip flatterSound;
	public AudioClip flirtSound;
	public AudioClip chatSound;
	public AudioClip jokeSound;
	public AudioClip music;



	//Dictionary<string, int> comboUsage;
	// Use this for initialization
	void Start () {
		Timer = 6f;

		audio.Play (music);
		canPlayerSpeak = true;
		premadeCombos = new Combo [3];
		premadeCombos [0] = new Combo ("ASA", "wholesome", 2, 1); //1, 2, 1, 0, 2, 2);
		premadeCombos [1] = new Combo ("WWSS","standup special", 2,1);//4, 3, 0,0,1,2 );
		premadeCombos [2] = new Combo ("DSSWD", "smooth criminal",1,1);
		preMadeCombos = new List<string>();
		preMadeCombos.Add ("ASA");
		preMadeCombos.Add ("WWSS");
		preMadeCombos.Add ("DSSWD");
		int i = 0;
		foreach(Combo combo in premadeCombos){
			comboUsage.Add (premadeCombos [i]);
			i++;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (resetSlots);
		//Get player input. 
		if (canPlayerSpeak == true ) {
			if(inputCombo.Length < 5 )
			{
				if (Input.GetKeyDown (KeyCode.A)) {
					inputCombo += "A";
					audio.Play(flatterSound);
//					buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = flatterSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.W)) {
					inputCombo += "W";
					audio.Play(chatSound);
				//	buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = chatSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					inputCombo += "S";
					audio.Play(jokeSound);
					//buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = jokeSlotSprite;
					buttonSlotSelection++;
				} else if (Input.GetKeyDown (KeyCode.D)) {
					inputCombo += "D";
					audio.Play(flirtSound);
					//buttonSlots [buttonSlotSelection].GetComponent<SpriteRenderer> ().sprite = flirtSlotSprite;
					buttonSlotSelection++;
				}
				print ("end of if(asdw){}");
			}

			if(Input.GetKeyDown(KeyCode.Space)){
				print ("pressed space >>"+inputCombo);

				canPlayerSpeak = false;
				GetComponent<comboReader>().readCombo(inputCombo);
				inputCombo = "";
				Timer = 6;
				canPlayerSpeak = true;
				//GetComponentInParent<comboReader> ().Source = inputCombo;
				//Debug.Log ("Press [R] to reset: Info>> " + compareCombo (preferedLength, inputCombo, premadeCombos));
				//print ("Press [R] to reset: Info>> " + compareCombo (preferedLength, inputCombo, premadeCombos, comboUsage));
			}

		}
		else { //hard reset button.
			if(Input.GetKeyDown(KeyCode.R) && canPlayerSpeak == false){ 
				resetSlots = true;
				timeText.text = "" + Mathf.Floor (Timer);
				Timer = 6;
				//canPlayerSpeak = true;
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

		if (Timer >= 0) {
			Timer -= Time.deltaTime;
		}
		if (Timer < 0) {
			timeText.text = "0";
			canPlayerSpeak = false;
			GetComponent<comboReader> ().readCombo ("");
			print (""+inputCombo);
		}
	}
		
	//<-------------------------------Functions----------------------->

	//compareCombo v2, now uses/needs a dictionary
	string compareCombo(int preferedComboLength, string playerCombo, ComboWithAllInts[] premadeComboList, List<ComboWithAllInts> usedCombos){
		string isIt = "";//the final string of info
		bool correctLength = false;
		bool premade = false;
		bool usedAlready = false;
		//testing length
		if(playerCombo.Length>preferedLength){ correctLength = true;}
		else{ isIt += "fit";}//langauge reflects length in attempts for improved readability

		//is this a premade combo
//		if(premadeComboList.Contains(playerCombo)==true){
//			isIt+=" premade";
//		} else { isIt+=" random";}
		foreach(ComboWithAllInts combo in premadeComboList){//checks if the combo is premade or not.
			int i =0;
			if (premadeComboList[i].comboInput.Equals(playerCombo)){
				premade = true;
				break;
			}
			i++;
		}
		foreach(ComboWithAllInts combo in usedCombos){//checks if  the  combo has been used before, and increments usage.
			int i = 0;
			if(usedCombos[i].comboInput.Equals(playerCombo)){
				usedAlready = true;
				usedCombos[i].usage+=1;
				break;
			}

			i++;
		}
		if(usedAlready==false){//adds the combo to the COmbo List, if necessary
			ComboWithAllInts newCombo = new ComboWithAllInts(playerCombo);
			usedCombos.Add(newCombo);
		}
//		if(usedCombos.Contains(playerCombo))
//		{ 
//			print ("used b4" + premadeComboList [playerCombo]);
//			usedCombos [playerCombo].usage += 1;
//			print ("used after " + premadeComboList [playerCombo]);
//			isIt += " used: " + usedCombos [playerCombo].usage;
//			print ("You've used this combo "+usedCombos[playerCombo].comboInput+" times!");
//		}
//		else{
//			print ("NEW COMBO ADDED!");
//			Combo newCombo = new Combo (playerCombo);
//			usedCombos.Add (newCombo);
//		}
		isIt = "Lenght?>"+correctLength+". Premade?>"+ premade+". New Combo?>"+usedAlready;
		return isIt;
	}

	public bool contains(string input, string[] list ){
		bool contained = false;

		for(int i = 0; i<list.Length-1;i++){
			if(list[i].Equals(input)){ contained = true; break;}
		}
		return contained;
	}

	public bool tooLong(int preferedLength, string combo){
		bool tooLong = false;
		if(preferedLength<combo.Length){
			tooLong = true;
		}
		return tooLong;
	}

	public bool premade(string combo, List<ComboWithAllInts> comboPreList){
		bool preMade = false;
		foreach (ComboWithAllInts combos in comboPreList ){
			int i = 0;
			if(comboPreList[i].comboName != "random"){
				preMade = true;
				break;
			}
			i++;
		}
		return preMade;
	}

	public	bool tooUsed(string combo, List<Combo> totalComboList, int prefUsage){
		bool usedMuch = false;
		int i = 0;
		foreach (Combo comBo in totalComboList){
			if(totalComboList[i].comboInput.Equals(combo) && totalComboList[i].usage>prefUsage){
				usedMuch = true;
				break;
			}

		}  

		return usedMuch;
	}
	public bool contains(string combo, List<Combo> totalCombos){
		bool onList = false;
		foreach (Combo wombo in totalCombos){
			int i = 0;
			if(totalCombos[i].comboInput.Equals(combo)){onList = true; break;}
			i++;
		}
		return onList;
	}
	public int findIndex(string combo, List<Combo> totalCombos){
		int index = -1;
		foreach (Combo wombo in totalCombos){
			int i = 0;
			if(totalCombos[i].comboInput.Equals(combo)){index = i; break;}
			i++;
		}
		return index;
	}


	public bool contains(string combo, List<string> totalCombos){
		bool onList = false;
		foreach (string wombo in totalCombos){
			int i = 0;
			if(totalCombos[i].Equals(combo)){onList = true; break;}
			i++;
		}
		return onList;
	}
//	public tempCombo convertToCombo(string comboWombo){
//		tempCombo comboInput = new tempCombo (inputCombo);
//
//
//		if (contains(comboWombo, preMadeCombos)==true){
//			premadeCombos [findIndex(comboWombo, comboUsage)].increaseUsage ();
//		}else {
//			comboUsage.Add (comboInput);
//		}
////		comboInput = premadeCombos [findIndex (comboWombo, comboUsage)];
//		return comboInput;
	//}
}







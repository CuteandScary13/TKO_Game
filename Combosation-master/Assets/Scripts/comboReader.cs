using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SakiAnswer{
	public List<string> options;//number of options that the player has
	public List<int> moodEffect;//int in the inspector that goes up or down depending on how appropriate the response is 
	public List<string>positiveOptions;
	public List<int>posMoodEffect;
	public List<string>negativeOptions;
	public List<int>negMoodEffect;
}



public class comboReader : MonoBehaviour {
	public comboManager comboManage;
	//public newInput newInput;
	public Dictionary<string, Combo> comboDictionary = new Dictionary<string, Combo>();
	private static comboReader _instance;//this is its own script and kind of its own object, so this script can be accessed from anywhere

	public static comboReader Instance { get { return _instance; } }

	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string Source;

	List <int> buttonCount;

	public List<string> questions;//the actual questions that Saki asks
	public List<string> negativeQuestions;
	bool negativeQuestionBool;
	public List<string> PositiveQuestions;
	bool positiveQuestionBool;

	public List<SakiAnswer> responses;//Saki's responses (both this and the questions are stored in the inspector) 
	public int questionIndex =0;//determines what number question you're on 
	public int finalAnswer =0;

	public static int statChecker;//checks mood over time going from sad to happy
	public static int mostUsedInput;// gets checked in the end scene
	public int chatChecker, flatterChecker, flirtChecker, jokeChecker;//checks the number of times each type of combo has been used throughout conversation

	public Text comboDescriptor;//text that describes the type of combo you implemented
	public Text dialogueText;//displays response text
	public Text questionText;//displays question text

	//public bool canPlayerSpeak = true;
	// Use this for initialization
	public GameObject sakiBubble;
	public Sprite neutralBubble;
	public Sprite goodBubble1;
	public Sprite goodBubble2;
	public Sprite badBubble1;
	public Sprite badBubble2;

	public AudioSource annoyanceSounds;
	public AudioSource newComboSource;
	public AudioClip annoyanceUp;
	public AudioClip annoyanceDown;

	int statEffect;
	public Combo currentCombo;

	public GameObject questionTextObject; //this is so it can be set inactive at the start
	float sceneStartTimer = .5f; //this stuff is so canvas stuff doesn't conflict with the scene transition
	bool sceneHasBegun;

	float finalDialogueTimer = 2f;
	float sceneEndTimer = 1f; //this block of stuff is all related to ending the scene
	public Animator sceneEndAnim;
	public GameObject sceneEndAnimObject;
	public AudioSource transitionSource;
	public AudioSource music;
	bool sceneEnding;
	bool endSoundHasPlayed;

	public bool posNegSwitch;

	public float annoyanceCounter;
	public GameObject saki;
	public Animator sakiAnim;//Saki's animator

	static int mostUsedComboType;

	public enum ResponseOps{//converts strings to ints
		chat=0,
		flirt=1,
		joke=2,
		flatter=3,
		other = 4,
		//we may not need this, look into 
	}

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	void Start () {
		questionTextObject.SetActive (false);
		//Debug.Log (questions [questionIndex]);
		comboDictionary= GetComponent<comboManager>().dictionaryCombos;
		GetComponent<newInput> ().canPlayerSpeak = true;


		statChecker=10;
		sakiAnim = saki.GetComponent<Animator> ();

		sceneEndAnimObject.SetActive(false);
		posNegSwitch = false;
	}
		
	// Update is called once per frame
	void Update () {
		
		if (sceneStartTimer >= 0) {
			sceneStartTimer -= Time.deltaTime;
		}
		if (sceneStartTimer <= 0 && sceneHasBegun == false) {
			questionTextObject.SetActive (true);
			sceneHasBegun = true;
		}



		if (posNegSwitch == false) {
			positiveQuestionBool = false;
			negativeQuestionBool = false;
		}
//		if (Input.GetKeyDown(KeyCode.M)) {
//			sceneEnding = true;
//			transitionSource.Play ();
//			music.Stop ();
//		}

		if (sceneEnding == true) {
			sceneEndTimer -= Time.deltaTime;
			sceneEndAnimObject.SetActive (true);
			sceneEndAnim.Play ("screenTransitionOpenAnimation");
			if (sceneEndTimer <= 0) {
				SceneManager.LoadScene ("endingSceneFinal");
			}
		}

		if (annoyanceCounter == 3) {
			statChecker = -30;
			questionIndex = 9;
		}
		//positive and negative track start
//		if (annoyanceCounter >= 1) {
//			negativeQuestionBool = true;
//			if(statEffect==2 && negativeQuestionBool==true){
//				negativeQuestionBool = false;
//				annoyanceCounter=0;
//			}
//		}
//		if (annoyanceCounter == 0 && statEffect == 2) {
//			positiveQuestionBool = true;
//		}
//		if (positiveQuestionBool == true) {
//			if (statEffect == -2 && positiveQuestionBool==true) {
//				positiveQuestionBool = false;
//			}
//		}
			//positive and negative track stop
		/*
		 * 
		 * int i = 0
		 * get space key
		 * 		if(i = 0){
		 * 			call question;
		 * 			i++;}
		 * 		if(i=1){ readCombo;i++}
		 * 		if(i=2){call response, i = 0}
		 * 
		 * 
		 */
		if (questionIndex == 9) {
			finalDialogueTimer -= Time.deltaTime;
			//Application.LoadLevel ("EndingScene");
			//if (finalDialogueTimer <= 0) {
				mostUsedTypeOfCombo ();
				//SceneManager.LoadScene("endingSceneFinal");
				sceneEnding = true;
				if (endSoundHasPlayed == false) {
					transitionSource.Play ();
					endSoundHasPlayed = true;
				}
				music.Stop ();
				comboDescriptor.text = " ";
				questionText.text = " ";
				dialogueText.text = " ";
			//}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			//Application.LoadLevel ("dellapisoundscene");//reloads game
		}

		if (statChecker > 55) { 
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = goodBubble2;
		}
		if (statChecker > 30 && statChecker <= 55) { //this stuff changes her bubble depending on how well you're doing
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = goodBubble1;
		}
		if (statChecker <= 30 && statChecker > 0) {
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = neutralBubble;

		}
		if (statChecker <= 0 && statChecker > -12) {
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = badBubble1;

		}
		if (statChecker <= -12) {
			sakiBubble.GetComponent<SpriteRenderer> ().sprite = badBubble2;

		}
			
	
//		}//molly check here for animator work
//		if (!Input.GetKeyDown (KeyCode.Space)) {
//			questionText.text = questions [questionIndex];//question text displays based on what number question you're on
//		}
	
		saki.GetComponent<Animator> ().SetFloat ("BaseMood", statChecker);//molly check here for animator work

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

	public void readCombo(string Source){
		
		//Debug.Log("Reader"+Source);
		//Debug.Log ("statchecker"+statChecker);
		print (Source);
		Combo temp = GetComponent<comboManager> ().addCombo (Source);
		currentCombo = temp;
		int currentComboType = GetComponent<comboManager>().readCombo (Source);
		Debug.Log ("the manager returned " + currentComboType);
		if (temp.isPremade == true) {
			comboDescriptor.text = 
				"NEW DISCOVERY" +//I know it's bad english
				"\nNew Combo: "+ temp.comboInput + 
				"\n\""+temp.comboName+ "\"" + 
				"\n Type: " + temp.comboType+" Bonus: "+temp.comboBonus+"X";

			newComboSource.Play ();
			/*
			 *Play sound/animation here?
			 */ 

		} else {//if its not an undiscovered instance
			comboDescriptor.text = "";
		}
	
		   
			
			GetComponent<newInput> ().inputCombo = "";
			GetComponent<newInput> ().canPlayerSpeak = true;

	


				//Debug.Log("Update"+Source);
		if (currentComboType == 0) {//checks if a chat combo was pressed
				RespondChat ();//calls chat function
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Chat! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Chat?! -" + Mathf.Abs (statEffect);
				}
			}
			questionIndex++;//moves the question index along
				}
		if(currentComboType==1){//checks for flatter
				RespondFlatter ();
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Flatter! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Flatter?! -" + Mathf.Abs (statEffect);
				}
			}
			questionIndex++;
				}
		if(currentComboType==2)
				{
				RespondJoke ();
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Joke! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Joke?! -" + Mathf.Abs (statEffect);
				}
			}
			questionIndex++;
				}
		if (currentComboType == 3) {
			RespondFlirt ();
			if (temp.isPremade == false) {
				if (statEffect > 0) {
					comboDescriptor.text = "Flirt! +" + Mathf.Abs (statEffect);
				} else {
					comboDescriptor.text = "Flirt?! -" + Mathf.Abs (statEffect);
				}
				questionIndex++;
			}
		}
		if (currentComboType == 4) {
			RespondAnnoyed ();
			questionIndex++;
		}

	}
	public void callDialogue(int typeOfCombo){

		dialogueText.text = responses [questionIndex].options [typeOfCombo];//takes the most pressed button, converts it to an int, then displays a response based on what that int is

//		if (negativeQuestionBool == true) {
//			dialogueText.text = responses [questionIndex].negativeOptions [typeOfCombo];
//		}
//
//		if (positiveQuestionBool == true) {
//			dialogueText.text = responses [questionIndex].positiveOptions [typeOfCombo];
//		}
		//a list within a list
	}

	public void callQuestion(){
		questionText.text = questions [questionIndex];//question text displays based on what number question you're on

//		if (negativeQuestionBool == true) {
//			questionText.text = negativeQuestions [questionIndex];
//		}
//
//		if (positiveQuestionBool == true) {
//			questionText.text = PositiveQuestions [questionIndex];
//		}

	}
	void RespondAnnoyed(){
		
			 statEffect = responses [questionIndex].moodEffect [4];
		
//		if (negativeQuestionBool == true) {
//			 statEffect = responses [questionIndex].negMoodEffect [4];
//		}
//		if (positiveQuestionBool == true) {
//			 statEffect = responses [questionIndex].posMoodEffect [4];
//		}
		sakiAnim.Play("unimpressedREACT");
		annoyanceCounter++;
		annoyanceSounds.clip = annoyanceUp;
		annoyanceSounds.Play ();
	}
	void RespondJoke(){
		
		 statEffect = responses [questionIndex].moodEffect [2];//checks the mood effect int in the inspector


//		if (negativeQuestionBool == true) {
//			 statEffect = responses [questionIndex].negMoodEffect [2];
//		}
//		if (positiveQuestionBool == true) {
//			 statEffect = responses [questionIndex].posMoodEffect [2];
//		}
		if ((statChecker < 0) || annoyanceCounter > 0) {
			//statEffect = -1;
		}
		if (statEffect == 2 && annoyanceCounter > 0) {
			annoyanceCounter--;
			annoyanceSounds.clip = annoyanceDown;
			annoyanceSounds.Play ();
		}
		statChecker += (statEffect*currentCombo.comboBonus)+1;//increases statchecker based on what was found in mood effect
		jokeChecker += 1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("unimpressedREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("happyREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("laughingREACT");
		}
	}
	void RespondFlatter(){
		
			statEffect = responses [questionIndex].moodEffect [1];//checks the mood effect int in the inspector


//		if (negativeQuestionBool == true) {
//			 statEffect = responses [questionIndex].negMoodEffect [1];
//		}
//		if (positiveQuestionBool == true) {
//			 statEffect = responses [questionIndex].posMoodEffect [1];
//		}

		if ((statChecker < 0) || annoyanceCounter > 0) {
			//statEffect = -2;
		}
		if (statEffect == 2 && annoyanceCounter > 0) {
			annoyanceCounter--;
			annoyanceSounds.clip = annoyanceDown;
			annoyanceSounds.Play ();
		}

		statChecker += (statEffect * currentCombo.comboBonus)+1;
		flatterChecker += 1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("unimpressedREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("happyREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("loveREACT");
		}
	}

	void RespondFlirt(){
		
			statEffect = responses [questionIndex].moodEffect [3];//checks the mood effect int in the inspector

//
//		if (negativeQuestionBool == true) {
//			 statEffect = responses [questionIndex].negMoodEffect [3];
//		}
//		if (positiveQuestionBool == true) {
//			 statEffect = responses [questionIndex].posMoodEffect [3];
//		}

		if ((statChecker < 0) || annoyanceCounter > 0) {
			//statEffect = -2;
		}
		if (statEffect == 2 && annoyanceCounter > 0) {
			annoyanceCounter--;
			annoyanceSounds.clip = annoyanceDown;
			annoyanceSounds.Play ();
		}

		statChecker += (statEffect* currentCombo.comboBonus)+1;
		//maximum per statchecker is 9, minimum is -7
		flirtChecker += 1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("angryREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("laughingREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("loveREACT");
		}
	}

	void RespondChat(){

			statEffect = responses [questionIndex].moodEffect [0];//checks the mood effect int in the inspector
		
//		if (negativeQuestionBool == true) {
//			 statEffect = responses [questionIndex].negMoodEffect [0];
//		}
//		if (positiveQuestionBool == true) {
//			 statEffect = responses [questionIndex].posMoodEffect [0];
//		}

		statChecker += (statEffect* currentCombo.comboBonus)+1;
		chatChecker+=1;
		if (statEffect == -2) {
			annoyanceCounter++;
			annoyanceSounds.clip = annoyanceUp;
			annoyanceSounds.Play ();
		}
		if (statEffect <= 0) {
			sakiAnim.Play ("unimpressedREACT");
		}
		if (statEffect == 1) {
			sakiAnim.Play ("neutralREACT");
		}
		if (statEffect == 2) {
			sakiAnim.Play ("happyREACT");
		}
	}
	public ResponseOps CheckButtonCounts(string combo) {
		buttonCount = new List<int> ();
		buttonCount.Add (0);
		buttonCount.Add (0);
		buttonCount.Add (0);
		buttonCount.Add (0);
		buttonCount [(int)buttonType.W] = combo.Split ('W').Length - 1;
		buttonCount [(int)buttonType.A] = combo.Split ('A').Length - 1;
		buttonCount [(int)buttonType.S] = combo.Split ('S').Length - 1;
		buttonCount [(int)buttonType.D] = combo.Split ('D').Length - 1;
		buttonType largestButtonType = buttonType.W;
		int largestCount = buttonCount [(int)largestButtonType];

		for (int i = 1; i < 4; i++) {
			if (largestCount < buttonCount [i]) {
				largestCount = buttonCount [i];
				largestButtonType = (buttonType)i;
			} else if (largestCount == buttonCount [i]) {
				largestButtonType = buttonType.Tie;
				//break;
			}
		}
			

		return (ResponseOps)largestButtonType;
	}

		public int mostUsedTypeOfCombo(){ 		//check line 160 for where this should be getting used
		//int tempMostUsedTypeOfCombo;
		int[] tempArray = new int[4];
		tempArray [0] = chatChecker;
		tempArray [1] = flatterChecker;
		tempArray [2] = jokeChecker;
		tempArray [3] = flirtChecker;

		int tempBig = tempArray[0];
		for(int i = 0; i<4;i++)
		{
			if(tempArray[i]>=tempBig){
				tempBig = tempArray [i];
				mostUsedInput = i;
			}
		}



		return mostUsedInput; //------ this line is causing an error
	}
}

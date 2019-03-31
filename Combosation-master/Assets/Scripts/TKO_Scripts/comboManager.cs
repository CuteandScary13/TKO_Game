using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class Combo {

	public string comboInput;//the literal string of characters that represenesnt the input
	public string comboName;//the name of the combo if it's premade, idk if necesary.

	public int usage;//how many times this has been used
	public int comboType ;//the type of combo this is, so the dialogue can be chosen. wchat = 0, aflatter =1, sjoke, = 2, dflirt 3, counter-clockwise.
	public int comboBonus ;//the bonus the combo gives.
	public bool isPremade;//is the combo premade.
	public bool unLocked;//is the combo unlocked

	List <int> buttonCount;
	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};
	public enum ResponseOps{//converts strings to ints
		chat=0,
		flirt=1,
		joke=2,
		flatter=3,
		other = 4,
		//we may not need this, look into 
	}

	public Combo (string inputCombo, string premadeName, int type, int bonus) {//premadeCombo COnstructor
		comboInput = inputCombo;
		comboName = premadeName; 
		usage = 0;
		comboType = type;
		comboBonus = bonus;
		isPremade = true;
		unLocked = true;
	}
	public Combo (string inputCombo){//randomCombo constructor
		comboInput = inputCombo; 
		comboName = "random";

		usage = 0;
		int randRange;
		int temp = (int)CheckButtonCounts(inputCombo);
		if(temp ==4){
			randRange = (int)Random.Range (0, inputCombo.Length-1);
			char inputChar = inputCombo [randRange];
			if(inputChar.Equals("W")){ comboType = 0;}
			else if(inputChar.Equals("A")){comboType = 1;}
			else if(inputChar.Equals("S")){comboType = 2;}
			else if(inputChar .Equals("D")){comboType = 3;}
		}else{
			comboType = temp;
		}

		isPremade = false;
		unLocked = true;
		comboBonus = 1;
	}

	public void increaseUsage()
	{
		usage++;
	}
	public string toString(){
		string info = comboName + "     " + comboInput + "     " + comboType;

		return info;
	}
	public int addBonus(int answerPoints ){
		int newPoints = answerPoints + comboBonus;
		return newPoints;
	}
	public int multBonus(int answerPoints){
		int newPoints = answerPoints * comboBonus;
		return newPoints;
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
}
public class comboManager : MonoBehaviour {
	//	public GameObject discoveryPanel;
	public Text dictionaryBox;
	public Image notepad;
	string PlayerInput;
	Combo inputCombo;
	public int preferedLenght;//what is the preferend length of combos for the date
	public int usageLimit;//how often a combo can be used before the date is upset.

	string myJson;
	public Dictionary<string,Combo> dictionaryCombos = new Dictionary<string, Combo>();
	Combo[] arrayOfCombos;
	public int numCombosPerPage=10;
	int dictionaryIndex=0;

	// Use this for initialization
	void Start () {

		myJson = "Assets/Scripts/TKO_Scripts/premadeComboList.json";

		CreateListFromJson ();
		arrayOfCombos = new Combo[dictionaryCombos.Count];
		int i = 0;
		foreach( KeyValuePair<string, Combo> entryCombo in dictionaryCombos) {
			arrayOfCombos [i] = entryCombo.Value;
			i++;
		}

	}

	// Update is called once per frame
	void Update () {

	}




	public int readCombo(string playerCombo){
		//Read Combo takes a string, the input of the player
		//return type of combo associated with that string.
		int typeOfCombo;

		//step 1
		//checks if there is a combo associated with that string in the dictionary. 
		//if there is, it should increase it's usage,
		//if not, it should add the string to the dictionary.
		if(dictionaryCombos.ContainsKey(playerCombo)){
			dictionaryCombos.TryGetValue (playerCombo, out inputCombo);
		}else{
			inputCombo = new Combo (playerCombo);
			dictionaryCombos.Add (playerCombo, inputCombo);

		}
		typeOfCombo = inputCombo.comboType;
		//step 2
		//chech it's usage,
		//if too often, respond with that.
		//if not too often, nothing. 
		Combo temp;
		dictionaryCombos.TryGetValue(playerCombo, out temp);
		if(temp.usage>usageLimit){
			typeOfCombo = 4;
		}

		return typeOfCombo;
	}

	public string displayDictionary(){
		/*
		 * create a string of combos
		 * if they have been discovered (usage == 0->1;)
		 * 	show their name, input and type
		 * if they haven't been
		 * 	show question marks
		 * 
		 */
		string TheDictionary = "#) Name     Input     Type \n";
		int indexCombo = 0;
		foreach(Combo dictCombo in arrayOfCombos){
			indexCombo++;

			string comboTypeString ="";//wchat = 0, aflatter =1, sjoke, = 2, dflirt 3

			if (dictCombo.usage > 0 ) {
				if (dictCombo.comboType == 0) {
					comboTypeString = "Chat";
				}else if(dictCombo.comboType ==1){
					comboTypeString ="Flatter";
				}else if(dictCombo.comboType ==2){
					comboTypeString ="Joke";
				}else if(dictCombo.comboType ==3){
					comboTypeString ="Flirt";
				}
				TheDictionary += indexCombo+") " + dictCombo.comboName + "     " + dictCombo.comboInput + "     " + comboTypeString+"\n";
			} 

			else {
				TheDictionary += indexCombo+")-----\n";
			}
		}

		return TheDictionary;
	}

	/*Display page of combos.
	 * bool goingForwardThroughDictionary; true = going forward/right/positive, false =back/left/negative
	 * create a string of combo dictionary entries.
	 * 
	 * if false
	 * 	set index back by numCombosPerPage
	 * 
	 * starting from index until index plus numCombosPerPage for each combo
	 * convert their comboType from an int to a string.
	 * put: #)comboName +dictCombo.comboInput + comboTypeString+"\n"; into the string.
	 * 
	 * index += numCombosPerPage;
	 * put the string into a text box.
	 * 
	 * 
	 * 
	 */ 

	public string displayDictionary(bool forwardThroughDictionary){//if true: move forward, if false: move back.
		string TheDictionary = "";
		if(forwardThroughDictionary == false){
			dictionaryIndex -= numCombosPerPage;
						if( (dictionaryIndex - numCombosPerPage)<0){
							dictionaryIndex = 0;
						}
		}
		int j;
		for(j = dictionaryIndex ; j<dictionaryIndex+numCombosPerPage;j++){
			string comboTypeString ="";//wchat = 0, aflatter =1, sjoke, = 2, dflirt 3
			//int jIndex = j+dictionaryIndex*numCombosPerPage;//adding j and dictionaryPageIndex give the actual number we're on.
			if(arrayOfCombos[j] == null){
				dictionaryIndex--;
				break;
			}
			if (arrayOfCombos[j].usage > 0 ) {
				if (arrayOfCombos[j].comboType == 0) {
					comboTypeString = "Chat";
				}else if(arrayOfCombos[j].comboType ==1){
					comboTypeString ="Flatter";
				}else if(arrayOfCombos[j].comboType ==2){
					comboTypeString ="Joke";
				}else if(arrayOfCombos[j].comboType ==3){
					comboTypeString ="Flirt";
				}
				TheDictionary += j+") " + arrayOfCombos[j].comboName + "     " + arrayOfCombos[j].comboInput + "     " + comboTypeString+"\n";
			} 

			else {
				TheDictionary += j+")-----\n";
			}
		}
		if(forwardThroughDictionary == true){
			dictionaryIndex +=numCombosPerPage;
						if((dictionaryIndex + numCombosPerPage)>arrayOfCombos.Length-numCombosPerPage){
							dictionaryIndex = arrayOfCombos.Length - numCombosPerPage;
						//this is for dealing with the fact that we may not have pretty numbers of combos, 
						//so it resets the index to the last number that would aboid getting an out of bounds exception when displaying
						}
		}
		TheDictionary+= "\n [L] Next Page\n[K] Last Page";
		return TheDictionary;

	}


	private bool CreateListFromJson()
	{
		//catch in case it don't work
		try{
			//give us a place to store the next line of json
			string line;

			//create a reader to read the file
			StreamReader jsonReader = new StreamReader(myJson);

			using (jsonReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = jsonReader.ReadLine();

					if (line != null)
					{
						Combo newCombo = JsonUtility.FromJson<Combo>(line);
						dictionaryCombos.Add(newCombo.comboInput,newCombo);
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				jsonReader.Close();
				return true;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
			return false;
		}
	}


	public Combo addCombo(string playerCOmbo){
		Combo newCombo;

		if(dictionaryCombos.ContainsKey(playerCOmbo)){
			dictionaryCombos.TryGetValue (playerCOmbo, out newCombo);

			//inputCombo.increaseUsage ();
			//print ("new usage: " + inputCombo.usage);
		}else{
			inputCombo = new Combo (playerCOmbo);
			dictionaryCombos.Add (playerCOmbo, inputCombo);
			//
			newCombo = inputCombo;
		}
		return newCombo;
	}

}
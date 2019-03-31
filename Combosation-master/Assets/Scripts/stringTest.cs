using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stringTest : MonoBehaviour {
	enum buttonType{W = 0, A = 1, S = 2, D = 3, Tie = 4};

	public string Source;//what the code uses to calculate.

	List <int> buttonCount;
	// Use this for initialization
	void Start () {
		
		buttonType mostPressedButton = CheckButtonCounts (Source);
	}
	
	// Update is called once per frame
	void Update () {
		//Mathf.Max
	}

	buttonType CheckButtonCounts(string combo) {
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
				break;
			}
		}

		if (largestButtonType == buttonType.W) {
			Debug.Log ("W");
		} else if (largestButtonType == buttonType.A) {
			Debug.Log ("A");
		} else if (largestButtonType == buttonType.S) {
			Debug.Log ("S");
		} else if (largestButtonType == buttonType.D) {
			Debug.Log ("D");
		} else {
			Debug.Log ("Tie!");
		}

		return largestButtonType;
	}
}

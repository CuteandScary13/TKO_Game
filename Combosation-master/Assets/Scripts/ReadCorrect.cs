using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCorrect : MonoBehaviour {

	public static string correctString;
	public static Text Correct;
	//public float timeToType;
	//public static float textPercentage = 0;
	//public static bool triggered = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//if (triggered) {
			Correct.text = "" + correctString;
			//int numberOfLettersToShow = (int)(correctString.Length * textPercentage);
			//Correct.text = correctString.Substring (0, numberOfLettersToShow);
			//textPercentage += Time.deltaTime / timeToType;
			//textPercentage = Mathf.Min (1.0f, textPercentage);
		//}
	}
}

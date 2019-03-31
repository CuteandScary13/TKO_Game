using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOptions : MonoBehaviour {
	public Text OptionOne;
	public Text OptionTwo;
	public Text OptionThree;
	public static string optionOneActive;
	public static string optionTwoActive;
	public static string optionThreeActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		OptionOne.text = "" + optionOneActive;
		OptionTwo.text = "" + optionTwoActive;
		OptionThree.text = "" + optionThreeActive;
	}
}

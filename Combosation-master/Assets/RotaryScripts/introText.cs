using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introText : MonoBehaviour {

	public static string activeString;
	public Text intro;
	public float timeToType;
	public static float textPercentage = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("active string = " + activeString);
		intro.text = "" + activeString;
		int numberOfLettersToShow = (int)(activeString.Length * textPercentage);
		intro.text = activeString.Substring (0, numberOfLettersToShow);
		textPercentage += Time.deltaTime / timeToType;
		textPercentage = Mathf.Min (1.0f, textPercentage);
	}
}
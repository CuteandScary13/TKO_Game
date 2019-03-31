using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPoetry : MonoBehaviour {

	public static string activeString;
	public Text Stanza;
	public float timeToType;
	public static float textPercentage = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("active string = " + activeString);
		Stanza.text = "" + activeString;
		int numberOfLettersToShow = (int)(activeString.Length * textPercentage);
		Stanza.text = activeString.Substring (0, numberOfLettersToShow);
		textPercentage += Time.deltaTime / timeToType;
		textPercentage = Mathf.Min (1.0f, textPercentage);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour {
	public GameObject date;
	public float response;
	public bool  dateSpeaking = true, playerSpeaking=false;
	// Use this for initialization
	void Start () {
		dateSpeaking = date.GetComponent<testDate> ().dateSpeaking;
		playerSpeaking = date.GetComponent<testDate> ().playerSpeaking;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log ("I think 1 is the luckiest number.");
			playerSpeaking = true;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log ("I think 2 is the luckiest number.");
			playerSpeaking = true;
	
		} else if (Input.GetKeyDown (KeyCode.Alpha3)){
			Debug.Log("I think 3 is the luckiest number.");
			playerSpeaking = true;
		}
	}
}

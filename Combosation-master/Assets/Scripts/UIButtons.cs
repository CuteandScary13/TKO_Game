using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

	public GameObject chatGuideOff;
	public GameObject chatGuideOn;
	public GameObject flatterGuideOff;
	public GameObject flatterGuideOn;
	public GameObject flirtGuideOff;
	public GameObject flirtGuideOn;
	public GameObject jokeGuideOff;
	public GameObject jokeGuideOn;

	void Start () {
		chatGuideOn.SetActive (false);
		flatterGuideOn.SetActive (false);
		flirtGuideOn.SetActive (false);
		jokeGuideOn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			chatGuideOn.SetActive (true);
			chatGuideOff.SetActive (false);
		} else {
			chatGuideOn.SetActive (false);
			chatGuideOff.SetActive (true);
		}

		if (Input.GetKey (KeyCode.A)) {
			flatterGuideOn.SetActive (true);
			flatterGuideOff.SetActive (false);
		} else {
			flatterGuideOn.SetActive (false);
			flatterGuideOff.SetActive (true);
		}

		if (Input.GetKey (KeyCode.S)) {
			jokeGuideOn.SetActive (true);
			jokeGuideOff.SetActive (false);
		} else {
			jokeGuideOn.SetActive (false);
			jokeGuideOff.SetActive (true);
		}

		if (Input.GetKey (KeyCode.D)) {
			flirtGuideOn.SetActive (true);
			flirtGuideOff.SetActive (false);
		} else {
			flirtGuideOn.SetActive (false);
			flirtGuideOff.SetActive (true);
		}
	}
}

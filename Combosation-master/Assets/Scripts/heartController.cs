using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour {

	public comboReader comboReader;
	public GameObject X1;
	public GameObject X2;
	public GameObject X3;
	 float annoyance;

	// Use this for initialization
	void Start () {
		X1.SetActive (false);
		X2.SetActive (false);
		X3.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		annoyance = comboReader.GetComponent<comboReader> ().annoyanceCounter;
		Debug.Log (annoyance );
		if (annoyance >= 1) {
			Debug.Log ("bloop");
			X1.SetActive (true);
		}

		if (comboReader.GetComponent<comboReader> ().annoyanceCounter >= 2) {
			X2.SetActive (true);
		}

		if (comboReader.GetComponent<comboReader> ().annoyanceCounter >= 3) {
			X3.SetActive (true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour {
	public int health=5;
	public int sadUp, sadDown, loveUp, loveDown, friendUp, friendDown, sadness, friendliness, loveliness;
	public Slider sadnessBar,lovelyBar,friendlyBar;//sliders for the bars
	// Use this for initialization
	void Start () {
		sadUp = sadnessBar.GetComponent<sadBar> ().rateInc;
		sadDown = sadnessBar.GetComponent<sadBar> ().rateDec;
		loveUp = lovelyBar.GetComponent<loveBar> ().rateInc;
		loveDown = lovelyBar.GetComponent<loveBar> ().rateDec;
		friendUp = friendlyBar.GetComponent<friendBar> ().rateInc;
		friendDown = friendlyBar.GetComponent<friendBar> ().rateDec;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			sadness -= sadDown;
			loveliness -= loveDown;
			friendliness -= friendDown;
			Debug.Log ("things go down");
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			sadness += sadDown;
			loveliness += loveDown;
			friendliness += friendDown;

			Debug.Log ("things go up");
		}

	}
}

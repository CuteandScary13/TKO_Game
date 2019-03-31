using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerFeels : MonoBehaviour {
	public int sadUp, sadDown, loveUp, loveDown, friendUp, friendDown, sadness, friendliness, loveliness;
	public Slider sadnessBar,lovelyBar,friendlyBar;//sliders for the bars
	// Use this for initialization
	void Start () {
		sadnessBar.GetComponent<sadBar> ().rateInc =sadUp;
		sadnessBar.GetComponent<sadBar> ().rateDec = sadDown;
		lovelyBar.GetComponent<loveBar> ().rateInc =loveUp;
		lovelyBar.GetComponent<loveBar> ().rateDec = loveDown;
		friendlyBar.GetComponent<friendBar> ().rateInc =friendUp;
		friendlyBar.GetComponent<friendBar> ().rateDec =friendDown;
	
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

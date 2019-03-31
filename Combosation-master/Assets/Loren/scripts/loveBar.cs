using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class loveBar : MonoBehaviour {
	public Slider sadnessBar,lovelyBar,friendlyBar;//sliders for the bars
	public GameObject gameMaster;
	public int rateInc,rateDec;//rate at which the bars move, sepereated into increased and decreased rate.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//lovelyBar.value = gameMaster.GetComponent<ButtonSelection> ().loveliness;//get infor from player and set's the bar with that info
		Debug.Log ("My cureent value is" + lovelyBar.value);
		if(lovelyBar.value<30){
			Debug.Log ("I'm less than 30");
		}
		else if(lovelyBar.value>60){
			Debug.Log ("I'm more than 60");
		}
		if(friendlyBar.value>70){
			//lovelyBar.GetComponent<loveBar> ().rateDec -= 10;
		}
	}
}

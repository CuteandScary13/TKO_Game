using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
	public GameObject player;
	public Slider sliderVar;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		sliderVar.value = player.GetComponent<playerHealth> ().health;
		Debug.Log ("My cureent value is" + sliderVar.value);
		if(sliderVar.value<30){
			Debug.Log ("I'm less than 30");
		}
		else if(sliderVar.value>60){
			Debug.Log ("I'm more than 60");
		}
	}
}

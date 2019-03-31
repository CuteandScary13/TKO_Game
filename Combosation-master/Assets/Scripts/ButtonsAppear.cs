using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAppear : MonoBehaviour {

	public Text buttonText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Abutton")){
			buttonText.text = "A";
		}
		if(Input.GetButton("Bbutton")){
			buttonText.text = "B";
		}
		if(Input.GetButton("Xbutton")){
			buttonText.text = "X";
		}
		if(Input.GetButton("Ybutton")){
			buttonText.text = "Y";
		}
		if(Input.GetAxisRaw("Vertical") == 1){
			buttonText.text = "up";
		}
		if(Input.GetAxisRaw("Vertical")== -1){
			buttonText.text = "down";
		}
		if(Input.GetAxisRaw("Horizontal") == -1){
			buttonText.text = "left";
		}
		if(Input.GetAxisRaw("Horizontal") == 1){
			buttonText.text = "right";
		}
	}
}

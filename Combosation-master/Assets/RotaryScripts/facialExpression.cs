using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facialExpression : MonoBehaviour {
	public GameObject happyFace;
	public GameObject sadFace;
	public GameObject heartFace;
	public GameObject sillyFace;

	public GameObject xMark;
	public GameObject checkMark;

	public bool sillyCheck=false;
	public bool heartCheck=false;
	public bool happyCheck=false;
	// Use this for initialization
	void Start () {
		sadFace.SetActive(false);
		heartFace.SetActive(false);
		sillyFace.SetActive(false);
		happyFace.SetActive(false);
		xMark.SetActive (false);
		checkMark.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (sillyCheck == true) {
			sillyFace.SetActive (true);
		}else{
				sillyFace.SetActive(false);
			}
		
		if (heartCheck == true) {
			heartFace.SetActive (true);
		}else{
				heartFace.SetActive(false);
			}
		
		if (happyCheck == true) {
			happyFace.SetActive (true);

		}else{
				happyFace.SetActive(false);
			}
		//in the final prototype, none of the inputs below rely on button presses. these bool checks will be put into the end of 
		//the response script depending on what response was picked. 
		if (Input.GetKeyDown (KeyCode.A)) {
			sillyCheck = true;
			heartCheck = false;
			happyCheck = false;
		} 
		if(Input.GetKeyDown(KeyCode.B)){
				heartCheck=true;
				sillyCheck = false;
				happyCheck = false;
			}
		if(Input.GetKeyDown(KeyCode.C)){
				happyCheck=true;
				sillyCheck = false;
				heartCheck = false;
				}
	}
}

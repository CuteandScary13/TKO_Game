using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour {
	public static float sadTotalGM, friendTotalGM, loveTotalGM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I)){
			Debug.Log ("here is sad: " + sadTotalGM + " and here is the friendTotal: " + friendTotalGM + " and here is the loveTotal: " + loveTotalGM + ".");
		}
	}
}

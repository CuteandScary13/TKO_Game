using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotChild : MonoBehaviour {
//	public Object parent;
//	public Object child;


	//frp, Infintie RUnner:Defelctor movement
	public GameObject child; 
	float xPos, yPos, radius; 
	public float thetaNgle, thetaInc = (2f*Mathf.PI)/3f;
	Vector3 rotAtion;
	// Use this for initialization
	void Start () {
		child.SetActive(true);
		rotAtion = new Vector3 (0f, 0f, thetaInc);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			//transform.RotateAround(this.transform.position, new Vector3(0f,0f,1f), thetaInc) (rotAtion, Space.World);

		}

	}
}

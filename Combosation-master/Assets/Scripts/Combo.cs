using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Combo {
//	public string comboInput {get;set;}//the literal string of characters that represenesnt the input
//	public string comboName{get;set;}//the name of the combo if it's premade, idk if necesary.
//	public string comboResponse{get;set;} //the response Saki gives for this premade combo.
//	public int usage{get;set;} //how many times this has been used
//	public int comboType {get;set;}//the type of combo this is, so the dialogue can be chosen.
//	public int comboBonus {get;set;}//the bonus the combo gives.
//
//	public Combo (string inputCombo, string premadeName, int type, string dialogueResponse, int bonus) {//premadeCombo COnstructor
//		comboInput = inputCombo; 
//		comboName = premadeName; 
//		usage = 0;
//		comboType = type;
//		comboBonus = bonus;
//	}
//	public Combo (string inputCombo){//randomCombo constructor
//		comboInput = inputCombo; 
//		comboName = "random";
//		comboResponse = "";
//		usage = 0;
//		comboType = (int)comboReader.Instance.CheckButtonCounts(inputCombo);
//	}
//
//
//		public void increaseUsage()
//	{
//		usage++;
//	}
//
//	public string toString(){
//		string info = "Name: "+comboName+"| Combo:"+comboInput+"| Type:" +comboType+"| Used: "+usage+"| Bonus:"+comboBonus;
//
//		return info;
//	}
//}

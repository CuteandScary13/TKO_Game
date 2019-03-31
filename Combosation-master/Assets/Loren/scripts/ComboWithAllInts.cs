using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboWithAllInts {

		public string comboInput {get;set;}
		public string comboName{get;set;}//the name of the combo if it's premade, idk if necesary.
		public int usage{get;set;}
		public int friendChangePos{get;set;}
		public int friendChangeNeg{get;set;}
		public int loveChangePos{get;set;}
		public int loveChangeNeg{get;set;}
	public int sadChangePos{ get; set;}
	public int sadChangeNeg{ get; set;}

	public ComboWithAllInts (string combo, string nameOfCombo, int friendPos, int friendNeg, int lovePos, int loveNeg, int sadPos, int sadNeg){
			comboInput = combo;
			comboName = nameOfCombo;
			usage = 0;
			friendChangePos = friendPos; friendChangeNeg = friendNeg; 
			loveChangePos = lovePos; loveChangeNeg=loveNeg;
			sadChangePos = sadPos; sadChangeNeg = sadNeg;

		}
		public ComboWithAllInts(string combo){
		comboInput = combo;
		usage = 0;
		comboName = "random";
		int frequentButton = (int)comboReader.Instance.CheckButtonCounts(combo);
		if (frequentButton == 0) {
			friendChangePos = 1; friendChangeNeg = 0; 
			loveChangePos = 0; loveChangeNeg=0;
			sadChangePos = 0; sadChangeNeg = 0;
		} else if (frequentButton == 1) {
			friendChangePos = 0; friendChangeNeg = 0; 
			loveChangePos = 1; loveChangeNeg=0;
			sadChangePos = 0; sadChangeNeg = 0;
		} else if (frequentButton == 2) {
			friendChangePos = 2; friendChangeNeg = 0; 
			loveChangePos = 0; loveChangeNeg=0;
			sadChangePos = 0; sadChangeNeg = 0;
		} else if (frequentButton == 3) {
			friendChangePos = 0; friendChangeNeg = 0; 
			loveChangePos = 2; loveChangeNeg=0;
			sadChangePos = 0; sadChangeNeg = 0;
		}else if(frequentButton ==4){
			friendChangePos = 0; friendChangeNeg = 0; 
			loveChangePos = 0; loveChangeNeg=0;
			sadChangePos = 0; sadChangeNeg = 0;
		}

		//friend/love++pos/neg are to be calculated in the constructor.
			//cop even's code to sort out it what the value is
		}


	}

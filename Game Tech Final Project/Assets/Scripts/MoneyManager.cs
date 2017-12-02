﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public double CurrentMoney;
	//public double DisplayMoney;
	public double AllTimeMoney;

	public Text MoneyDisplay;


	// Use this for initialization
	void Start () {
		CurrentMoney = 50000;
		AllTimeMoney = 50000;

		UpdateText ();
	}

	public bool Transaction (double MoneyChange) {
		if ((MoneyChange >= 0) || (MoneyChange < 0 && Math.Abs(MoneyChange) <= CurrentMoney)) {
			CurrentMoney += MoneyChange;
			AllTimeMoney += MoneyChange;
			UpdateText ();
			return true;
		} else {
			return false;
		}
	}
	
	void UpdateText () {
		//DisplayMoney += (CurrentMoney - DisplayMoney) / (CurrentMoney - DisplayMoney);
		//MoneyDisplay.text = Math.Round(DisplayMoney, 2) + "$";
		MoneyDisplay.text = "$" + Math.Round(CurrentMoney, 2);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyManager : MonoBehaviour {

	public double CurrentMoney;
	public double AllTimeMoney;

	public double DisplayMoney;

	// Use this for initialization
	void Start () {
		CurrentMoney = 50000;
		AllTimeMoney = 50000;

		DisplayMoney = CurrentMoney;
	}

	public bool Transaction (double MoneyChange) {
		if ((MoneyChange >= 0) || (MoneyChange < 0 && Math.Abs(MoneyChange) <= CurrentMoney)) {
			CurrentMoney += MoneyChange;
			AllTimeMoney += MoneyChange;
			DisplayMoney = Math.Round(CurrentMoney, 2);
			return true;
		} else {
			return false;
		}
	}
}

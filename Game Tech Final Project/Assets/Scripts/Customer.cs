using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : ScriptableObject {

	public Category category;
	public double willingness;

	public bool Buy () {
		double r = Random.Range (0, 100) / 100.0;
		if (r <= willingness) {
			return true;
		}
		return false;
	}

	public Item ChooseItemToBuy (Dictionary<Item, int> ItemsForSale) {
		foreach (Item i in ItemsForSale.Keys) {
			if (i.category.name == category.name)
				return i;
		}
		return null;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Customers : MonoBehaviour {

	public Category[] categories;
	public float[] categoryProbabilities;

	public int popularity;
	public List<Category> CustomerList;

	private float total;

	private ItemManager PlayerItems = MainManager.singleton.GetComponent<ItemManager> ();

	// Use this for initialization
	void Start () {
		// Starting in 1 second repeat every 30 seconds
		InvokeRepeating("UpdateFunction", 30.0f, 30.0f);

	}

	private void UpdateFunction() {
		if (PlayerItems.ItemsForSale.Count > 0) {
			total = 0;
			for (int i = 0; i < categoryProbabilities.Length; i++) {
				float n = UnityEngine.Random.value;
				categoryProbabilities [i] = total + n;
				total += n;
			}
			popularity = PlayerItems.totalNumberItemsForSale() * 2;
		}
	}

	private Category ChooseCustomer() {
		float roll = UnityEngine.Random.Range(0.0f, total);

		for (int i = 0; i < categories.Length; ++i) {
			if (roll <= categoryProbabilities [i]) {
				return categories[i];
			}
		}
		return categories [categories.Length - 1];
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Customers : MonoBehaviour {

	public Category[] categories;

	public List<List<int>> categoryFunctions;
	public List<double> categoryPopularity;

	public double shopPopularity = 10;
	public double time = 0;

	public List<Customer> CurrentCustomers;

	private ItemManager PlayerItems;

	// Use this for initialization
	void Start () {
		CurrentCustomers = new List<Customer> ();
		PlayerItems = gameObject.GetComponent<ItemManager> ();

		categoryPopularity = new List<double> ();

		categoryFunctions = new List<List<int>> ();
		categoryFunctions.Add(new List<int>());
		categoryFunctions.Add(new List<int>());
		categoryFunctions.Add(new List<int>());

		foreach (List<int> polys in categoryFunctions) {
			categoryPopularity.Add (0.0);

			polys.Add (UnityEngine.Random.Range(-4,6));
			polys.Add (UnityEngine.Random.Range(-4,6));
			polys.Add (UnityEngine.Random.Range(-4,6));
		}

		// Starting in 30 second repeat every 30 seconds
		InvokeRepeating("UpdateFunction", 30.0f, 30.0f);

	}

	private void UpdateFunction() {
		List<Item> itemsForSale = new List<Item> (PlayerItems.ItemsForSale.Keys);
		foreach (Customer c in CurrentCustomers) {
			if (c.Buy () && PlayerItems.ItemsForSale.Count > 0) {
				if (PlayerItems.SellItem(itemsForSale[0]))
					itemsForSale.RemoveAt(0);
			}
		}
		CurrentCustomers.Clear ();

		time += .1;
		if (time > 5)
			time -= 5;

		//shopPopularity = PlayerItems.ItemsForSale.Count;	//temp

		for (int c = 0; c < categoryPopularity.Count; ++c) {
			categoryPopularity [c] = shopPopularity * (Math.Cos(categoryFunctions[c][0] * Math.Sin(categoryFunctions[c][1] * time 
				* Math.Sin(categoryFunctions[c][2] * time))) * Math.Cos(categoryFunctions[c][0] * Math.Sin(categoryFunctions[c][1] * time)));
		}
		CalculateCustomers ();
	}

	private void CalculateCustomers() {
		for (int cat = 0; cat < categoryPopularity.Count; cat++) {
			if (PlayerItems.numberOfItemsInCategory (categories [cat]) > 0) {
				double popularity = categoryPopularity [cat];
				for (int r = 0; r < popularity; r++) {
					Customer person = ScriptableObject.CreateInstance<Customer> ();
					person.category = categories [cat];
					person.willingness = UnityEngine.Random.Range(0,50)/100.0;
					CurrentCustomers.Add (person);
				}
			}
		}
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Dictionary<Item, int> MyItems;
	public Dictionary<CraftMaterial, int> MyMaterials;

	public Dictionary<Item, int> ItemsForSale;

	// Use this for initialization
	void Start () {
		MyItems = new Dictionary<Item, int> ();
		MyMaterials = new Dictionary<CraftMaterial, int> ();

		ItemsForSale = new Dictionary<Item, int> ();
	}

	public void MakeItem (Item item) {
		if (MyItems.ContainsKey (item)) {
			MyItems [item] = MyItems [item] + 1;
		} else {
			MyItems.Add (item, 1);
		}
	}

	public void DuplicateItem (Item item) {
	}

	public bool SellItem (Item item) {
		if (item != null && MyItems.ContainsKey (item) && MyItems[item] > 0) {
			item.Sell (500);		//TODO let the user input their own info
			if (ItemsForSale.ContainsKey (item)) {
				ItemsForSale [item] += 1;
			} else {
				ItemsForSale.Add (item, 1);
			}
			MyItems [item] -= 1;
			if (MyItems [item] == 0)
				MyItems.Remove (item);
			return true;
		}
		return false;
	}

	public void GetMaterial (CraftMaterial material) {
		if (MyMaterials.ContainsKey (material)) {
			MyMaterials [material] = MyMaterials [material] + 1;
		} else {
			MyMaterials.Add (material, 1);
		}
	}

	public bool UseMaterial (CraftMaterial material, int Number = 1) {
		if (MyMaterials.ContainsKey(material) && MyMaterials[material] <= Number) {
			MyMaterials [material] -= Number;
			if (MyMaterials [material] == 0)
				MyMaterials.Remove (material);
			return true;
		}
		return false;
	}

	public int totalNumberItemsForSale () {
		int total = 0;
		foreach (int i in ItemsForSale.Values) {
			total += i;
		}
		return total;
	}

	public int numberOfItemsInCategory (Category cat) {
		int total = 0;
		foreach (Item i in ItemsForSale.Keys) {
			if (i.category.name == cat.name)
				++total;
		}
		return total;
	}

}

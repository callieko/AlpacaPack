using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Dictionary<GameObject, int> ItemsForSale;

	public MoneyManager wallet;

	public GameObject ItemDisplay;
	public GameObject ShopDisplayPanel;

	// Use this for initialization
	void Start () {
		ItemsForSale = new Dictionary<GameObject, int> ();
	}

	public void DisplayItem (GameObject itemObj) {
		if (ItemsForSale.ContainsKey (itemObj)) {
			ItemsForSale [itemObj] = ItemsForSale [itemObj] + 1;
		} else {
			ItemsForSale.Add (itemObj, 1);
		}

		GameObject display = Instantiate (ItemDisplay);

		GameObject Image = display.transform.GetChild (0).gameObject;
		GameObject Name = display.transform.GetChild (1).gameObject;
		GameObject Category = display.transform.GetChild (2).gameObject;
		GameObject Price = display.transform.GetChild (3).gameObject;
		GameObject EditButton = display.transform.GetChild (5).gameObject;

		Item item = itemObj.GetComponent<Item> ();

		Image.GetComponent<Image> ().sprite = item.GetThumbnail ();

		Name.GetComponent<Text> ().text = item.Name + " (" + ItemsForSale[itemObj] + ")";

		string categories = "";
		int index = 0;
		foreach (Category C in item.Categories) {
			categories += C.Name;
			if (item.Categories.Count > 1 && index < item.Categories.Count - 1)
				categories += ", ";
			index++;
		}
		Category.GetComponent<Text> ().text = categories;

		Price.GetComponent<Text> ().text = "$" + item.GetSalePrice();

		EditButton.GetComponent<Button>().onClick.AddListener(delegate {EditItem(itemObj);});

		display.transform.SetParent (ShopDisplayPanel.transform);
		ItemDisplay = display;
	}

	public void EditItem (GameObject item) {
	}

	public void SellItem (GameObject item) {
		wallet.Transaction (item.GetComponent<Item> ().GetSalePrice ());

		ItemsForSale [item] -= 1;
		if (ItemsForSale [item] == 0) {
			ItemsForSale.Remove (item);
			Destroy (ItemDisplay);
		} else {
			GameObject Name = ItemDisplay.transform.GetChild (1).gameObject;
			Name.GetComponent<Text> ().text = item.GetComponent<Item> ().Name + " (" + ItemsForSale[item] + ")";
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}

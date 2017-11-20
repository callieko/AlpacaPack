using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Dictionary<GameObject, int> ItemsForSale;

	public MoneyManager wallet;

	public GameObject ShopItemDisplay;
	public GameObject ShopDisplayPanel;

	public GameObject EditItemWindow;

	// Use this for initialization
	void Start () {
		ItemsForSale = new Dictionary<GameObject, int> ();

		EditItemWindow.SetActive(false);
	}

	/* Puts an item up for sale and adds it to the Shop Display window */
	public void DisplayItem (GameObject itemObj) {
		if (ItemsForSale.ContainsKey (itemObj)) {
			ItemsForSale [itemObj] = ItemsForSale [itemObj] + 1;
		} else {
			ItemsForSale.Add (itemObj, 1);
		}

		GameObject display = Instantiate (ShopItemDisplay);

		GameObject Image = display.transform.GetChild (0).gameObject;
		GameObject Name = display.transform.GetChild (1).gameObject;
		GameObject Category = display.transform.GetChild (2).gameObject;
		GameObject Price = display.transform.GetChild (3).gameObject;
		GameObject EditButton = display.transform.GetChild (4).gameObject;

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

		EditButton.GetComponent<Button>().onClick.AddListener(delegate {EditItem(itemObj, display);});

		display.transform.SetParent (ShopDisplayPanel.transform);
		ShopItemDisplay = display;
	}

	/* Called when the edit button is pressed on the the item. Brings up the edit window */
	public void EditItem (GameObject itemObj, GameObject display) {
		Item item = itemObj.GetComponent<Item> ();

		EditItemWindow.SetActive(true);
		Image Thumbnail = EditItemWindow.transform.GetChild (1).GetComponent<Image> ();
		InputField NameField = EditItemWindow.transform.GetChild (3).GetComponent<InputField> ();
		//Dropdown Categories = EditItemWindow.transform.GetChild (5).GetComponent<Dropdown> ();
		InputField PriceField = EditItemWindow.transform.GetChild (7).GetComponent<InputField> ();
		Button AcceptButton = EditItemWindow.transform.GetChild (8).GetComponent<Button> ();
		Button CancelButton = EditItemWindow.transform.GetChild (9).GetComponent<Button> ();

		Thumbnail.sprite = item.GetThumbnail ();
		NameField.text = item.Name;
		//TODO Category dropdown
		PriceField.text = "" + item.GetSalePrice ();
		AcceptButton.onClick.AddListener(delegate {EditExit(true, display, itemObj);});
		CancelButton.onClick.AddListener(delegate {EditExit(false);});
	}

	/* When the item is actually sold */
	public void SellItem (GameObject item) {
		wallet.Transaction (item.GetComponent<Item> ().GetSalePrice ());

		ItemsForSale [item] -= 1;
		if (ItemsForSale [item] == 0) {
			ItemsForSale.Remove (item);
			Destroy (ShopItemDisplay);
		} else {
			GameObject Name = ShopItemDisplay.transform.GetChild (1).gameObject;
			Name.GetComponent<Text> ().text = item.GetComponent<Item> ().Name + " (" + ItemsForSale[item] + ")";
		}
	}

	/* When the edits from the edit window are accepted or rejected */
	public void EditExit (bool accept, GameObject display = null, GameObject itemObj = null) {
		Item item = itemObj.GetComponent<Item> ();

		EditItemWindow.SetActive(false);
		if (accept) {
			InputField NameField = EditItemWindow.transform.GetChild (3).GetComponent<InputField> ();
			//Dropdown Categories = EditItemWindow.transform.GetChild (5).GetComponent<Dropdown> ();
			InputField PriceField = EditItemWindow.transform.GetChild (7).GetComponent<InputField> ();

			Text Name = display.transform.GetChild (1).gameObject.GetComponent<Text>();
			//Text Category = display.transform.GetChild (2).gameObject.GetComponent<Text>();
			Text Price = display.transform.GetChild (3).gameObject.GetComponent<Text>();

			item.Name = NameField.text;
			Name.text = item.Name + " (" + ItemsForSale[itemObj] + ")";;

			//TODO Category dropdown

			try {   
				double priceInput = double.Parse(PriceField.text);
				item.Sell (priceInput);
				Price.text = "$" + priceInput;
			} catch {
				print ("Input Invalid!");
			}

		}
	}
}

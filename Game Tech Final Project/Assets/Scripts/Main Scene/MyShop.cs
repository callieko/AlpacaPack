using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyShop : MonoBehaviour {

	public GameObject EditItemWindow;

	public GameObject ShopItemDisplay;
	public GameObject ShopDisplayPanel;

	private MainManager m = MainManager.singleton;
	private MoneyManager wallet;
	private ItemManager playerItems;

	// Use this for initialization
	void Start () {
		wallet = m.GetComponent<MoneyManager> ();
		playerItems = m.GetComponent<ItemManager> ();

		EditItemWindow.SetActive(false);
	}

	/* Puts an item up for sale and adds it to the Shop Display window */
	public void DisplayItem (Item item) {
		GameObject display = Instantiate (ShopItemDisplay);

		GameObject Image = display.transform.GetChild (0).gameObject;
		GameObject Name = display.transform.GetChild (1).gameObject;
		GameObject Category = display.transform.GetChild (2).gameObject;
		GameObject Price = display.transform.GetChild (3).gameObject;
		GameObject EditButton = display.transform.GetChild (4).gameObject;

		Image.GetComponent<Image> ().sprite = item.GetThumbnail ();

		Name.GetComponent<Text> ().text = item.Name + " (" + playerItems.ItemsForSale[item] + ")";

		Category.GetComponent<Text> ().text = item.category.Name;

		Price.GetComponent<Text> ().text = "$" + item.GetSalePrice();

		EditButton.GetComponent<Button>().onClick.AddListener(delegate {EditItem(item, display);});

		display.transform.SetParent (ShopDisplayPanel.transform);
		ShopItemDisplay = display;
	}

	/* Called when the edit button is pressed on the the item. Brings up the edit window */
	public void EditItem (Item item, GameObject display) {

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
		AcceptButton.onClick.AddListener(delegate {EditExit(true, display, item);});
		CancelButton.onClick.AddListener(delegate {EditExit(false);});
	}

	/* When the item is actually sold */
	public void SellItem (Item item) {
		wallet.Transaction (item.GetSalePrice ());

		playerItems.ItemsForSale [item] -= 1;
		if (playerItems.ItemsForSale [item] == 0) {
			Destroy (ShopItemDisplay);
		} else {
			GameObject Name = ShopItemDisplay.transform.GetChild (1).gameObject;
			Name.GetComponent<Text> ().text = item.Name + " (" + playerItems.ItemsForSale[item] + ")";
		}
	}

	/* When the edits from the edit window are accepted or rejected */
	public void EditExit (bool accept, GameObject display = null, Item item = null) {

		EditItemWindow.SetActive(false);
		if (accept) {
			InputField NameField = EditItemWindow.transform.GetChild (3).GetComponent<InputField> ();
			//Dropdown Categories = EditItemWindow.transform.GetChild (5).GetComponent<Dropdown> ();
			InputField PriceField = EditItemWindow.transform.GetChild (7).GetComponent<InputField> ();

			Text Name = display.transform.GetChild (1).gameObject.GetComponent<Text>();
			//Text Category = display.transform.GetChild (2).gameObject.GetComponent<Text>();
			Text Price = display.transform.GetChild (3).gameObject.GetComponent<Text>();

			item.Name = NameField.text;
			Name.text = item.Name + " (" + playerItems.ItemsForSale[item] + ")";;

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

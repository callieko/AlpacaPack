using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

	public Text MoneyDisplay;

	public GameObject ItemDisplay;
	public GameObject ItemDisplayPanel;

	private MainManager m = MainManager.singleton;
	private MoneyManager wallet;
	private ItemManager playerItems;

	// Use this for initialization
	void Start () {
		wallet = m.GetComponent<MoneyManager> ();
		playerItems = m.GetComponent<ItemManager> ();


	}

	public void AddItem(Item item) {
		GameObject display = Instantiate (ItemDisplay);

		GameObject Image = display.transform.GetChild (0).gameObject;
		GameObject Name = display.transform.GetChild (1).gameObject;
		GameObject Category = display.transform.GetChild (2).gameObject;
		GameObject Quantity = display.transform.GetChild (3).gameObject;
		GameObject SellButton = display.transform.GetChild (4).gameObject;
		GameObject MakeButton = display.transform.GetChild (5).gameObject;

		Image.GetComponent<Image> ().sprite = item.GetThumbnail ();

		Name.GetComponent<Text> ().text = item.Name;

		string categories = Category.name;
		Category.GetComponent<Text> ().text = categories;

		Quantity.GetComponent<Text> ().text = "Quantity: " + playerItems.MyItems [item];

		SellButton.GetComponent<Button> ().onClick.AddListener (delegate {
			playerItems.SellItem (item);

		});

		Button mButton = MakeButton.GetComponent<Button> ();
		mButton.onClick.AddListener (delegate {
			playerItems.DuplicateItem (item);
		});
		mButton.transform.GetChild (0).gameObject.GetComponent<Text> ().text = "Make Duplicate ($" + item.GetMaterialCost () + ")";

		display.transform.SetParent (ItemDisplayPanel.transform);
	}
	
	// Update is called once per frame
	void Update () {
		MoneyDisplay.text = "$" + wallet.DisplayMoney;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShopManager : MonoBehaviour {

	public GameObject MaterialListing;

	public List<CraftMaterial> MaterialsForSale;
	public GameObject MaterialDisplayPanel;

	public GameObject PopUpWindow;

	private MoneyManager Wallet;
	private ItemManager PlayerItems;

	// Use this for initialization
	void Start () {
		Wallet = MainManager.singleton.GetComponent<MoneyManager> ();
		PlayerItems = MainManager.singleton.GetComponent<ItemManager> ();

		foreach (CraftMaterial materialObject in MaterialsForSale) {
			GameObject listing = Instantiate (MaterialListing);

			GameObject Image = listing.transform.GetChild (0).gameObject;
			GameObject Name = listing.transform.GetChild (1).gameObject;
			GameObject Price = listing.transform.GetChild (2).gameObject;

			Image ImageComp = Image.GetComponent<Image> ();
			ImageComp.sprite = materialObject.GetThumbnail ();

			Text NameText = Name.GetComponent<Text> ();
			NameText.text = materialObject.Name;

			Text PriceText = Price.GetComponent<Text> ();
			PriceText.text = "$" + materialObject.Value;

			Button btn = listing.GetComponent<Button>();
			btn.onClick.AddListener(delegate {BuyItem(materialObject);});

			listing.transform.SetParent (MaterialDisplayPanel.transform);
		}
	}

	public void BuyItem (CraftMaterial Item) {
		//if (Item.GetComponent<CraftMaterial>() != null) {
			print ("Attempting to buy " + Item.name);
			if (Wallet.Transaction (-Item.Value)) {
				ShowPopUp ("Purchase Successful");
				PlayerItems.GetMaterial (Item);
			}
			else
				ShowPopUp ("Insufficient Funds");
		//}
	}

	public void ShowPopUp (string msg) {
		GameObject parentCanvas = MaterialDisplayPanel.transform.parent.parent.parent.gameObject;
		Vector3 center = parentCanvas.GetComponent<RectTransform> ().position;
		GameObject window = Instantiate (PopUpWindow);//, new Vector3(center[0], center[1], 0), new Quaternion(0,0,0,0));
		window.transform.GetChild (0).GetComponent<Text> ().text = msg;
		window.transform.GetChild (2).GetComponent<Button> ().onClick.AddListener(delegate {DestroyWindow(window);});
		window.transform.SetParent (parentCanvas.transform);
		window.transform.Translate (new Vector3 (center [0], center [1], 0));
	}

	public void DestroyWindow (GameObject obj) {
		Destroy (obj);
	}
}

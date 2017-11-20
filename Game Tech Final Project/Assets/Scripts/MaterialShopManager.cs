using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShopManager : MonoBehaviour {

	public GameObject MaterialListing;

	public MoneyManager Wallet;
	public ItemManager PlayerItems;

	public List<GameObject> MaterialsForSale;
	public GameObject MaterialDisplayPanel;

	public GameObject PopUpWindow;

	// Use this for initialization
	void Start () {
		foreach (GameObject materialObject in MaterialsForSale) {
			GameObject listing = Instantiate (MaterialListing);

			GameObject Image = listing.transform.GetChild (0).gameObject;
			GameObject Name = listing.transform.GetChild (1).gameObject;
			GameObject Price = listing.transform.GetChild (2).gameObject;

			CraftMaterial singleMaterial = materialObject.GetComponent<CraftMaterial> ();

			Image ImageComp = Image.GetComponent<Image> ();
			ImageComp.sprite = singleMaterial.GetThumbnail ();

			Text NameText = Name.GetComponent<Text> ();
			NameText.text = materialObject.name;

			Text PriceText = Price.GetComponent<Text> ();
			PriceText.text = "$" + singleMaterial.Value;

			Button btn = listing.GetComponent<Button>();
			btn.onClick.AddListener(delegate {BuyItem(materialObject);});

			listing.transform.SetParent (MaterialDisplayPanel.transform);
		}
	}

	public void BuyItem (GameObject Item) {
		if (Item.GetComponent<CraftMaterial>() != null) {
			print ("Attempting to buy " + Item.name);
			if (Wallet.Transaction (-Item.GetComponent<CraftMaterial> ().Value)) {
				ShowPopUp ("Purchase Successful");
				PlayerItems.GetMaterial (Item);
			}
			else
				ShowPopUp ("Insufficient Funds");
		}
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

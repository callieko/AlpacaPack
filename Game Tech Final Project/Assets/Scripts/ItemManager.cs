using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Dictionary<GameObject, int> MyItems;
	public Dictionary<GameObject, int> MyMaterials;

	public GameObject ItemDisplay;
	public GameObject ItemDisplayPanel;

	// Use this for initialization
	void Start () {
		MyItems = new Dictionary<GameObject, int> ();
		MyMaterials = new Dictionary<GameObject, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeItem (GameObject itemObj) {

		if (MyItems.ContainsKey (itemObj)) {
			MyItems [itemObj] = MyItems [itemObj] + 1;
		} else {
			MyItems.Add (itemObj, 1);
		}

		GameObject display = Instantiate (ItemDisplay);

		GameObject Image = display.transform.GetChild (0).gameObject;
		GameObject Name = display.transform.GetChild (1).gameObject;
		GameObject Category = display.transform.GetChild (2).gameObject;
		GameObject Quantity = display.transform.GetChild (3).gameObject;
		GameObject SellButton = display.transform.GetChild (4).gameObject;
		GameObject MakeButton = display.transform.GetChild (5).gameObject;

		Item item = itemObj.GetComponent<Item> ();

		Image.GetComponent<Image> ().sprite = item.GetThumbnail ();

		Name.GetComponent<Text> ().text = item.Name;

		string categories = "";
		int index = 0;
		foreach (Category C in item.Categories) {
			categories += C.Name;
			if (item.Categories.Count > 1 && index < item.Categories.Count - 1)
				categories += ", ";
			index++;
		}
		Category.GetComponent<Text> ().text = categories;

		Quantity.GetComponent<Text> ().text = "Quantity: " + MyItems[itemObj];

		SellButton.GetComponent<Button>().onClick.AddListener(delegate {SellItem(itemObj);});

		Button mButton = MakeButton.GetComponent<Button> ();
		mButton.onClick.AddListener(delegate {DuplicateItem(itemObj);});
		mButton.transform.GetChild (0).gameObject.GetComponent<Text> ().text = "Make Duplicate ($" + item.GetMaterialCost () + ")";

		display.transform.SetParent (ItemDisplayPanel.transform);
	}

	public void DuplicateItem (GameObject item) {
	}

	public void SellItem (GameObject item) {

	}

	public void GetMaterial (GameObject material) {
		
		if (MyMaterials.ContainsKey (material)) {
			MyMaterials [material] = MyMaterials [material] + 1;
		} else {
			MyMaterials.Add (material, 1);
		}
	}

	public bool UseMaterial (GameObject material, int Number = 1) {
		if (MyMaterials.ContainsKey (material) && MyMaterials[material] <= Number) {
			MyMaterials [material] -= Number;
			if (MyMaterials [material] == 0)
				MyMaterials.Remove (material);
			return true;
		}
		return false;
	}
}

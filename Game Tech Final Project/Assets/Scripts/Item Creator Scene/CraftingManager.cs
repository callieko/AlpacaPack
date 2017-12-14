using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour {

	public GameObject SceneObjectPrefab;

	public GameObject MaterialListing;
	public GameObject MaterialDisplayPanel;
	public GameObject Item;

	public GameObject SaveWindow;

	private MenuManager menuManager;
	public EditMenuManager editMenuManager;
	public onMouseDrag onMouseDragFile;
	public GameObject moveManipulator;
	public GameObject scaleManipulator;
	public bool manipulator;
	public List<CraftMaterial> CurrentlyUsedMaterials;

	private ItemManager PlayerItems;

	// Use this for initialization
	void Start () {
		PlayerItems = MainManager.singleton.GetComponent<ItemManager> ();
		menuManager = gameObject.GetComponent<MenuManager> ();

		CurrentlyUsedMaterials = new List<CraftMaterial> ();

		foreach (CraftMaterial materialObject in PlayerItems.MyMaterials.Keys) {
			GameObject listing = Instantiate (MaterialListing);

			GameObject Image = listing.transform.GetChild (0).gameObject;
			GameObject Name = listing.transform.GetChild (1).gameObject;
			GameObject Count = listing.transform.GetChild (2).gameObject;

			Image ImageComp = Image.GetComponent<Image> ();
			ImageComp.sprite = materialObject.GetThumbnail ();

			Text NameText = Name.GetComponent<Text> ();
			NameText.text = materialObject.name;

			Text CountText = Count.GetComponent<Text> ();
			CountText.text = "" + MainManager.singleton.GetComponent<ItemManager>().MyMaterials[materialObject];

			Button btn = listing.GetComponent<Button>();
			btn.onClick.AddListener(delegate {UseMaterial(materialObject, listing);});

			listing.transform.SetParent (MaterialDisplayPanel.transform);
		}
	}

	void UseMaterial(CraftMaterial materialObject, GameObject listing) {
		if (PlayerItems.MyMaterials [materialObject] > 0) {
			print ("USED: " + materialObject.Name);
			CurrentlyUsedMaterials.Add (materialObject);
			PlayerItems.MyMaterials [materialObject] -= 1;
		} else {
			print ("UNABLE TO USE: " + materialObject.Name);
			return;
		}

		if (PlayerItems.MyMaterials [materialObject] == 0) {
			listing.SetActive (false);
			PlayerItems.MyMaterials.Remove (materialObject);
		} else {
			GameObject Count = listing.transform.GetChild (2).gameObject;
			Text CountText = Count.GetComponent<Text> ();
			CountText.text = "" + PlayerItems.MyMaterials [materialObject];
		}
		menuManager.ChangeMenu (MaterialDisplayPanel.transform.parent.parent.parent.gameObject);

		GameObject obj = Instantiate (SceneObjectPrefab);
		obj.transform.SetParent (Item.transform);
		MeshFilter objMesh = obj.GetComponent<MeshFilter> ();
		objMesh.mesh = materialObject.ObjectMesh;
		obj.transform.SetPositionAndRotation (new Vector3 (0, 0, 0), new Quaternion(0,0,0,1));

		// The new object needs to be manually given it's mesh type
		MeshCollider objCollider = obj.GetComponent<MeshCollider> ();
		objCollider.sharedMesh = materialObject.ObjectMesh;

		MeshRenderer objRenderer = obj.GetComponent<MeshRenderer> ();
		objRenderer.material = materialObject.ObjectMaterial;

		// The new object needs to be manually given the menu object
		onMouseDrag objOND = obj.GetComponent<onMouseDrag> ();
		objOND.editMenuManager = editMenuManager;
		objOND.moveManipulator = moveManipulator;
		objOND.scaleManipulator = scaleManipulator;
	}
		
	// This doesn't work right now
	void UnuseMaterial(GameObject obj, GameObject listing) {
		CraftMaterial materialObject = obj.GetComponent<CraftMaterial>();

		if (PlayerItems.MyMaterials.ContainsKey (materialObject))
			PlayerItems.MyMaterials [materialObject] = PlayerItems.MyMaterials [materialObject] + 1;
		else
			PlayerItems.MyMaterials.Add (materialObject, 1);

		if (PlayerItems.MyMaterials [materialObject] > 0) {
			listing.SetActive (true);

			GameObject Count = listing.transform.GetChild (2).gameObject;
			Text CountText = Count.GetComponent<Text> ();
			CountText.text = "" + PlayerItems.MyMaterials [materialObject];
		}

		Destroy (obj);
	}

	public void SaveItem () {
		InputField NameField = SaveWindow.transform.GetChild (2).GetComponent<InputField> ();
		//Dropdown Categories = SaveWindow.transform.GetChild (4).GetComponent<Dropdown> ();
		InputField PriceField = SaveWindow.transform.GetChild (6).GetComponent<InputField> ();

		//TODO Category dropdown

		Item i = ScriptableObject.CreateInstance<Item>();

		i.Name = NameField.text;

		try {   
			double priceInput = double.Parse(PriceField.text);
			i.Sell (priceInput);
		} catch {
			print ("Input Invalid!");
		}

		i.Materials = CurrentlyUsedMaterials;
		i.Meshes = Item;
		i.category = ScriptableObject.CreateInstance<Category> ();
		i.category.name = "Paper Weight";
		PlayerItems.MakeItem(i);
	}
}

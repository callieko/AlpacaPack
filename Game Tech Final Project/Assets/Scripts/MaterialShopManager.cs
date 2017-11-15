using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShopManager : MonoBehaviour {

	public List<CraftMaterial> MaterialsForSale;
	public GameObject MaterialDisplayPanel;

	// Use this for initialization
	void Start () {
		foreach (CraftMaterial singleMaterial in MaterialsForSale) {
			GameObject listing = singleMaterial.GetListing ();
			listing.transform.SetParent (MaterialDisplayPanel.transform);
		}
	}
}

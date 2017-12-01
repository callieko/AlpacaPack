using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	/*
	public GameObject ShopMenu;
	public GameObject WorkshopMenu;
	public GameObject BuyShopMenu;
	public GameObject ToolsShopMenu;
	public GameObject MaterialsShopMenu;
	public GameObject SettingsMenu;
	*/

	public GameObject PopUpWindow;

	private GameObject currentMenu = null;

	// Use this for initialization
	void Start () {
		/*
		ShopMenu.SetActive (false);
		WorkshopMenu.SetActive (false);
		MaterialsMenu.SetActive (false);
		SettingsMenu.SetActive (false);
		*/
	}


	/* A function that is called by button that changes what menu is being shown */
	public void ChangeMenu (GameObject nextMenu) {
		/*//Find which menu the index is referring to
		GameObject nextMenu = null;
		switch (nextMenuIndex) {
		case 1:
			nextMenu = ShopMenu;
			break;
		case 2:
			nextMenu = WorkshopMenu;
			break;
		case 3:
			nextMenu = BuyShopMenu;
			break;
		case 4:
			nextMenu = SettingsMenu;
			break;
		case 5:
			nextMenu = ToolsShopMenu;
			break;
		case 6:
			nextMenu = MaterialsShopMenu;
			break;
		}*/


		//Index does not refer to any menu
		if (nextMenu == null)
			return;
			
		//Hide the current menu, if there is one
		if (currentMenu != null && currentMenu != nextMenu)
			currentMenu.SetActive (false);

		//Toggle activation of requested menu, allows for menu to be hidden by pressing the button
		//for this menu while it is active
		nextMenu.SetActive (!(nextMenu.activeInHierarchy));

		//Set currentMenu
		if (nextMenu.activeSelf)
			currentMenu = nextMenu;
		else
			currentMenu = null;
	}

	public void ShowPopUp (string msg) {
		GameObject window = Instantiate (PopUpWindow);
		window.transform.GetChild (0).GetComponent<Text> ().text = msg;
		window.transform.GetChild (1).GetComponent<Button> ().onClick.AddListener(delegate {DestroyWindow(window);});
		//window.transform.SetParent (MaterialDisplayPanel.transform);
	}

	public void DestroyWindow (GameObject obj) {
		Destroy (obj);
	}

	public void GoToItemCreation() {
		SceneManager.LoadScene (2);

	}
}

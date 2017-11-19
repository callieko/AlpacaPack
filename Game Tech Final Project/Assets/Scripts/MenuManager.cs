using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public GameObject ShopMenu;
	public GameObject WorkshopMenu;
	public GameObject MaterialsMenu;
	public GameObject SettingsMenu;

	private GameObject currentMenu = null;

	// Use this for initialization
	void Start () {
		ShopMenu.SetActive (false);
		WorkshopMenu.SetActive (false);
		MaterialsMenu.SetActive (false);
		SettingsMenu.SetActive (false);
	}


	/* A function that is called by button that changes what menu is being shown */
	public void ChangeMenu (int nextMenuIndex) {
		//Find which menu the index is referring to
		GameObject nextMenu = null;
		switch (nextMenuIndex) {
		case 1:
			nextMenu = ShopMenu;
			break;
		case 2:
			nextMenu = WorkshopMenu;
			break;
		case 3:
			nextMenu = MaterialsMenu;
			break;
		case 4:
			nextMenu = SettingsMenu;
			break;
		}

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
}

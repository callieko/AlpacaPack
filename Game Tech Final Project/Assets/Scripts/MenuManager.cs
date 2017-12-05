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
		//Rect popUpRect = PopUpWindow.GetComponent<Rect> ();
	}


	/* A function that is called by button that changes what menu is being shown */
	public void ChangeMenu (GameObject nextMenu) {
			
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

		//TODO HEY LINH! This part is causing a Null Pointer Exception in scenes other than the Item Creator.
		//If you could find another wasy to do this that'd be ideal

		// If the EditMenuManager menu was open and is toggled off,
		// reset the currentEditMode to None to ensure the objects cannot be messed with.
		EditMenuManager editMenuManager = GameObject.Find("EditMenuManager").GetComponent<EditMenuManager>();
		if (editMenuManager != null) {
			editMenuManager.currentEditMode = EditMenuManager.EditMode.None;
		}
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

	public void GoToMainGame() {
		SceneManager.LoadScene (1);
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject PopUpWindow;

	private GameObject currentMenu = null;

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

	public void GoToScene(int sceneNumber) {
		SceneManager.LoadScene (sceneNumber);
	}
}

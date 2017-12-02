using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDrag : MonoBehaviour {

	public GameObject currentMode

	private GameObject currentMenu = null;

	float distance = 10;

	// On mouse drag (https://www.youtube.com/watch?v=pK1CbnE2VsI)
	void OnMouseDrag() {
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objectPos = Camera.main.ScreenToWorldPoint (mousePos);

		transform.position = objectPos;
	}

	/* A function that is called by button that changes what menu is being shown */
	public void ChangeMenu (GameObject nextMenu) {
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

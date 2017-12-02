using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditMenuManager : MonoBehaviour {

	private GameObject currentEditMode = null;

	/* A function that is called by button that changes what edit mode is activated */
	public void ChangeEditMode (GameObject nextEditMode) {
		//Index does not refer to any menu
		if (nextEditMode == null)
			return;

		//Hide the current edit mode, if there is one
		if (currentEditMode != null && currentEditMode != nextEditMode)
			currentEditMode.SetActive (false);

		//Toggle activation of requested menu, allows for menu to be hidden by pressing the button
		//for this menu while it is active
		nextEditMode.SetActive (!(nextEditMode.activeInHierarchy));

		//Set currentEditMode
		if (nextEditMode.activeSelf)
			currentEditMode = nextEditMode;
		else
			currentEditMode = null;
	}
}

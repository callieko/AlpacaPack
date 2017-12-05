using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditMenuManager : MonoBehaviour {

	public EditMode currentEditMode;

	public enum EditMode
	{
		None,
		Move,
		Rotate,
		Scale,
		Snap,
		Remove
	}

	void Start () {
		currentEditMode = EditMode.None;
	}

	public void ChangeEditMode (int nextEditMode) {
		print ("The editMode is: " + currentEditMode.ToString());
		currentEditMode = (EditMode)nextEditMode;
	}
}

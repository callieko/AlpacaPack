using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDrag : MonoBehaviour {

	public EditMenuManager editMenuManager;
	// Variables for move
	private float distance = 10f;
	// Variables for rotation
	private float rotationSpeed = 20f;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	// Variables for scale
	private float starting = 0f;
	private float shrinkScale = 0.5f;
	private float enlargeScale = 2f;

	public GameObject moveManipulator;
	public GameObject scaleManipulator;
	private GameObject createdMoveManip;
	private GameObject createdScaleManip;

	void Start () {
		starting = Input.mousePosition.x;
	}

	// Move object: (https://www.youtube.com/watch?v=pK1CbnE2VsI)
	// Rotate object: (https://www.youtube.com/watch?v=S3pjBQObC90)
	//                (https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera)
	// Scaling object: (https://stackoverflow.com/questions/19034528/game-in-unity3d-scaling-objects-with-mouse-in-c-sharp)
	void OnMouseDrag() {
		switch (editMenuManager.currentEditMode) {
			case EditMenuManager.EditMode.None:
					break;
			case EditMenuManager.EditMode.Move:
				print ("Old movement");
				Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
				Vector3 objectPos = Camera.main.ScreenToWorldPoint (mousePos);
				transform.position = objectPos;
				break;
			case EditMenuManager.EditMode.Rotate:
				yaw -= Input.GetAxis("Mouse X") * rotationSpeed;
				pitch += Input.GetAxis("Mouse Y") * rotationSpeed;
				transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
				break;
			case EditMenuManager.EditMode.Scale:
				print ("Old scale");
				// Currently doing scale based upon the change in x position only.
				if (starting > Input.mousePosition.x) {
					Vector3 v3Scale = new Vector3 (shrinkScale, shrinkScale, shrinkScale);
					transform.localScale = Vector3.Lerp (transform.localScale, v3Scale, Time.deltaTime);
				} else if (starting < Input.mousePosition.x) {
					Vector3 v3Scale = new Vector3 (enlargeScale, enlargeScale, enlargeScale);
					transform.localScale = Vector3.Lerp (transform.localScale, v3Scale, Time.deltaTime);
				}
				starting = Input.mousePosition.x;
				break;
			case EditMenuManager.EditMode.Snap:
				break;
			case EditMenuManager.EditMode.Remove:
				Destroy(gameObject);
				// INSERT HERE CODE TO CALL CRAFTINGMANAGER.CS 'S UNUSEMATERIAL() METHOD.
				break;
		}
	}

	void OnMouseDown()
	{
		print ("OnMouseDown() activiated");

		Destroy (createdMoveManip);
		Destroy (createdScaleManip);

		float scaleX = gameObject.transform.localScale.x * 0.2f;
		float scaleY = gameObject.transform.localScale.y * 0.2f;
		float scaleZ = gameObject.transform.localScale.z * 0.2f;

		switch (editMenuManager.currentEditMode) {
		case EditMenuManager.EditMode.None:
			print ("OnMouseDown() no mode");
			break;
		case EditMenuManager.EditMode.Move:
			print ("OnMouseDown() move");
//			createdMoveManip = Instantiate (moveManipulator, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
//			createdMoveManip.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
//			createdMoveManip.transform.SetParent (gameObject.transform);
			break;
		case EditMenuManager.EditMode.Scale:
			print ("OnMouseDown() scale");
//			createdScaleManip = Instantiate (scaleManipulator, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
//			createdScaleManip.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
//			createdScaleManip.transform.SetParent (gameObject.transform);
			break;
		}
		print ("OnMouseDrag() end");
	}

}

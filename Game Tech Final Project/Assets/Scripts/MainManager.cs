using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	public static MainManager singleton;

	void Awake () {
		if (singleton == null) {
			DontDestroyOnLoad (gameObject);
			singleton = this;
		} else if (singleton != null) {
			Destroy (gameObject);
		}
	}
}

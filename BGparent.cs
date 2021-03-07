using UnityEngine;
using System.Collections;

public class BGparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (AppController.bgCheck) {
			Destroy (this.gameObject);
			AppController.bgCheck = false;
		}
	
	}


}

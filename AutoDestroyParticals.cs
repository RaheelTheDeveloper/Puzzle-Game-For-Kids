using UnityEngine;
using System.Collections;

public class AutoDestroyParticals : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
			if (AppController.Is_particle) {
			
				AppController.Is_particle = false;
				Destroy (this.gameObject);


			}

	
	}
}

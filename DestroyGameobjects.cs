using UnityEngine;
using System.Collections;

public class DestroyGameobjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
		if(AppController.destroyCheck){
			
			Destroy (this.gameObject);
			Invoke ("CloneDestroy", 0.1f);
		}
	}

	void CloneDestroy(){
		AppController.destroyCheck = false;
	}
}

using UnityEngine;
using System.Collections;

public class LoadGamePlay : MonoBehaviour {

	public GameObject levelToLoad;

	//public GameObject refreshBtn;
	// Use this for initialization
	void Start () {
		AppController.Is_particle = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Utility.isClicked_2D(GetComponent<Collider2D>())&&gameObject.activeSelf) {
			//Destroy (refreshBtn);
			//gameObject.SetActive (false);

			AppController.destroyCheck = false;
			AppController.bgCheck = true;
			AppController.Is_particle = true;
			GameObject g = Instantiate (levelToLoad) as GameObject;
			Destroy (transform.parent.gameObject);
			//Debug.Log ("PHade Wala Check"+AppController.destroyCheck);
			//Destroy(this.gameObject);

		}


	}
}

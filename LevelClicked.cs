using UnityEngine;
using System.Collections;

public class LevelClicked : MonoBehaviour {
	public GameObject parent;
	public string spawningLevel;
	AudioClip click;
	public static GameObject winParticles;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Utility.isClicked_2D(GetComponent<Collider2D>())) {


				AppController.Is_particle = true;
			//Debug.Log (AppController.Is_particle);

			if (AppController.isSound) {
				gameObject.AddComponent<AudioSource> ();
				click = Resources.Load ("ButtonClick") as AudioClip;
				gameObject.AddComponent<AudioSource> ().PlayOneShot (click, 1f);
			}
			
			Utility.count = 0;
			AppController.destroyCheck = true;
			Invoke ("Fun", 0.001f);


		}
	}

	void Fun(){
		AppController.destroyCheck = false;
		parent.SendMessage (spawningLevel);

		AppController.Is_particle = false;


	}
}

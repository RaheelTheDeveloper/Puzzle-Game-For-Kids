using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PuzzleLevelLoad : MonoBehaviour {
	public int loadLevel;
	AudioSource click;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Utility.isClicked_2D(GetComponent<Collider2D>())) {
			if (AppController.isSound) {
				click = GetComponent<AudioSource> ();
				click.Play ();
			}
			Utility.count = 0;
			AppController.destroyCheck = false;
			//Application.LoadLevel (loadLevel);
			Invoke("witch",1);


		}
	}
	void witch()
	{
		SceneManager.LoadScene (loadLevel);
	}
}

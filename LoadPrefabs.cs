using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadPrefabs : MonoBehaviour {
	public GameObject prefabToLoad;
	public GameObject Panel;
	public GameObject back;
	public GameObject home;

	public int myVal;


	public void PrefabLoad()
	{
//		if (AppController.isSound) {
//			click = GetComponent<AudioSource> ();
//			click.Play ();
//		}
		//Debug.Log ("Clicked On Puzzle");
		GameObject background = GameObject.Find ("ScrollBG");
		background.SetActive (false);


		AppController.mainPlayActive = myVal;
		GameObject gm = Instantiate (prefabToLoad) as GameObject;
		Panel.SetActive (false);
		back.SetActive (false);
		home.SetActive (true);
	
	}


}

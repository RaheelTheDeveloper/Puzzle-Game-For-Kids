using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {
	public bool detected = false;
	public int checkFinish;
	private Vector3 offset;
	public GameObject go1;
	public GameObject go2;
	public GameObject bg;
	public int count = 0;
	//public int order = 1;
	public static bool Check;
	private bool chk = false;
	private float tparam = 0;
	public bool isLastPuzzle;
	Vector3 start;
	Vector3 end;
	AudioClip click;
	AudioSource shot;

	public GameObject nextLevel;

	void Fun(){
		if (!isLastPuzzle) {
			nextLevel = GameObject.FindGameObjectWithTag ("puzzle").gameObject.GetComponent<EasyMediumHardspawning> ().arrow;

		}

	}
	void Start () {
		
		Invoke ("Fun", 0.5f);
		end = new Vector3 (go2.transform.position.x, go2.transform.position.y, go2.transform.position.z);
		bg.SetActive (false);
	}

	void Update () {
		
			//Debug.Log (Utility.count);
		if (Utility.isClicked_2D (go1.GetComponent<Collider2D> ())) {
		//	Debug.Log ("Collider clicked");
			detected = true;
			Check = true;
			offset = new Vector2 (transform.position.x - Utility.getPositionVector2 ().x, transform.position.y - Utility.getPositionVector2 ().y);
				
			go1.transform.localScale  = new Vector3 (1f, 1f, 1);

			go1.GetComponent<SpriteRenderer> ().sortingOrder = 3;


		}

		if (chk) {
			BoundInterSect ();
		}

			
		if (detected) {
			drag ();
		}
		if (Utility.getTouched_Phase2D (0) == TouchPhase.Ended) {
			detected = false;
			go1.GetComponent<SpriteRenderer> ().sortingOrder = 2;

			if (go1.transform.position == go2.transform.position) {
				go1.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}

			if (go1.GetComponent<Collider2D> ().enabled == true) {
				if (go1.GetComponent<Collider2D> ().bounds.Intersects (go2.GetComponent<Collider2D> ().bounds)) {

//					Debug.Log ("Intersects");
					chk = true;
			//		BoundInterSect ();

				}

			}
		}

		if(AppController.destroyCheck){
			Destroy (this.gameObject);
			Invoke ("CloneDestroy", 0.1f);
		}

	}

	void BoundInterSect(){
		if (go1.transform.position != go2.transform.position) {
//			Debug.Log ("Entered");
			if (tparam < 1) {
				tparam += 0.09f;
				go1.transform.position = new Vector3 (Mathf.Lerp (transform.position.x, end.x, tparam), Mathf.Lerp (transform.position.y, end.y, tparam), 0);
				go1.GetComponent<Collider2D> ().enabled = false;
			}
		} 
		if (Check) {
			if (go1.transform.position == go2.transform.position) {
				
				go1.GetComponent<Collider2D> ().enabled = false;
				go1.GetComponent<SpriteRenderer> ().sortingOrder = 1;

				//Sounds
				if (AppController.isSound) {
					go1.AddComponent<AudioSource> ();
					click = Resources.Load ("tap") as AudioClip;
					go1.AddComponent<AudioSource> ().PlayOneShot (click, 1f);
				}


//				Debug.Log ("ColliderFalsed");
				Check = false;
				chk = false;
				Utility.count++;
//				Debug.Log (Utility.count);


				if (Utility.count == checkFinish) {

					//Debug.Log ("win");
					AppController.bgCheck = false;
					bg.SetActive (true);
					Utility.count = 0;
					Check = false;
					//Invoke ("FUn", 1f);


					//Particle Systems

					GameObject winParticles = Instantiate(Resources.Load("FinishStars") as GameObject);
					ParticleSystem heal = winParticles.GetComponent<ParticleSystem> ();
					heal.Play ();
//					heal.transform.localPosition = new Vector3 (-2.9f, 0.3f, 0);
					Destroy (winParticles, 6f);
					Debug.Log (winParticles);

					//




					//Sounds
					if (AppController.isSound) {
						bg.AddComponent<AudioSource> ();
						click = Resources.Load ("clapping") as AudioClip;
						bg.AddComponent<AudioSource> ().PlayOneShot (click, 1f);
					}
					//

					if (!isLastPuzzle) {

						nextLevel.SetActive (true);
						nextLevel.transform.localPosition = new Vector3 (5.66f,0.17f,0);

					}



					//AppController.destroyCheck = true;

					Invoke ("FUn", 0.2f);

				}

			}
		}


	
	
	}




	void FUn(){
		AppController.destroyCheck = true;

	}

	void drag() {
		transform.position = new Vector3(offset.x + Utility.getPositionVector2().x, offset.y + Utility.getPositionVector2().y, transform.position.z);
	}

	void CloneDestroy(){
		AppController.destroyCheck = false;
	}


}

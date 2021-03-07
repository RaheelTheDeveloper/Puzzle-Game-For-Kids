using UnityEngine;
using System.Collections;

public class InjectionTask : MonoBehaviour {
	public bool detected=false;
	private Vector3 offset;
	private Vector3 initialPos;
	public GameObject injection;
	private Vector3 screenpoint;
	private Vector3 worldpoint;
	public GameObject injection2;
	public GameObject injection1;
	public GameObject injection3;
	public GameObject hand1;
	public GameObject hand2;
	public GameObject hand3;
	int clickcounter=0;
	private bool h1,h2,h3;
	//public GameObject injectionother;


	// Use this for initialization
	void Start () {
	
		initialPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utility.isTouched ()) {
			
			if (Utility.isClicked_2D (GetComponent<Collider2D> ())&&!AppController._isDialogue) {
				detected = true;
				if (AppController.isMusic){
					if (!GetComponent<AudioSource>().isPlaying) {
						GetComponent<AudioSource>().Play();
					}
				}
				if(!h1){
				hand1.SetActive(true);

				}
				if(!h2){
					hand2.SetActive(true);
				}
				if(!h3){
					hand3.SetActive(true);
				}
				offset = new Vector2 (transform.position.x - Utility.getPositionVector2 ().x, transform.position.y - Utility.getPositionVector2 ().y);
			}
			
			if (detected) {
				drag ();
			}
			
			if (Utility.getTouched_Phase2D (0) == TouchPhase.Ended) {
				detected = false;
//				if(h1){
//					
//					hand1.SetActive(false);
//				}
//				if(h2){
//					
//					hand2.SetActive(false);
//				}
//				if(h3){
//					
//					hand3.SetActive(false);
//				}
				hand1.SetActive(false);
				hand2.SetActive(false);
				hand3.SetActive(false);
				transform.position = initialPos;
			}
		
		}
	}
	void drag()
		{
		if (gameObject.GetComponent<Collider2D> ().bounds.Intersects (injection.GetComponent<Collider2D> ().bounds) && injection.GetComponent<Collider2D>().enabled) {

			injection.SetActive (true);
			//AppController.isDialogue=true;
			hand1.SetActive(false);
			h1 = true;
			injection2.GetComponent<SpriteRenderer> ().enabled = false;
			injection.GetComponent<Collider2D>().enabled=false;


		}
		if (gameObject.GetComponent<Collider2D> ().bounds.Intersects (injection1.GetComponent<Collider2D> ().bounds) && injection1.GetComponent<Collider2D>().enabled) {
	
			injection1.SetActive (true);
			hand2.SetActive(false);
			//AppController.isDialogue=true;
			h2 = true;
			injection2.GetComponent<SpriteRenderer> ().enabled = false;	
			injection1.GetComponent<Collider2D>().enabled=false;
	}
		if (gameObject.GetComponent<Collider2D> ().bounds.Intersects (injection3.GetComponent<Collider2D> ().bounds) && injection3.GetComponent<Collider2D>().enabled) {
			
			injection3.SetActive (true);
			hand3.SetActive(false);
			//AppController.isDialogue=true;
			h3= true;
			
			injection2.GetComponent<SpriteRenderer> ().enabled = false;
			injection3.GetComponent<Collider2D>().enabled=false;
		}
		transform.position = new Vector3(offset.x + Utility.getPositionVector2().x, offset.y + Utility.getPositionVector2().y, transform.position.z);
	}
}

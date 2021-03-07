using UnityEngine;
using System.Collections;

public class SetRandOmSprite : MonoBehaviour {
	public GameObject[] items;
	ArrayList generatedItems;
	public GameObject[] childrens;
	private int childCounter;
	public int childCounterFinish;
	// Use this for initialization
	void Start () {
		
		childCounter = 0;
		generatedItems = new ArrayList ();
		//Debug.Log ("StartFunction");
		GetSprite ();

		for (int i = 0; i < childrens.Length; i++) {


			childrens [i].AddComponent<AnimControl> ();
		}

		Invoke ("GOdestory",0.1f);
	}
		

	void GetSprite(){
//		Debug.Log ("Random Sprite Funcation");
		int tempno = Random.Range (0, items.Length);
//		Debug.Log (tempno + "Number");
		int counter = 0;

		if (generatedItems.Count > 0) {
			for (int i = 0; i < generatedItems.Count; i++) {
				int nUmber = (int)generatedItems [i];
				if (tempno == nUmber) {
					counter++;
//					Debug.Log ("Counter problem");
				}
			}
//			Debug.Log ("Problem Here");

			if (counter > 0) {
//				Debug.Log ("Problem");
				GetSprite ();
			} else {
				generatedItems.Add (tempno);
				childrens [childCounter] = Instantiate (items [tempno], new Vector2 (childrens [childCounter].transform.position.x, childrens [childCounter].transform.position.y), Quaternion.identity) as GameObject;
			//	Debug.Log ("Instentient");
				//childrens [childCounter].SetActive (false);
				//items [tempno].SetActive (true);
		

				childCounter++;
				if (childCounter < childCounterFinish) {
					GetSprite ();
				}
			}

		} else {
			generatedItems.Add (tempno);
			childrens [childCounter] = Instantiate (items [tempno], new Vector2 (childrens [childCounter].transform.position.x, childrens [childCounter].transform.position.y), Quaternion.identity) as GameObject;
			//childrens [childCounter].SetActive (false);
			childCounter++;
			GetSprite ();

		}
	}

	void GOdestory(){

		Destroy (this.gameObject);


	}


}

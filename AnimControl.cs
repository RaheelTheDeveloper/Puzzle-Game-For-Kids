using UnityEngine;
using System.Collections;

public class AnimControl : MonoBehaviour {

	Vector3 finalPos,initialPos;
	float tparam;

	void Awake()
	{
		finalPos = transform.localPosition;
//		Debug.Log (transform.localPosition);
		transform.localPosition = new Vector3 (transform.localPosition.x, 5.83f, 0);
//		Debug.Log (transform.localPosition);
		initialPos = transform.localPosition;

//		if (transform.localPosition.x < 0) {
//
//			transform.localPosition = new Vector3 (transform.localPosition.x, 5.83f, 0);
//		} else
//		{
//			transform.localPosition = new Vector3 (transform.localPosition.x, 5.83f, 0);
//		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (tparam < 1) {
			//tparam += Time.deltaTime;
			tparam += 0.05f;
			transform.localPosition = new Vector3 (Mathf.Lerp (initialPos.x, finalPos.x, tparam), Mathf.Lerp (initialPos.y, finalPos.y, tparam), 0);
		}
		if (tparam > 1) {
			transform.transform.localPosition = finalPos;
			GetComponent<AnimControl> ().enabled = false;
		}

	}
}

using UnityEngine;
using System.Collections;

public class DialougeOperations : MonoBehaviour {

	void OnEnable(){
		AppController._isDialog = true;
	}

	void OnDisable(){
		AppController._isDialog = false;
	}
}

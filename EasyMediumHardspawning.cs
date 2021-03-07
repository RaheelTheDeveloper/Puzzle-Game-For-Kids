using UnityEngine;
using System.Collections;

public class EasyMediumHardspawning : MonoBehaviour {
	public string easy, medium, hard;
	public GameObject arrow;
	GameObject gm;

//	void common(string folder,string type)
//	{
//		Instantiate(Resources.Load (folder+type)as GameObject);
//		Destroy (this.gameObject);
//	}


	public void SpawnEasy(){

		//common ("SeaLifePrefabs/",easy);
		gm = Instantiate(Resources.Load ("SeaLifePrefabs/"+easy)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);
	}


	public void SpawnMedium(){
		gm = Instantiate (Resources.Load("SeaLifePrefabs/"+medium)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);

	}


	public void SpawnHard(){
		gm = Instantiate (Resources.Load("SeaLifePrefabs/"+hard)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);

	}

	public void SpawnAnimalEasy(){
		gm = Instantiate(Resources.Load ("AnimalPrefabs/"+easy)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);
	}

	public void SpawnAnimalMedium(){
		gm = Instantiate (Resources.Load("AnimalPrefabs/"+medium)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);

	}

	public void SpawnAnimalHard(){
		gm = Instantiate (Resources.Load("AnimalPrefabs/"+hard)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);

	}

	public void SpawnBirdEasy(){
		gm = Instantiate(Resources.Load ("BirdPrefabs/"+easy)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);
	}

	public void SpawnBirdMedium(){
		gm = Instantiate (Resources.Load("BirdPrefabs/"+medium)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);

	}

	public void SpawnBirdHard(){
		gm = Instantiate (Resources.Load("BirdPrefabs/"+hard)as GameObject);
//		gm.transform.localPosition = new Vector3 (0,.5f,0);
		Destroy (this.gameObject);

	}

}

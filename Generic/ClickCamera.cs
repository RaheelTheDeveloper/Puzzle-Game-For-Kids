using UnityEngine;
using System.Collections;
using System.IO;
//using ChartboostSDK;

public class ClickCamera : MonoBehaviour {

    public bool ScreenShort;

    public SpriteRenderer[] sp;
    public GameObject[] HideShow;
    public GameObject saveCall;
	private Vector3 touchPosition3;
	private Vector2 touchPosition2;
	private bool detected = false;
	private SpriteRenderer selfRenderer;

    private string screenShotName = "HalloweenBookColoringPages";
	private int screenShotNumber = 0;
	private string ssName;
	
	AndroidJavaObject playerActivityContext ;
	AndroidJavaObject gallery ;
	
	void Start () {

		selfRenderer = GetComponent<SpriteRenderer> ();

		AndroidJavaObject actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		playerActivityContext =  actClass.GetStatic<AndroidJavaObject>("currentActivity");
		gallery = new AndroidJavaObject("com.icaw.galleryupdate.GalleryUpdate");

		if (!PlayerPrefs.HasKey ("ScreenShot")) {
			PlayerPrefs.SetInt ("ScreenShot", screenShotNumber);
			PlayerPrefs.Save ();
		} else
			screenShotNumber = PlayerPrefs.GetInt ("ScreenShot");

		CreateFolder ();
	}
	
	/// Update is called once per frame
	void Update () {

        if (ScreenShort)
        {
            //if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            //{
            //    touchPosition3 = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //    touchPosition2 = new Vector2(touchPosition3.x, touchPosition3.y);
                if (Utility.isClicked_2D(saveCall.GetComponent<Collider2D>()) && !detected)//GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition2) && !detected)
                {
                    detected = true;
                    Buttons(false);
                    for (int i = 0; i < sp.Length; i++)
                    {
                        sp[i].enabled = false;
                    }
                    ssName = screenShotName + screenShotNumber + ".png";
                    Debug.Log("Camera Clicked " + ssName);

                    Application.CaptureScreenshot("/../../../../DCIM/HalloweenBookColoringPages/" + ssName);

                    //Application.CaptureScreenshot("MyLovelyPet.png");

                    //var pathToImage = Application.persistentDataPath + "/" + "MyLovelyPet.png";
                    //Debug.Log(Application.persistentDataPath + "/" + "MyLovelyPet.png");

                    //Application.CaptureScreenshot("/../../../../DCIM/Camera/" + "MyLovelyPet2.png" );
                    GalleryUpdate();

                    screenShotNumber++;
                    PlayerPrefs.SetInt("ScreenShot", screenShotNumber);
                    PlayerPrefs.Save();
                }
            //}
        }
	}
	
	void GalleryUpdate () {
		StartCoroutine (GalleryUpdateRoutine());
	}
	
	IEnumerator GalleryUpdateRoutine () {
		yield return new WaitForSeconds (2.0f);
        //if (AppController.isMusic)
        //{
        //    GetComponent<AudioSource>().Play();
        //}
		//Buttons(true);
		detected = false;
     //   Debug.Log(System.IO.Directory.GetFiles(Application.persistentDataPath + "/../../../../DCIM/PrincessShoeBotique/").Length);
        gallery.CallStatic("GalleryRefresh", playerActivityContext, Application.persistentDataPath + "/../../../../DCIM/HalloweenBookColoringPages/" + ssName);//PrincessShoeBotique
        Debug.Log("Scene End");
        if (ScreenShort)
        {
            Application.LoadLevel(2);
        }
       
	}

	void CreateFolder() {
        if (Directory.Exists(Application.persistentDataPath + "/../../../../DCIM/HalloweenBookColoringPages")) 
		{
		//	Debug.Log("That path exists already.");
			return;
		}
        Directory.CreateDirectory(Application.persistentDataPath + "/../../../../DCIM/HalloweenBookColoringPages");
	}

	void Buttons(bool show) {

        for (int i = 0; i < HideShow.Length; i++)
        {
            HideShow[i].SetActive(show);
        }
	}

    public void ScreenCaptureCal()
    {
        detected = true;
				Buttons(false);

				ssName = screenShotName + screenShotNumber + ".png";
				Debug.Log("Camera Clicked " + ssName);

                Application.CaptureScreenshot("/../../../../DCIM/HalloweenBookColoringPages/" + ssName);
				
				//Application.CaptureScreenshot("MyLovelyPet.png");
				
				//var pathToImage = Application.persistentDataPath + "/" + "MyLovelyPet.png";
				//Debug.Log(Application.persistentDataPath + "/" + "MyLovelyPet.png");
				
				//Application.CaptureScreenshot("/../../../../DCIM/Camera/" + "MyLovelyPet2.png" );
				GalleryUpdate();

				screenShotNumber++;
				PlayerPrefs.SetInt ("ScreenShot", screenShotNumber);
				PlayerPrefs.Save ();
    }
}

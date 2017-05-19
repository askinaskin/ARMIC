using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiWebcamManager : MonoBehaviour {

	public GameObject webcamTexturePrefab;

	private string[] nameOfCams;
	private List<WebCamTexture> webCamTextures = new List<WebCamTexture>();

	// Use this for initialization
	void Start () {
		
		int numOfCams = WebCamTexture.devices.Length;
		nameOfCams = new string[numOfCams];

		for (int i = 0; i < numOfCams; i++) {

            nameOfCams[i] = "microsoft LifeCam HD-6000";
                //WebCamTexture.devices [i].name;

			GameObject go = Instantiate(webcamTexturePrefab,new Vector3(i*6, 0, 0), Quaternion.identity) as GameObject;
			go.transform.parent = gameObject.transform;

			WebCamTexture webcamTexture = new WebCamTexture ();
			webcamTexture.deviceName = nameOfCams [i];
			webCamTextures.Add (webcamTexture);

			go.transform.GetChild (0).GetComponent<Renderer> ().material.mainTexture = webCamTextures [i];
			Debug.Log ("Camera " + i + ": " + nameOfCams [i]);
			webCamTextures [i].Play();

		}
	}
	

}

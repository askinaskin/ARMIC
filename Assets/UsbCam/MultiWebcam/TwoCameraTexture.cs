using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoCameraTexture : MonoBehaviour {

	public GameObject plane1;
	public GameObject plane2;

	private List<WebCamTexture> webCamTextures = new List<WebCamTexture>();

	// Use this for initialization
	void Start () {

		int numOfCams = WebCamTexture.devices.Length;
		if (numOfCams == 2) {
			
			WebCamTexture webcamTexture = new WebCamTexture ();
			webcamTexture.deviceName = WebCamTexture.devices [0].name;
			plane1.GetComponent<Renderer> ().material.mainTexture = webcamTexture;
			Debug.Log ("Camera 1: "  + webcamTexture.deviceName);
			webcamTexture.Play();

			WebCamTexture webcamTexture1 = new WebCamTexture ();
			webcamTexture1.deviceName = WebCamTexture.devices [1].name;
			plane2.GetComponent<Renderer> ().material.mainTexture = webcamTexture1;
			Debug.Log ("Camera 2: "  + webcamTexture1.deviceName);
			webcamTexture1.Play();
		}
        
	}

    void Update()
    {
        print("Plane 1 position: " + plane1.transform.position.x);

    }

}

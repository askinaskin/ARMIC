using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneCameraTexture : MonoBehaviour {

    public GameObject plane1;

    private List<WebCamTexture> webCamTextures = new List<WebCamTexture>();

    // Use this for initialization
    void Start()
    {

        int numOfCams = WebCamTexture.devices.Length;
        if (numOfCams > 0)
        {

            WebCamTexture webcamTexture = new WebCamTexture();
            webcamTexture.deviceName = WebCamTexture.devices[0].name;
            plane1.GetComponent<Renderer>().material.mainTexture = webcamTexture;
            Debug.Log("Camera 1: " + webcamTexture.deviceName);
            webcamTexture.Play();

        }

    }
}

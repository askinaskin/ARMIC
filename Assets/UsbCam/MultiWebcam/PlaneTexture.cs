using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTexture : MonoBehaviour {

    private WebCamTexture texture;

    public Camera targetCamera = null;
    public enum Eye { left, right };
    public Eye eye;

    public Vector2 offset;
    public Vector2 scale;

    public float fps = 60.0f;

    private const float FARNESS_RATE = 0.9f;

    void Awake()
    {
        texture = new WebCamTexture();

        switch(this.eye)
        {
            case Eye.left:
                this.texture.deviceName = WebCamTexture.devices[0].name;
                this.GetComponent<Renderer>().material.mainTexture = texture;
                texture.Play();
                Debug.Log("Camera Left: " + texture.deviceName);
                break;
            case Eye.right:
                this.texture.deviceName = WebCamTexture.devices[1].name;
                this.GetComponent<Renderer>().material.mainTexture = texture;
                texture.Play();
                Debug.Log("Camera Right: " + texture.deviceName);
                break;
            default:
                throw new System.Exception("unexpected parameter: eye=" + this.eye);
        }

    }
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0, 0, 10);
        transform.rotation = Quaternion.Euler(0, 90, -90);
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = targetCamera.transform.position + targetCamera.transform.forward * targetCamera.far * FARNESS_RATE;

    }
}

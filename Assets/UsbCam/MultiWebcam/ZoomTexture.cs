using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTexture : MonoBehaviour {

    float minFov = 15f;
    float maxFov  = 90f;

    float sensitivity = 10f;
	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        if (Camera.current != null)
        {
            float fov = Camera.current.fieldOfView;
            //float pos = transform.position.z;
            //ScrollWheel
            fov += Input.GetAxis("Mouse X") * sensitivity;
            Debug.Log("Mouse fov: " + fov);
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.current.fieldOfView = fov;
            Debug.Log("new fov: " + fov);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour {

    public Camera targetCamera = null;
    public GameObject prefab = null;
    public int cameraNumber = 0;
    public int layer = 0;
    public int hiddenLayer = 0;
    public Vector2 rotation;

    private GameObject billboard_ = null;

    //child plane name
    private const string CHILD_NAME = "CameraBackgroundImage";

    //adjustment parameter
    private const float EXPAND_WIDTH_RATE = 1.8f;
    private const float EXPAND_HEIGHT_RATE = 2.7f;
    private const float FARNESS_RATE = 0.9f;

    void Awake()
    {
        if (targetCamera == null)
        {
            Debug.LogError("No target camera!");
            return;
        }
        if (prefab == null)
        {
            Debug.LogError("No prefab!");
            return;
        }

        // set the PS Eye number before instantiation
        GameObject child = prefab.transform.FindChild(CHILD_NAME).gameObject;
        child.GetComponent<CameraTexture>().cameraNumber = cameraNumber;

        // create a billboard
        billboard_ = Instantiate(prefab) as GameObject;

        // set the billboard's size and child's rotation
        float width = targetCamera.far * EXPAND_WIDTH_RATE;
        float height = targetCamera.far * EXPAND_HEIGHT_RATE;
        billboard_.transform.localScale = new Vector3(width, height, 0.1f);
        child.transform.localRotation = Quaternion.Euler(rotation);

        // set the billboard's layer and the targetCamera's culling mask
        billboard_.layer = child.layer = layer;
        targetCamera.cullingMask &= ~(1 << hiddenLayer);

        // update the billboard's position and rotation
        UpdateObject();
    }

    void LateUpdate()
    {
        if (targetCamera != null && billboard_ != null)
        {
            UpdateObject();
        }
    }

    void UpdateObject()
    {
        billboard_.transform.position = targetCamera.transform.position + targetCamera.transform.forward * targetCamera.far * FARNESS_RATE;
        billboard_.transform.rotation = targetCamera.transform.rotation;
    }
}

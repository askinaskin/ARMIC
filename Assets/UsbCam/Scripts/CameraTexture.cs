using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraTexture : MonoBehaviour {

    private int width_ = 0;
    private int height_ = 0;

    private Texture2D texture_;
    private Color32[] pixels_, pixelsABGR_;
    private GCHandle pixels_handle_;


    private static int CameraCount { get { return CLEyeGetCameraCount(); } }
    public int cameraNumber = 0;
    void Awake()
    {

        texture_ = new Texture2D(width_, height_, TextureFormat.ARGB32, false);
        pixels_ = texture_.GetPixels32();
        pixels_handle_ = GCHandle.Alloc(pixels_, GCHandleType.Pinned);
        GetComponent<Renderer>().material.mainTexture = texture_;
        pixelsABGR_ = texture_.GetPixels32();
    }
  

    public static extern int CLEyeGetCameraCount();
}   

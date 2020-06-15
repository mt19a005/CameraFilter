using OpenCVForUnity.CoreModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.ImgprocModule;
using System.Collections;
using UnityEngine;
using static OpenCVForUnity.CoreModule.Core;
using static OpenCVForUnity.CoreModule.CvType;

public class Display : MonoBehaviour
{
    //撮影動画
    WebCamTexture webcamTexture;
    //ディスプレイ
    GameObject display;
    //WebCamTextureから、Texture2Dに変更したもの
    Texture2D webcamTextureTex2D;

    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display");

        //カメラ映像をディスプレイに病gは
        webcamTexture = new WebCamTexture();
        display.GetComponent<Renderer>().material.mainTexture = webcamTexture;
        //webcamTexture.Play();
        if (webcamTexture.isPlaying == false) webcamTexture.Play();
        DontDestroyOnLoad(gameObject);
    }
    //撮影ボタンが押されたら呼び出し
    //撮影した画像をModel.TookPictureに保存
    public void Take()
    {
        Texture2D webcamTextureTex2D = new Texture2D(webcamTexture.width, webcamTexture.height);
        webcamTextureTex2D = webcamTextureToTex2D(webcamTextureTex2D);
        Model.TookPicture = webcamTextureTex2D;
    }
    //webcamTextureから、TextureTex2Dに変更
    Texture2D webcamTextureToTex2D(Texture2D webcamTextureTex2D)
    {
        Color32[] color32 = webcamTexture.GetPixels32();
        webcamTextureTex2D.SetPixels32(color32);
        webcamTextureTex2D.Apply();
        return webcamTextureTex2D;
    }
}
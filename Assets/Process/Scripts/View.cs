using OpenCVForUnity.CoreModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.ImgprocModule;
using System.Collections;
using UnityEngine;
using static OpenCVForUnity.CoreModule.Core;
using static OpenCVForUnity.CoreModule.CvType;
using System.Collections.Generic;
using Rect = OpenCVForUnity.CoreModule.Rect;

public class View : MonoBehaviour
{
    GameObject display;
    ProcessType nowType;


    void Start()
    {
        nowType = ProcessType.Nothing;
        display = GameObject.FindGameObjectWithTag("Display");
    }
    void Update()
    {
        //加工タイプが変わったら
        if (nowType != Model.getType())
        {
            //              加工処理ここから                //
            //普通に変更
            if (Model.getType() == ProcessType.Nomal)
            {
                display.GetComponent<Renderer>().material.mainTexture = Model.TookPicture;
            }
            else
            {
                //前処理
                Texture2D TookPictureTMP = Model.TookPicture;
                Mat TookPictureMat;
                TookPictureMat = webcamTex2DToMat(Model.TookPicture);
                Texture2D dst = new Texture2D(TookPictureTMP.width, TookPictureTMP.height);

                //グレイスケールに変更
                if (Model.getType() == ProcessType.Gray) Process.Gray(TookPictureMat);
                //2値化に変更
                else if (Model.getType() == ProcessType.Thresh) Process.Threshold(TookPictureMat, 50, 255);
                //エッジ検出
                else if (Model.getType() == ProcessType.Edge) Process.Edge(TookPictureMat, 20, 120);
                //ガウシアンフィルター
                else if (Model.getType() == ProcessType.Gaussian) Process.Gaussian(TookPictureMat);

                //後処理
                Utils.matToTexture2D(TookPictureMat, dst);
                display.GetComponent<Renderer>().material.mainTexture = dst;
            }
            //              加工処理ここまで               //

            nowType = Model.getType();
        }
    }

    Mat webcamTex2DToMat(Texture2D webcamTextureTex2D)
    {
        Mat webcamTextureMat = new Mat(webcamTextureTex2D.height, webcamTextureTex2D.width, CV_8UC4);

        Utils.texture2DToMat(webcamTextureTex2D, webcamTextureMat);
        return webcamTextureMat;
    }
}

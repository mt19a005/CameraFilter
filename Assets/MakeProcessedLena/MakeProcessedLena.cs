using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.ImgprocModule;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.ImgcodecsModule;
using System.IO;

public class MakeProcessedLena : MonoBehaviour
{
    string path = @"C:\Unity_Project\CameraFilter\Assets\Lena\ProcessedLena\ProcessedLena.jpg";
    // Start is called before the first frame update
    void Start()
    {
        Mat src = Imgcodecs.imread(Application.dataPath + "/Resources/Splites/Lena.jpg");

        //処理
        Process.Gaussian(src);

        Texture2D texture = new Texture2D(src.cols(), src.rows());

        Utils.matToTexture2D(src, texture);

        var png = texture.EncodeToPNG();
        File.WriteAllBytes(path, png);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

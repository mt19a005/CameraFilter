using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgcodecsModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lena : MonoBehaviour
{
    GameObject lenaObj;
    // Start is called before the first frame update
    void Start()
    {
        Mat src = Imgcodecs.imread(@"C:\Unity_Project\CameraFilter\Assets\Resources\Prefab\Image.lena.jpg");
        Process.Gray(src);
        Imgcodecs.imwrite("C:/Users/motom/Downloads/Processedlena.jpg", src);
    }
}

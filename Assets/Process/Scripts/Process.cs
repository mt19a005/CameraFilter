using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.ImgprocModule;
using Rect = OpenCVForUnity.CoreModule.Rect;

static class Process
{
    internal static Mat Gray(Mat src)
    {
        Imgproc.cvtColor(src, src, Imgproc.COLOR_RGBA2GRAY);
        return src;
    }
    internal static Mat Threshold(Mat src, int thresh, int max)
    {
        Gray(src);
        Imgproc.threshold(src, src, thresh, max, Imgproc.THRESH_BINARY);
        return src;
    }
    internal static Mat Edge(Mat src, int thresh1, int thresh2)
    {
        Gray(src);
        Imgproc.GaussianBlur(src, src, new Size(3, 3), 0);
        Imgproc.Canny(src, src, thresh1, thresh2);
        Imgproc.cvtColor(src, src, Imgproc.COLOR_GRAY2RGBA);
        return src;
    }
    internal static Mat Gaussian(Mat src)
    {
        //Rect rect = new Rect(src.rows() / 3, src.cols() / 3, src.rows() / 3, src.cols() / 3);
        //Mat Roi = new Mat(src, rect);
        //Imgproc.GaussianBlur(Roi, Roi, new Size(0, 0), 30, 30);
        Imgproc.GaussianBlur(src, src, new Size(0, 0), 30, 30);
        //src.copyTo(Roi);

        Imgproc.cvtColor(src, src, Imgproc.COLOR_GRAY2RGBA);
        return src;
    }
}

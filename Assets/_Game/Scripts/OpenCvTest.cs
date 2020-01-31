using UnityEngine;
using System.Collections;
using OpenCvSharp;
using OpenCvSharp.Demo;

public class OpenCvTest : WebCamera
{
    private Mat previousFrame = new Mat();

    protected override void Awake()
    {
        base.Awake();
        base.forceFrontalCamera = true;
    }

    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        Mat image = OpenCvSharp.Unity.TextureToMat(input, TextureParameters);
        Mat imageGray = new Mat();
        Mat imageBlurred = new Mat();
        Mat imageBlurred32F = new Mat();
        Mat display = new Mat();

        Cv2.CvtColor(image, imageGray, ColorConversionCodes.BGR2GRAY);

        Cv2.Blur(imageGray, imageBlurred, new Size(5, 5));

        imageBlurred.ConvertTo(imageBlurred32F, MatType.CV_32F);

        if (!previousFrame.Empty())
        {
            Mat diff = imageBlurred32F - previousFrame;

            Cv2.ConvertScaleAbs(diff, display);
            Cv2.Threshold(display, display, 10, 255, ThresholdTypes.Binary);

            output = OpenCvSharp.Unity.MatToTexture(display, output);
        }
        else
        {
            output = OpenCvSharp.Unity.MatToTexture(imageBlurred, output);
        }

        imageBlurred32F.CopyTo(previousFrame);

        return true;
    }
}

namespace OpenCvSharp.Demo
{
	using UnityEngine;
	using System.Collections;
	using OpenCvSharp;
	using UnityEngine.UI;

	public class GrayscaleScript : MonoBehaviour {

		public Texture2D texture;

		// Use this for initialization
		void Start () {

			Mat mat = Unity.TextureToMat (this.texture);
			Mat grayMat = new Mat ();
			Cv2.CvtColor (mat, grayMat, ColorConversionCodes.BGR2GRAY);

			CLAHE clahe = CLAHE.Create();
			clahe.Apply(grayMat, grayMat);

			Mat grayMat32F = new Mat();

			grayMat.ConvertTo(grayMat32F, MatType.CV_32F);
			grayMat32F *= 0.5f;
			grayMat32F.ConvertTo(grayMat, MatType.CV_8U);

			Texture2D texture = Unity.MatToTexture (grayMat);

			RawImage rawImage = gameObject.GetComponent<RawImage> ();
			rawImage.texture = texture;
	//		Renderer renderer = gameObject.GetComponent<Renderer> ();
	//		renderer.material.mainTexture = texture;
		}

		// Update is called once per frame
		void Update () {

		}


	}
}
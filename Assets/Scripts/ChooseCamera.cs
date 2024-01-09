using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCamera : MonoBehaviour
{
	private bool camAvailable;
	private WebCamTexture cameraTexture;
	private Texture defaultBackground;

	public RawImage background;
	public AspectRatioFitter fit;
	public bool frontFacing;
	private WebCamTexture webCameraTexture;

	// Use this for initialization
	void Start()
	{
		WebCamDevice[] devices = WebCamTexture.devices;

		foreach (WebCamDevice cam in devices)
		{
			if (cam.isFrontFacing)
			{
				Debug.Log(cam.name);
				if (cam.name == "OBS Virtual Camera")
				{ return; }

				webCameraTexture = new WebCamTexture(cam.name, Screen.width, Screen.height); 
				webCameraTexture.deviceName = cam.name;
				background.texture = webCameraTexture;
				webCameraTexture.Play();
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!camAvailable)
			return;

		float ratio = (float)cameraTexture.width / (float)cameraTexture.height;
		fit.aspectRatio = ratio; // Set the aspect ratio

		float scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera

		int orient = -cameraTexture.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}

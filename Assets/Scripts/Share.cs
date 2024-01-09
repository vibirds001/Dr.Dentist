using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using VoxelBusters;
//using VoxelBusters.NativePlugins;

public class Share : MonoBehaviour {
 
    private bool isSharing = false;

    public GameObject ReturnPanel;
 
    public void RateMyApp()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.zentanamusicltd.zenlandar");
            //NPBinding.Utility.OpenStoreLink ("com.zentanamusicltd.zenlandar");
        }
    }
 
    public void ShareSocialMedia ()
    {
        isSharing = true;
    }
 
    void LateUpdate ()
    {
        if (isSharing == true)
        {
            isSharing = false;
 
            StartCoroutine (CaptureScreenShoot());
        }
    }
 
    IEnumerator CaptureScreenShoot ()
    {
        yield return new WaitForEndOfFrame ();

        //Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture ();

        //ShareSheet (texture);

        //Object.Destroy(texture, 2);
        StartCoroutine(TakeScreenshotAndShare());

        Invoke("ShowReturnPanel", 2);
            
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = System.IO.Path.Combine(Application.temporaryCachePath, "shared img.png");
        System.IO.File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Zenland AR").SetText("My lucky zenpet 2D Rescue!").SetUrl("https://zenlandar.com/")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }

    private void ShareSheet (Texture2D texture)
    {
        //ShareSheet _shareSheet = new ShareSheet ();
 
        //_shareSheet.Text = "My lucky zenpet 2D Rescue!";
        //_shareSheet.AttachImage (texture);
        //_shareSheet.URL = "https://zenlandar.com/";
 
        //NPBinding.Sharing.ShowView (_shareSheet, FinishSharing);
    }

    public void ShowReturnPanel()
    {
        ReturnPanel.SetActive(true);
    }
 
    //private void FinishSharing (eShareResult _result)
    //{
    //    Debug.Log (_result);
    //}
}
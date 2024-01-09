// using System;
// using UnityEngine;
// using GoogleMobileAds;
// using GoogleMobileAds.Api;

// public class GoogleMobileAdsDemoHandler : IDefaultInAppPurchaseProcessor
// {


//     private readonly string[] validSkus = { "android.test.purchased" };

//     // Will only be sent on a success.
//     public void ProcessCompletedInAppPurchase(IInAppPurchaseResult result)
//     {
//         result.FinishPurchase();
// 		Admob.OutputMessage = "Purchase Succeeded! Credit user here.";
//     }

//     // Check SKU against valid SKUs.
//     public bool IsValidPurchase(string sku)
//     {
//         foreach (string validSku in this.validSkus)
//         {
//             if (sku == validSku)
//             {
//                 return true;
//             }
//         }

//         return false;
//     }

//     // Return the app's public key.
//     public string AndroidPublicKey
//     {
//         // In a real app, return public key instead of null.
//         get { return null; }
//     }
// }

// // Example script showing how to invoke the Google Mobile Ads Unity plugin.
// public class Admob : MonoBehaviour
// {
// 	public BannerView bannerView;
// 	public InterstitialAd interstitial;
// 	public NativeExpressAdView nativeExpressAdView;
//     private RewardBasedVideoAd rewardBasedVideo;
//     private float deltaTime = 0.0f;
//     private static string outputMessage = string.Empty;

//     public static string OutputMessage
//     {
//         set { outputMessage = value; }
//     }

//     public void Start()
//     {
		
// 		DontDestroyOnLoad (this);
// 		RequestBanner ();
// 		RequestInterstitial ();
// 		bannerView.Show ();

//         // Get singleton reward based video ad reference.
//         this.rewardBasedVideo = RewardBasedVideoAd.Instance;

//         // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
//         this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
//         this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
//         this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
//         this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
//         this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
//         this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
//         this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
//     }

//     public void Update()
//     {
//         // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
//         // value.
//         this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.01f;
//     }



    

//     // Returns an ad request with custom ad targeting.
// 	public AdRequest CreateAdRequest()
//     {
//         return new AdRequest.Builder()
//             .AddTestDevice(AdRequest.TestDeviceSimulator)
//             .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
//             .AddKeyword("game")
//             .SetGender(Gender.Male)
//             .SetBirthday(new DateTime(1985, 1, 1))
//             .TagForChildDirectedTreatment(false)
//             .AddExtra("color_bg", "9B30FF")
//             .Build();
//     }

// 	public void RequestBanner()
//     {
//         // These ad units are configured to always serve test ads.
//         #if UNITY_EDITOR
//         string adUnitId = "unused";
//         #elif UNITY_ANDROID
//         string adUnitId = "ca-app-pub-3940256099942544/6300978111";
//         #elif UNITY_IPHONE
//         string adUnitId = "ca-app-pub-3940256099942544/2934735716";
//         #else
//         string adUnitId = "unexpected_platform";
//         #endif

//         // Create a 320x50 banner at the top of the screen.
// 		this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

//         // Register for ad events.
//         this.bannerView.OnAdLoaded += this.HandleAdLoaded;
//         this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
//         this.bannerView.OnAdLoaded += this.HandleAdOpened;
//         this.bannerView.OnAdClosed += this.HandleAdClosed;
//         this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

//         // Load a banner ad.
//         this.bannerView.LoadAd(this.CreateAdRequest());
//     }

// 		public void RequestInterstitial()
//     {
//         // These ad units are configured to always serve test ads.
//         #if UNITY_EDITOR
//         string adUnitId = "unused";
//         #elif UNITY_ANDROID
//         string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//         #elif UNITY_IPHONE
//         string adUnitId = "ca-app-pub-3940256099942544/4411468910";
//         #else
//         string adUnitId = "unexpected_platform";
//         #endif

//         // Create an interstitial.
//         this.interstitial = new InterstitialAd(adUnitId);

//         // Register for ad events.
//         this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
//         this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
//         this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
//         this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
//         this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

//         // Load an interstitial ad.
//         this.interstitial.LoadAd(this.CreateAdRequest());
//     }

// 		public void RequestNativeExpressAdView()
//     {
//         // These ad units are configured to always serve test ads.
//         #if UNITY_EDITOR
//         string adUnitId = "unused";
//         #elif UNITY_ANDROID
//         string adUnitId = "ca-app-pub-3940256099942544/1072772517";
//         #elif UNITY_IPHONE
//         string adUnitId = "ca-app-pub-3940256099942544/2562852117";
//         #else
//         string adUnitId = "unexpected_platform";
//         #endif

//         // Create a 320x150 native express ad at the top of the screen.
//         this.nativeExpressAdView = new NativeExpressAdView(
//             adUnitId,
//             new AdSize(320, 150),
//             AdPosition.Top);

//         // Register for ad events.
//         this.nativeExpressAdView.OnAdLoaded += this.HandleNativeExpressAdLoaded;
//         this.nativeExpressAdView.OnAdFailedToLoad += this.HandleNativeExpresseAdFailedToLoad;
//         this.nativeExpressAdView.OnAdLoaded += this.HandleNativeExpressAdOpened;
//         this.nativeExpressAdView.OnAdClosed += this.HandleNativeExpressAdClosed;
//         this.nativeExpressAdView.OnAdLeavingApplication += this.HandleNativeExpressAdLeftApplication;

//         // Load a native express ad.
//         this.nativeExpressAdView.LoadAd(this.CreateAdRequest());
//     }

// 		public void RequestRewardBasedVideo()
//     {
//         #if UNITY_EDITOR
//         string adUnitId = "unused";
//         #elif UNITY_ANDROID
//         string adUnitId = "INSERT_AD_UNIT_HERE";
//         #elif UNITY_IPHONE
//         string adUnitId = "INSERT_AD_UNIT_HERE";
//         #else
//         string adUnitId = "unexpected_platform";
//         #endif

//         this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
//     }

// 		public void ShowInterstitial()
// 		{
// 		if (interstitial.IsLoaded())
// 		{
// 		interstitial.Show();
// 		} else    {
// 			RequestInterstitial ();
// 		}   
// 		}


//     private void ShowRewardBasedVideo()
//     {
//         if (this.rewardBasedVideo.IsLoaded())
//         {
//             this.rewardBasedVideo.Show();
//         }
//         else
//         {
//             MonoBehaviour.print("Reward based video ad is not ready yet");
//         }
//     }

//     #region Banner callback handlers

// 		public void HandleAdLoaded(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdLoaded event received");
//     }

//     public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//     {
//         MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
//     }

//     public void HandleAdOpened(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdOpened event received");
//     }

//     public void HandleAdClosed(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdClosed event received");
//     }

//     public void HandleAdLeftApplication(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdLeftApplication event received");
//     }

//     #endregion

//     #region Interstitial callback handlers

//     public void HandleInterstitialLoaded(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleInterstitialLoaded event received");
//     }

//     public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//     {
//         MonoBehaviour.print(
//             "HandleInterstitialFailedToLoad event received with message: " + args.Message);
//     }

//     public void HandleInterstitialOpened(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleInterstitialOpened event received");
//     }

//     public void HandleInterstitialClosed(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleInterstitialClosed event received");
//     }

//     public void HandleInterstitialLeftApplication(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleInterstitialLeftApplication event received");
//     }

//     #endregion

//     #region Native express ad callback handlers

//     public void HandleNativeExpressAdLoaded(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleNativeExpressAdAdLoaded event received");
//     }

//     public void HandleNativeExpresseAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//     {
//         MonoBehaviour.print(
//             "HandleNativeExpressAdFailedToReceiveAd event received with message: " + args.Message);
//     }

//     public void HandleNativeExpressAdOpened(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleNativeExpressAdAdOpened event received");
//     }

//     public void HandleNativeExpressAdClosed(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleNativeExpressAdAdClosed event received");
//     }

//     public void HandleNativeExpressAdLeftApplication(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleNativeExpressAdAdLeftApplication event received");
//     }

//     #endregion

//     #region RewardBasedVideo callback handlers

//     public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
//     }

//     public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//     {
//         MonoBehaviour.print(
//             "HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
//     }

//     public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
//     }

//     public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
//     }

//     public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
//     }

//     public void HandleRewardBasedVideoRewarded(object sender, Reward args)
//     {
//         string type = args.Type;
//         double amount = args.Amount;
//         MonoBehaviour.print(
//             "HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
//     }

//     public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
//     }

//     #endregion

// 		}

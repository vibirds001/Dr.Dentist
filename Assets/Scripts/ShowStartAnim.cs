using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowStartAnim : MonoBehaviour
{
	private int IntroTextPlayed;

    public GameObject CanvasIntro;
    public GameObject CanvasReplay;
    public AudioSource AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        IntroTextPlayed = PlayerPrefs.GetInt("IntroText", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroTextPlayed == 1)
        {
        	CanvasIntro.SetActive(true);
        }
        else if (IntroTextPlayed == 2)
        {
        	CanvasIntro.SetActive(false);
        	CanvasReplay.SetActive(true);
            AudioSource.Stop();
        }
    }

    public void IntroPlayed()
    {
    	StartCoroutine(SetIntroToPlayed());
    }

    IEnumerator SetIntroToPlayed()
    {
    	yield return new WaitForEndOfFrame();
    	IntroTextPlayed = 2;
    	PlayerPrefs.SetInt("IntroText", IntroTextPlayed);
    }

    public void ReplayIntro()
    {
    	IntroTextPlayed = 1;
    	PlayerPrefs.SetInt("IntroText", IntroTextPlayed);
    }

}

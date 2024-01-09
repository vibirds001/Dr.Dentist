using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public static Setting instance;
    public GameObject sfxOn;
    public GameObject sfxOff;

    public GameObject musicOn;
    public GameObject musicOff;




    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        sfxOn.GetComponent<Button>().onClick.RemoveAllListeners();
        sfxOn.GetComponent<Button>().onClick.AddListener(() => OnClick_SFX_Button_OFF());
        
        sfxOff.GetComponent<Button>().onClick.RemoveAllListeners();
        sfxOff.GetComponent<Button>().onClick.AddListener(()=>OnClick_SFX_Button_ON());

        musicOn.GetComponent<Button>().onClick.RemoveAllListeners();
        musicOn.GetComponent<Button>().onClick.AddListener(() => OnClick_Music_Button_OFF());

        musicOff.GetComponent<Button>().onClick.RemoveAllListeners();
        musicOff.GetComponent<Button>().onClick.AddListener(() => OnClick_Music_Button_ON());



        Set_BUTTONS_Statuses();
        Set_BUTTONS_StatusesMusic();
        //if(SceneManager.GetActiveScene().ToString() == "PlayMatch3")
        //{
        //    GameObject.Find("TitleImagePause").SetActive(true);
        //    GameObject.Find("TitleImageSetting").SetActive(false);

        //    if (PlayerPrefs.GetString("GameMode") == "TimeAttack")
        //    {
        //        GameObject.Find("Score").SetActive(true); 
        //        GameObject.Find("Timer").SetActive(true); 

        //    }
        //    else if(PlayerPrefs.GetString("GameMode") == "Survival")
        //    {
        //        GameObject.Find("Score").SetActive(false);
        //        GameObject.Find("Timer").SetActive(false);

        //    }
        //}
        //else if (SceneManager.GetActiveScene().ToString() == "MainMenu")
        //{
        //    GameObject.Find("TitleImagePause").SetActive(true);
        //    GameObject.Find("TitleImageSetting").SetActive(false);
        //    GameObject.Find("Score").SetActive(false);
        //    GameObject.Find("Timer").SetActive(false);

        //}



    }

  

    public void Set_BUTTONS_Statuses()
    {

        //SFX
        if (SoundManager.instance.isSfxOn())
        {
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else
        {
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);
        }
    }

    public void Set_BUTTONS_StatusesMusic()
    {
        // MUSIC
        if (isMusicOn())
        {
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
        else
        {
            musicOff.SetActive(false);
            musicOn.SetActive(true);
        }
    }

    public bool isMusicOn()
    {
        if (PlayerPrefs.GetInt("MUSIC", 1) == 0)
        {
            // MUSIC OFF
            return false;
        }
        else
        {
            // MUSIC ON
            return true;
        }
    }



    public void OnClick_Music_Button_ON()
    {
        MusicManager.instance.OnClick_Music_Button_ON();
    }


    public void OnClick_Music_Button_OFF()
    {
        MusicManager.instance.OnClick_Music_Button_OFF();
    }


    public void OnClick_SFX_Button_ON()
    {
        SoundManager.instance.OnClick_SFX_Button_ON();
    }


    public void OnClick_SFX_Button_OFF()
    {
        SoundManager.instance.OnClick_SFX_Button_OFF();

    }







}

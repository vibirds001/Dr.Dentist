using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

   

    [Header("----- AUDIO SOURCES -----")]
    [Space(12)]
    public AudioSource asrc;

    [Header("----- AUDIO CLIPS -----")]
    [Space(12)]
    [SerializeField] private AudioClip buttonClick_Clip;

    [SerializeField] private AudioClip levelComplete_Clip;
    [SerializeField] private AudioClip levelFailed_Clip;
    [SerializeField] private AudioClip MatchSound_Clip;
    private static bool created = false;


    void Awake()
    {


        //if (instance == null)
        //    instance = this;

        //if (!created)
        //{
        //    DontDestroyOnLoad(this.gameObject);
        //    created = true;
        //}

    }


    void Start()
    {
        //if (created == true)
        //{
        //    sfxOff = GameObject.Find("SFX ON");
        //    sfxOn = GameObject.Find("SFX OFF");
        //    musicOff = GameObject.Find("MUSIC ON");
        //    musicOn = GameObject.Find("MUSIC OFF");
        //}]


        DontDestroyOnLoad(gameObject);


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



        //if (instance == null)
        //    instance = this;

        //if (!created)
        //{
        //    DontDestroyOnLoad(this.gameObject);
        //    created = true;
        //}


        Set_SOUNDS_STATUS();
     // Setting.instance.Set_BUTTONS_Statuses();
    }


    void Set_SOUNDS_STATUS()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            // SFX OFF
            asrc.volume = 0f;
        }
        else
        {
            // SFX ON
            asrc.volume = 1f;

        }

    }

    public void Set_SFX_STATUS(bool status)
    {
        if (status == true)
        {
            PlayerPrefs.SetInt("SFX", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 0);
        }
        Set_SOUNDS_STATUS();
    }




    public void Play_BUTTON_CLICK_Sound()
    {

        asrc.PlayOneShot(buttonClick_Clip);

    }
    public void Play_MATCH_TILE_Sound()
    {
        asrc.PlayOneShot(MatchSound_Clip);

    }

    public void Play_LEVEL_COMPLETE_Sound()
    {
        asrc.PlayOneShot(levelComplete_Clip);

    }
    public void Play_LEVEL_FAILED_Sound()
    {
        asrc.PlayOneShot(levelFailed_Clip);

    }









    public bool isSfxOn()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            // SFX OFF
            return false;
        }
        else
        {
            // SFX ON
            return true;
        }
    }


    /// <summary>
    /// /////////////////           SETTINGS SCREEN
    /// </summary>
    ///






   



    public void OnClick_SFX_Button_ON()
    {
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        SoundManager.instance.Set_SFX_STATUS(false);
        Setting.instance.Set_BUTTONS_Statuses();
    }


    public void OnClick_SFX_Button_OFF()
    {
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        SoundManager.instance.Set_SFX_STATUS(true);
        Setting.instance.Set_BUTTONS_Statuses();
    }


    public void OnClick_SETTINGS()
    {
        Time.timeScale = 0f;
    }



    public void OnClick_SETTINGS_BACK()
    {
        Time.timeScale = 1f;

    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music_audioSource;
   

    public static MusicManager instance;
    private static bool created = false;

    private void Awake()
    {
        //// instance = this;
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
        DontDestroyOnLoad(gameObject);


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Set_SOUNDS_STATUS();
      //  Setting.instance.
    }

    void Set_SOUNDS_STATUS()
    {
     
        if (PlayerPrefs.GetInt("MUSIC", 1) == 0)
        {
            // MUSIC OFF
            music_audioSource.volume = 0f;
        }
        else
        {
            // MUSIC ON
            music_audioSource.volume = 0.5f;

        }

    }

    public void Set_MUSIC_STATUS(bool status)
    {
        if (status == true)
        {
            PlayerPrefs.SetInt("MUSIC", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MUSIC", 0);
        }
        Set_SOUNDS_STATUS();
    }

    



   
   
    public void OnClick_Music_Button_ON()
    {
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        Set_MUSIC_STATUS(false);
        Setting.instance.Set_BUTTONS_StatusesMusic();
    }


    public void OnClick_Music_Button_OFF()
    {
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        Set_MUSIC_STATUS(true);
        Setting.instance.Set_BUTTONS_StatusesMusic();
    }





}

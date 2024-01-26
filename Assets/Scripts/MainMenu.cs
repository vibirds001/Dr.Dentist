using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject ContinueButton;
    public GameObject shopPanel;
    public static MainMenu main;
    private ShopItem si;
    
    
    private void Awake()
    {
        main = this;
        if (!PlayerPrefs.HasKey("firsttime"))
        {
            PlayerPrefs.SetString("Gem1", "1stTier/ToothBrush/1");
            PlayerPrefs.SetString("Gem2", "1stTier/Toothpaste/2");
            PlayerPrefs.SetString("Gem3", "1stTier/Floss/3");
            PlayerPrefs.SetString("Gem4", "1stTier/MouthWash/4");
            PlayerPrefs.SetString("Gem5", "1stTier/TongueScraper/5");

            PlayerPrefs.SetString("Selectedgem1", "1stTier/ToothBrush/1");
            PlayerPrefs.SetString("Selectedgem2", "1stTier/Toothpaste/2");
            PlayerPrefs.SetString("Selectedgem3", "1stTier/Floss/3");
            PlayerPrefs.SetString("Selectedgem4", "1stTier/MouthWash/4");
            PlayerPrefs.SetString("Selectedgem5", "1stTier/TongueScraper/5");

            PlayerPrefs.SetInt("firsttime", 1);
        }
    }

    void Start()
    {
       // mainMenuPanel.mmp.missingtoolPanel.SetActive(false);


        si = GetComponent<ShopItem>();
        main = GetComponent<MainMenu>();

        print("Level No. : " + PlayerPrefs.GetInt("Level"));


        if (PlayerPrefs.GetInt("Save", 0) > 0 && SaveGame.ReadString(Application.persistentDataPath + "/test.txt") != null)
        {
            ContinueButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            ContinueButton.GetComponent<Button>().interactable = false;

        }
        //if (PlayerPrefs.GetInt("Level", 0) < 1)
        //{
        //    PlayerPrefs.SetInt("Level", 0);
        //    OpenTutorialMode();

        //}

    }
    public void Update()
    {
       
    }
    public void OpenTimeAttackMode()
    {
        bool selected = true;
        for (int i = 1; i < 6; i++)
        {
            if (!PlayerPrefs.HasKey("Selectedgem" + i))
            {
                mainMenuPanel.mmp.missingtoolPanel.SetActive(true);
                selected = false;
            }
        }
        if (selected)
        {
            PlayerPrefs.SetString("Game", "");
            PlayerPrefs.SetString("GameMode", "TimeAttack");
            SceneManager.LoadScene("PlayMatch3");
            SoundManager.instance.Play_BUTTON_CLICK_Sound();
        }
 
    }
    public void ClassicMode()
    {
        Main.instance.goalText.text = "Classic Mode";

        bool selected = true;
        for (int i = 1; i < 6; i++)
        {
            if (!PlayerPrefs.HasKey("Selectedgem" + i))
            {
                mainMenuPanel.mmp.missingtoolPanel.SetActive(true);
                selected = false;
            }
        }
        if (selected) 
        {
            PlayerPrefs.SetString("Game", "");
            PlayerPrefs.SetString("GameMode", "Classic");
            SceneManager.LoadScene("PlayMatch3");
            SoundManager.instance.Play_BUTTON_CLICK_Sound();
        }
        
    }
    public void OpenTutorialMode()
    {
        PlayerPrefs.SetString("Game", "");
        PlayerPrefs.SetString("GameMode", "Tutorial");
        SceneManager.LoadScene("PlayMatch3");
        //   SoundManager.instance.Play_BUTTON_CLICK_Sound();
    }

    public void OpenLoadMode()
    {
        print("Load");
        if (PlayerPrefs.GetInt("Save") == 1)
        {
            PlayerPrefs.SetString("GameMode", "TimeAttack");
        }
        else if (PlayerPrefs.GetInt("Save") == 2)
        {
            PlayerPrefs.SetString("GameMode", "Survival");

        }
        PlayerPrefs.SetString("Game", "Load");
        SceneManager.LoadScene("PlayMatch3");
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
    }
    public void clickSound()
    {
        SoundManager.instance.Play_BUTTON_CLICK_Sound();

    }
    public void Shop()
    {
        shopPanel.SetActive(true);

    }
    
}

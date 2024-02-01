using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuPanel : MonoBehaviour
{
    public TextMeshProUGUI AuraText;
    public GameObject obtainedItemPanel;
    public static mainMenuPanel mmp;
    public GameObject ShopPanel;

    public GameObject missingtoolPanel;

    public Image[] bagOfDebrisImg;
    public Image[] LargeDepositImg;
    public Image shinyRockImg;
    public Image[] shinyDepositImg;
    public Image largeGemStoneImg;
    public Sprite[] gemSprite;
    public GameObject bagOfDebrisGameObject;
    public GameObject largeDepositGameObject;
    public GameObject shinyDepositGameObject;
    public GameObject shinyRockGameObject;
    public GameObject legandaryGemStoneGameObject;

    public GameObject showStatPanel;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI stats;
    public Image img;

    public int totalCoins;
    private void Awake()
    {
        if (mmp == null)
        mmp = this;
    }

    void Start()
    {
        AuraText.text = totalCoins.ToString();
        obtainedItemPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        aura();
    }

    public void aura()
    {
        if (AuraText != null)
        {
            totalCoins = PlayerPrefs.GetInt("totalaura");
            
            // Update the UI text to display the current total aura count
            AuraText.text = totalCoins.ToString();
        }
        else
        {
            Debug.LogError("AuraText is null in MainMenu.aura()");
        }



    }
    public void cross()
    {
        showStatPanel.SetActive(false);
        obtainedItemPanel.SetActive(false);
        mmp.ShopPanel.SetActive(true);
    }
    public void crossShowPanel()
    {
        showStatPanel.SetActive(false);
      
        MainMenu.main.shopPanel.SetActive(true);
    }
    
}

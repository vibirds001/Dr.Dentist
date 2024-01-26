using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public bool isSelected = false;
    public Image tickSign; // Reference to the tick sign UI element 
    public GameObject ShopPanel;
    public GameObject ChestPanel;
    public GameObject MainMenuPanel;
    private Main mm;

    private void Start()
    {
        mm = GetComponent<Main>();  
    }
    public void MainMenu()
    {
       ShopPanel.SetActive(false);
       MainMenuPanel.SetActive(true);
    }
    public void chest()
    {
        ChestPanel.SetActive(true); 
        //ShopPanel.SetActive(false);
    }
    public void cross()
    {
        ChestPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }
    public void Close()
    {
        mainMenuPanel.mmp.missingtoolPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}


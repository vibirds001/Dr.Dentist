using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemManager : MonoBehaviour
{
    public static GemManager gm;
    public int gemNumber;
    public string gemType;
    public string GemNumber;
    public string gemName;
    public string gemStats;
    public Image gemIcon;
    public int i;
    //public GameObject selectedItemDetailPanel;

    
    public Sprite[] gemsImages;

    
    private void Awake()
    {
        gm = this;
        PlayerPrefs.SetString("Gem1", "default/Ruby/1");
        PlayerPrefs.SetString("Gem2", "default/Amethyst/2");
        PlayerPrefs.SetString("Gem3", "default/Emerald/3");
        PlayerPrefs.SetString("Gem4", "default/Saphire/4");
        PlayerPrefs.SetString("Gem5", "default/Topaz/5");
        if (!PlayerPrefs.HasKey("totalgems"))
        {
            PlayerPrefs.SetInt("totalgems", 5);
        }
    }

    void Start()
    {
      
        
        //selectedItemDetailPanel.SetActive(false);
        getGems();
        for (int i = 1; i <= 5; i++)
        {
            Container.c.CheckSelectedGems(i);
        }

    }
    public void getGems()
    {
        string Gem = PlayerPrefs.GetString("Gem"+gemNumber);
        string[] G = Gem.Split('/');
        gemType = G[0];
        gemName = G[1]; 

        if (gemName.Equals("Ruby"))
        {
            gemIcon.sprite = gemsImages[0]; 
        }
        if (gemName.Equals("Amethyst"))
        {
            gemIcon.sprite = gemsImages[1]; 
        }
        if (gemName.Equals("Emerald"))
        {
            gemIcon.sprite = gemsImages[2]; 
        }
        if (gemName.Equals("Saphire"))
        {
            gemIcon.sprite = gemsImages[3]; 
        }
        if (gemName.Equals("Topaz"))
        {
            gemIcon.sprite = gemsImages[4]; 
        }
        if (gemName.Equals("RubySS"))
        {
            gemIcon.sprite = gemsImages[5];
        }
        if (gemName.Equals("AmethystSS"))
        {
            gemIcon.sprite = gemsImages[6];
        }
        if (gemName.Equals("EmeraldS"))
        {
            gemIcon.sprite = gemsImages[7];
        }
        if (gemName.Equals("SaphireS"))
        {
            gemIcon.sprite = gemsImages[8];
        }
        if (gemName.Equals("TopazS"))
        {
            gemIcon.sprite = gemsImages[9];
        }
        if (gemName.Equals("Temporal"))
        {
            gemIcon.sprite = gemsImages[10];
        }
        if (gemName.Equals("Salamander"))
        {
            gemIcon.sprite = gemsImages[11];
        }
        if (gemName.Equals("Basic" ))
        {
            gemIcon.sprite = gemsImages[12];
        }
        if (gemName.Equals("Multiplier"))
        {
            gemIcon.sprite = gemsImages[13];
        }
        if (gemName.Equals("Chronos"))
        {
            gemIcon.sprite = gemsImages[14];
        }
        if (gemName.Equals("Void"))
        {
            gemIcon.sprite = gemsImages[15];
        }
        if (gemName.Equals("Transfiguration"))
        {
            gemIcon.sprite = gemsImages[16];
        }
    }
    public void selectedGem()
    {
       
        for ( i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.HasKey("Selectedgem" + i))
            {
                //Do nothing
                
            }
            else
            {

                PlayerPrefs.SetString("Selectedgem" + i, 
                    mainMenuPanel.mmp.showStatPanel.GetComponent<selectedItemDetails>().Gtype + "/"+ 
                    mainMenuPanel.mmp.showStatPanel.GetComponent<selectedItemDetails>().Gname + "/" +
                    mainMenuPanel.mmp.showStatPanel.GetComponent<selectedItemDetails>().Gnumber);
                //.selectedItemDetailPanel.SetActive(true);
                Container.c.CheckSelectedGems(i);
                mainMenuPanel.mmp.showStatPanel.SetActive(false);
                
                break;
            }
        }
       // Main.instance.selectedGem = true;
    }

    public void showStats()
    {
        //Panel open
        mainMenuPanel.mmp.showStatPanel.SetActive(true);
        PlayerPrefs.GetString("Selectedgem" , gemType + "/" + gemName + "/" + gemNumber);
        mainMenuPanel.mmp.itemName.text = gemName;
        mainMenuPanel.mmp.showStatPanel.GetComponent<selectedItemDetails>().Gname = gemName;
        mainMenuPanel.mmp.showStatPanel.GetComponent<selectedItemDetails>().Gtype = gemType;
        mainMenuPanel.mmp.showStatPanel.GetComponent<selectedItemDetails>().Gnumber = gemNumber;
        mainMenuPanel.mmp.stats.text = PlayerPrefs.GetString(gemType + "/" + gemName + "/" + gemNumber, "");
        if (gemName == "Ruby")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[0];
        }
        else if(gemName == "Amethyst")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[1];
        }
        else if (gemName == "Emerald")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[2];
        }
        else if (gemName == "Saphire")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[3];
        }
        else if (gemName == "Topaz")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[4];
        }
        else if (gemName == "RubySS")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[5];
        }
        else if (gemName == "AmethystSS")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[6];
        }
        else if (gemName == "EmeraldS")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[7];
        }
        else if (gemName == "SaphireS")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[8];
        }
        else if (gemName == "TopazS")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[9];
        }
        else if (gemName == "Temporal")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[10];
        }
        else if (gemName == "Salamander")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[11];
        }
        else if (gemName == "Basic")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[12];
        }
        else if (gemName == "Multiplier")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[13];
        }
        else if (gemName == "Chronos")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[14];
        }
        else if (gemName == "Void")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[15];
        }
        else if (gemName == "Transfiguration")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[16];
        }




    }
}
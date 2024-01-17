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
        PlayerPrefs.SetString("Gem1", "1stTier/ToothBrush/1");
        PlayerPrefs.SetString("Gem2", "1stTier/Toothpaste/2");
        PlayerPrefs.SetString("Gem3", "1stTier/Floss/3");
        PlayerPrefs.SetString("Gem4", "1stTier/MouthWash/4");
        PlayerPrefs.SetString("Gem5", "1stTier/TongueScraper/5");
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

        if (gemName.Equals("ToothBrush"))
        {
            gemIcon.sprite = gemsImages[0]; 
        }
        if (gemName.Equals("Toothpaste"))
        {
            gemIcon.sprite = gemsImages[1]; 
        }
        if (gemName.Equals("Floss"))
        {
            gemIcon.sprite = gemsImages[2]; 
        }
        if (gemName.Equals("MouthWash"))
        {
            gemIcon.sprite = gemsImages[3]; 
        }
        if (gemName.Equals("TongueScraper"))
        {
            gemIcon.sprite = gemsImages[4]; 
        }
        if (gemName.Equals("HawleyRetainer"))
        {
            gemIcon.sprite = gemsImages[5];
        }
        if (gemName.Equals("MolarBands"))
        {
            gemIcon.sprite = gemsImages[6];
        }
        if (gemName.Equals("WaterPick"))
        {
            gemIcon.sprite = gemsImages[7];
        }
        if (gemName.Equals("Elastics"))
        {
            gemIcon.sprite = gemsImages[8];
        }
        if (gemName.Equals("ToothX-Rays"))
        {
            gemIcon.sprite = gemsImages[9];
        }
        if (gemName.Equals("Expander"))
        {
            gemIcon.sprite = gemsImages[10];
        }
        if (gemName.Equals("PlasticRetainer"))
        {
            gemIcon.sprite = gemsImages[11];
        }
        if (gemName.Equals("3DPrinter"))
        {
            gemIcon.sprite = gemsImages[12];
        }
        if (gemName.Equals("WhiteningTray"))
        {
            gemIcon.sprite = gemsImages[13];
        }
        if (gemName.Equals("3DDentalScanner"))
        {
            gemIcon.sprite = gemsImages[14];
        }
        if (gemName.Equals("MetalBraces"))
        {
            gemIcon.sprite = gemsImages[15];
        }
        if (gemName.Equals("Aligners"))
        {
            gemIcon.sprite = gemsImages[16];
        }
        if (gemName.Equals("Whitening"))
        {
            gemIcon.sprite = gemsImages[17];
        }
        if (gemName.Equals("ToothColoredBraces"))
        {
            gemIcon.sprite = gemsImages[18];
        }
        if (gemName.Equals("LingualMetalRetainer"))
        {
            gemIcon.sprite = gemsImages[19];
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
        if (gemName == "ToothBrush")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[0];
        }
        else if(gemName == "Toothpaste")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[1];
        }
        else if (gemName == "Floss")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[2];
        }
        else if (gemName == "MouthWash")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[3];
        }
        else if (gemName == "TongueScraper")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[4];
        }
        else if (gemName == "HawleyRetainer")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[5];
        }
        else if (gemName == "MolarBands")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[6];
        }
        else if (gemName == "WaterPick")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[7];
        }
        else if (gemName == "Elastics")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[8];
        }
        else if (gemName == "ToothX-Rays")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[9];
        }
        else if (gemName == "Expander")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[10];
        }
        else if (gemName == "PlasticRetainer")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[11];
        }
        else if (gemName == "3DPrinter")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[12];
        }
        else if (gemName == "WhiteningTray")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[13];
        }
        else if (gemName == "3DDentalScanner")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[14];
        }
        else if (gemName == "MetalBraces")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[15];
        }
        else if (gemName == "Aligners")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[16];
        }
        else if (gemName == "Whitening")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[17];
        }
        else if (gemName == "ToothColoredBraces")
        {
           mainMenuPanel.mmp.img.sprite = gemsImages[18];
        }
        else if (gemName == "LingualMetalRetainer")
        {
            mainMenuPanel.mmp.img.sprite = gemsImages[19];
        }




    }
}
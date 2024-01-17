using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teeth : MonoBehaviour
{
    public GameObject[] tooth;
    public static teeth t;
    private List<GameObject> enabledObjects = new List<GameObject>();

    private void Awake()
    {
        t = this;
    }

    public void CleanTeeth()
    {
        
        if(Main.instance._scoreTotal >= 1000)
        {
            tooth[0].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 2000)
        {
            tooth[1].SetActive(false);
            
        }
        if (Main.instance._scoreTotal >= 3000)
        {
            tooth[2].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 4000)
        {
            tooth[3].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 5000)
        {
            tooth[4].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 6000)
        {
            tooth[5].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 7000)
        {
            tooth[6].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 8000)
        {
            tooth[7].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 9000)
        {
            tooth[8].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 10000)
        {
            tooth[9].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 11000)
        {
            tooth[10].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 12000)
        {
            tooth[11].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 13000)
        {
            tooth[12].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 14000)
        {
            tooth[14].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 15000)
        {
            tooth[15].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 16000)
        {
            tooth[16].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 17000)
        {
            tooth[17].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 18000)
        {
            tooth[18].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 19000)
        {
            tooth[19].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 20000)
        {
            tooth[20].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 21000)
        {
            tooth[21].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 22000)
        {
            tooth[22].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 23000)
        {
            tooth[23].SetActive(false);
        }
        if (Main.instance._scoreTotal >= 24000)
        {
            tooth[24].SetActive(false);
        }
    }
}

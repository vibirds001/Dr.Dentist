using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public GameObject GemPrefab;
    public float gemOffset = 1f;
    //public Image gemIcon;
    public Image[] selectedGemIcons;
    public Sprite[] gemsImages;
    public static Container c;
    public Sprite RemoveImage;

    private void Awake()
    {
        c = GetComponent<Container>();
    }

    void Start()
    {
        gems();
    }

    public void gems()
    {

        int totalgems = PlayerPrefs.GetInt("totalgems", 5);

        // Remove existing child objects before instantiating new ones
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 1; i <= totalgems; i++)
        {

            Vector3 gemPosition = new Vector3(i * gemOffset, 0f, 0f);
            GameObject g = Instantiate(GemPrefab, transform.position + gemPosition, Quaternion.identity, transform);
            g.GetComponent<GemManager>().gemNumber = i;
        }
    }


    public void CheckSelectedGems(int number)
    {
        string name = PlayerPrefs.GetString("Selectedgem" + number);
        if (name == "")
        {
            selectedGemIcons[number - 1].sprite = RemoveImage;
            return;
        }
        string[] n = name.Split("/");
 
        //if (GemName+gemType+gemNumber == "")
        if (n[1] == "Ruby")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[0];
        }
        else if (n[1] == "Amethyst")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[1];
        }
        else if (n[1] == "Emerald")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[2];
        }
        else if (n[1] == "Saphire")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[3];
        }
        else if (n[1] == "Topaz")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[4];
        }
        else if (n[1] == "RubySS")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[5];
        }
        else if (n[1] == "AmethystSS")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[6];
        }
        else if (n[1] == "EmeraldS")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[7];
        }
        else if (n[1] == "SaphireS")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[8];
        }
        else if (n[1] == "TopazS")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[9];
        }
        else if (n[1] == "Temporal")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[10];
        }
        else if (n[1] == "Salamander")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[11];
        }
        else if (n[1] == "Basic")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[12];
        }
        else if (n[1] == "Multiplier")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[13];
        }
        else if (n[1] == "Chronos")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[14];
        }
        else if (n[1] == "Void")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[15];
        }
        else if (n[1] == "Transfiguration")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[16];
        }
        else
        {
            selectedGemIcons[number - 1].sprite = RemoveImage;
        }
    }


    public void Remove(int number)
    {
        PlayerPrefs.DeleteKey("Selectedgem" + number);
        CheckSelectedGems(number);
    }
}

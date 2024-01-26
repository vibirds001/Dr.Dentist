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
    GridLayoutGroup GLG;
    public RectTransform gridContainer;
    private void Awake()
    {
        c = GetComponent<Container>();
    }

    void Start()
    {
        GLG = GetComponent<GridLayoutGroup>();
        gems();
    }

    private void Update()
    {
        //print(Screen.width + " " + Screen.height);
        //GLG.cellSize = new Vector2(Screen.width / 1080 * 100, Screen.height / 1920 * 100);
        int columns = 3; // Fixed column count
        float padding = GLG.padding.left + GLG.padding.right;
        float spacing = (columns - 1) * GLG.spacing.x;
        float availableWidth = gridContainer.rect.width - padding - spacing;

        // Calculate the cell size based on the available width and number of columns
        float cellWidth = availableWidth / columns;

        // Set the cell size (assuming square cells for simplicity)
        Vector2 cellSize = new Vector2(cellWidth, cellWidth);
        GLG.cellSize = cellSize;
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
        if (n[1] == "ToothBrush")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[0];
        }
        else if (n[1] == "Toothpaste")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[1];
        }
        else if (n[1] == "Floss")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[2];
        }
        else if (n[1] == "MouthWash")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[3];
        }
        else if (n[1] == "TongueScraper")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[4];
        }
        else if (n[1] == "HawleyRetainer")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[5];
        }
        else if (n[1] == "MolarBands")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[6];
        }
        else if (n[1] == "WaterPick")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[7];
        }
        else if (n[1] == "Elastics")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[8];
        }
        else if (n[1] == "ToothX-Rays")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[9];
        }
        else if (n[1] == "Expander")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[10];
        }
        else if (n[1] == "PlasticRetainer")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[11];
        }
        else if (n[1] == "3DPrinter")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[12];
        }
        else if (n[1] == "WhiteningTray")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[13];
        }
        else if (n[1] == "3DDentalScanner")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[14];
        }
        else if (n[1] == "MetalBraces")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[15];
        }
        else if (n[1] == "Aligners")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[16];
        }
        else if (n[1] == "Whitening")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[17];
        }
        else if (n[1] == "ToothColoredBraces")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[18];
        }
        else if (n[1] == "LingualMetalRetainer")
        {
            selectedGemIcons[number - 1].sprite = gemsImages[19];
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

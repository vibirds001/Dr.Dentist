
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int TileNumber;
    public string GemType;
    public string GemNumber;
    public string GemName;
    public bool GemLit;

    public static Tile tile;

    private void Awake()
    {
        tile = this;
    }
    void Start()
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //GemName = spriteRenderer.sprite.name;
        //gameObject.name = GemName;



        //print(spriteRenderer.sprite.name);











        // Declare the variable within the method or class scope

        // Use PlayerPrefs to get a string and split it
        //if (gemManager != null)
        //{
        //    string gem = PlayerPrefs.GetString("Gem" + gemManager.gemNumber);
        //    string[] g = gem.Split('/');
        //    GemType = g[0];
        //    GemName = g[1];
        //    GemNumber = g[2];
            // Rest of your code...
        }



    }



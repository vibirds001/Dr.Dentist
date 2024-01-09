using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelHeader : MonoBehaviour
{


    public static ShopPanelHeader instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        this.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Coin").ToString();

    }

    public void BackButton()
    {
        this.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

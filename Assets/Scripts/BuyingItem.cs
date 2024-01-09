using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{

    public TextMeshProUGUI gemNameText;

    public TextMeshProUGUI DescriptionText;

    public TextMeshProUGUI BuyWithAuraText;

    public TextMeshProUGUI ObtainedItemText;
    public Button BuyButton;

    public int number;

    public GemManager gm;
    private int GemPrice = 500;
    private int BagOfDebris = 1000;
    private int LargeDepositGemPrice = 5000;
    private int ShinyRockGemPrice = 7000;
    private int ShinyDepositGemPrice = 14500;
    private int ULGemPrice = 0;

    private void Start()
    {
        mainMenuPanel.mmp.bagOfDebrisGameObject.SetActive(false);
        mainMenuPanel.mmp.largeDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyRockGameObject.SetActive(false);
        mainMenuPanel.mmp.legandaryGemStoneGameObject.SetActive(false);
        gm = GetComponent<GemManager>();

    }
    public void ThePolished()
    {
        gemNameText.text = "The Polished";
        DescriptionText.text = "Give a 1.3 bonus score for ranked mode.";
        BuyWithAuraText.text = "Buy         " + GemPrice;
        BuyButton.onClick.RemoveAllListeners();
        //BuyButton.onClick.AddListener(() => buyButton(GemPrice, "polished"));
        BuyButton.onClick.AddListener(() => ObtainedPolished(GemPrice, "score increment"));
    }

    public void TheTimeSpirit()
    {

        gemNameText.text = "The Time Spirit";
        DescriptionText.text = "+ 30 seconds in time limit.";
        BuyWithAuraText.text = "Buy         " + GemPrice;
        BuyButton.onClick.RemoveAllListeners();
        //  BuyButton.onClick.AddListener(() => buyButton(GemPrice, "The Time Spirit"));
        BuyButton.onClick.AddListener(() => ObtainedTimeSpirit(GemPrice, "Time Spirit"));

    }

    public void TheClover()
    {
        gemNameText.text = "The Clover";
        DescriptionText.text = "Lucky";
        BuyWithAuraText.text = "Buy         " + GemPrice;
        BuyButton.onClick.RemoveAllListeners();
        //  BuyButton.onClick.AddListener(() => buyButton(GemPrice, "The Clover"));
        BuyButton.onClick.AddListener(() => ObtainedLucky(GemPrice, "Clover"));

    }

    public void BagofDebris()
    {
        gemNameText.text = "Bag of Debris";
        DescriptionText.text = "Grant 3 common gem";
        BuyWithAuraText.text = "Buy         " + BagOfDebris;
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(() => buyButtonBagOfDebris(BagOfDebris, "Bag of Debris"));


    }

    public void LargeDeposit()
    {
        gemNameText.text = "Large Deposit ";
        DescriptionText.text = "Grant 5 gems";
        BuyWithAuraText.text = "Buy         " + LargeDepositGemPrice;
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(() => buyButtonLargeDeposit(LargeDepositGemPrice, "Large Deposit"));


    }

    public void ShinyRock()
    {
        gemNameText.text = "Shiny Rock ";
        DescriptionText.text = "Grant 1 Rare Stone";
        BuyWithAuraText.text = "Buy         " + ShinyRockGemPrice;
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(() => buyButtoShinyRock(ShinyRockGemPrice, "Shiny Rock "));


    }

    public void ShinyDeposit()
    {
        gemNameText.text = "Shiny Deposit";
        DescriptionText.text = "Grant 3 gems.";
        BuyWithAuraText.text = "Buy       " + ShinyDepositGemPrice;
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(() => buyButtonShinyDeposit(ShinyDepositGemPrice, "Shiny Deposit"));


    }

    public void UnrefinedLegendaryGemstone()
    {
        gemNameText.text = "Legendary Gemstone";
        DescriptionText.text = "Grant 1 Legendary Gem ";
        BuyWithAuraText.text = "Buy         " + ULGemPrice;
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(() => buyButtonLegendaryGemStone(ULGemPrice, "Legendary Gemstone"));



    }

    public void ObtainedPolished(int price, string item)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
            PlayerPrefs.SetInt("ThePolished", PlayerPrefs.GetInt("ThePolished", 0) + 1);
            PlayerPrefs.Save();
        }

    }
    public void ObtainedTimeSpirit(int price, string item)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
            PlayerPrefs.SetInt("TimeSpirit", PlayerPrefs.GetInt("TimeSpirit", 0) + 1);
            PlayerPrefs.Save();
        }

    }
    public void ObtainedLucky(int price, string item)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
            PlayerPrefs.SetInt("Lucky", PlayerPrefs.GetInt("Lucky", 0) + 1);
            PlayerPrefs.Save();
        }

    }
    public void buyButtonBagOfDebris(int price, string gem)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            ObtainedBagOfDebris();
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
        }
    }
    public void ObtainedBagOfDebris()
    {
        mainMenuPanel.mmp.obtainedItemPanel.SetActive(true);
        mainMenuPanel.mmp.bagOfDebrisGameObject.SetActive(true);
        mainMenuPanel.mmp.largeDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyRockGameObject.SetActive(false);
        mainMenuPanel.mmp.legandaryGemStoneGameObject.SetActive(false);
        ObtainedItemText.text = "Bag Of Debris";
        int tg = PlayerPrefs.GetInt("totalgems");
        for (int i = 1; i <= 3; i++)
        {
            if (Random.value < 0.05)
            {

                int R = Random.Range(1, 5);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Temporal/" + (tg + 1));
                    SetStats("Rare", "Temporal", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[10];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Salamander/" + (tg + 1));
                    SetStats("Rare", "Salamander", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[11];

                }
                else if (R == 3)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Basic/" + (tg + 1));
                    SetStats("Rare", "Basic", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[12];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Multiplier/" + (tg + 1));
                    SetStats("Rare", "Multiplier", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[13];
                }
            }
            else
            {
                int R = Random.Range(1, 6);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/RubySS/" + (tg + 1));
                    SetStats("common", "RubySS", (tg + 1));
                    tg++;

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/AmethystSS/" + (tg + 1));
                    SetStats("common", "AmethystSS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[6];

                }
                else if (R == 3)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/EmeraldS/" + (tg + 1));
                    SetStats("common", "EmeraldS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[7];

                }
                else if (R == 4)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/SaphireS/" + (tg + 1));
                    SetStats("common", "SaphireS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[8];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/TopazS/" + (tg + 1));
                    SetStats("common", "TopazS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.bagOfDebrisImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[9];

                }
            }
            //CheckSelectedGems(i);
        }
        PlayerPrefs.SetInt("totalgems", PlayerPrefs.GetInt("totalgems") + 3);
        Container.c.gems();
    }
    public void buyButtonLargeDeposit(int price, string gem)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            ObtainedLargeDeposit();
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
        }
    }
    public void ObtainedLargeDeposit()
    {
        mainMenuPanel.mmp.obtainedItemPanel.SetActive(true);
        mainMenuPanel.mmp.bagOfDebrisGameObject.SetActive(false);
        mainMenuPanel.mmp.largeDepositGameObject.SetActive(true);
        mainMenuPanel.mmp.shinyDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyRockGameObject.SetActive(false);
        mainMenuPanel.mmp.legandaryGemStoneGameObject.SetActive(false);
        ObtainedItemText.text = "Large Deposit";
        int tg = PlayerPrefs.GetInt("totalgems");
        for (int i = 1; i <= 5; i++)
        {
            if (Random.value < 0.05)
            {

                int R = Random.Range(1, 5);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Temporal/" + (tg + 1));
                    SetStats("Rare", "Temporal", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[10];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Salamander/" + (tg + 1));
                    SetStats("Rare", "Salamander", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[11];

                }
                else if (R == 3)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Basic/" + (tg + 1));
                    SetStats("Rare", "Basic", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[12];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Multiplier/" + (tg + 1));
                    SetStats("Rare", "Multiplier", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[13];
                }
            }
            else if ((Random.value < 0.95))
            {
                int R = Random.Range(1, 6);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/RubySS/" + (tg + 1));
                    SetStats("common", "RubySS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[5];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/AmethystSS/" + (tg + 1));
                    SetStats("common", "AmethystSS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[6];

                }
                else if (R == 3)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/EmeraldS/" + (tg + 1));
                    SetStats("common", "EmeraldS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[7];

                }
                else if (R == 4)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/SaphireS/" + (tg + 1));
                    SetStats("common", "SaphireS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[8];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/TopazS/" + (tg + 1));
                    SetStats("common", "TopazS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[9];

                }
            }
            else if ((Random.value < 0.001))
            {
                int R = Random.Range(1, 4);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Chronos/" + (tg + 1));
                    SetStats("Legendary", "Chronos", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[14];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Void/" + (tg + 1));
                    SetStats("Legendary", "Void", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[15];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Transfiguration/" + (tg + 1));
                    SetStats("Legendary", "Transfiguration", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.LargeDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[16];

                }
                //CheckSelectedGems(i);
            }
        }
        PlayerPrefs.SetInt("totalgems", PlayerPrefs.GetInt("totalgems") + 5);
        Container.c.gems();
    }
    public void buyButtoShinyRock(int price, string gem)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            ObtainedShinyRock();
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
        }
    }
    public void ObtainedShinyRock()
    {
        mainMenuPanel.mmp.obtainedItemPanel.SetActive(true);
        mainMenuPanel.mmp.bagOfDebrisGameObject.SetActive(false);
        mainMenuPanel.mmp.largeDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyRockGameObject.SetActive(true);
        mainMenuPanel.mmp.legandaryGemStoneGameObject.SetActive(false);
        ObtainedItemText.text = "Shiny Rock";
        int tg = PlayerPrefs.GetInt("totalgems");
        int R = Random.Range(1, 5);
        if (R == 1)
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Temporal/" + (tg + 1));
            SetStats("Rare", "Temporal", (tg + 1));
            mainMenuPanel.mmp.shinyRockImg.sprite = mainMenuPanel.mmp.gemSprite[10];

        }
        else if (R == 2)
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Salamander/" + (tg + 1));
            SetStats("Rare", "Salamander", (tg + 1));
            mainMenuPanel.mmp.shinyRockImg.sprite = mainMenuPanel.mmp.gemSprite[11];

        }
        else if (R == 3)
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Basic/" + (tg + 1));
            SetStats("Rare", "Basic", (tg + 1));
            mainMenuPanel.mmp.shinyRockImg.sprite = mainMenuPanel.mmp.gemSprite[12];

        }
        else
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Multiplier/" + (tg + 1));
            SetStats("Rare", "Multiplier", (tg + 1));
            mainMenuPanel.mmp.shinyRockImg.sprite = mainMenuPanel.mmp.gemSprite[13];
        }
        PlayerPrefs.SetInt("totalgems", PlayerPrefs.GetInt("totalgems") + 1);
        Container.c.gems();



    }
    public void buyButtonShinyDeposit(int price, string gem)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            ObtainedShinyDeposite();
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
        }
    }
    public void ObtainedShinyDeposite()
    {
        mainMenuPanel.mmp.obtainedItemPanel.SetActive(true);
        mainMenuPanel.mmp.bagOfDebrisGameObject.SetActive(false);
        mainMenuPanel.mmp.largeDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyDepositGameObject.SetActive(true);
        mainMenuPanel.mmp.shinyRockGameObject.SetActive(false);
        mainMenuPanel.mmp.legandaryGemStoneGameObject.SetActive(false);
        ObtainedItemText.text = "Shiny Deposit";
        int tg = PlayerPrefs.GetInt("totalgems");
        for (int i = 1; i <= 3; i++)
        {
            if (Random.value < 0.74)
            {

                int R = Random.Range(1, 5);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Temporal/" + (tg + 1));
                    SetStats("Rare", "Temporal", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[10];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Salamander/" + (tg + 1));
                    SetStats("Rare", "Salamander", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[11];

                }
                else if (R == 3)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Basic/" + (tg + 1));
                    SetStats("Rare", "Basic", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[12];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Rare/Multiplier/" + (tg + 1));
                    SetStats("Rare", "Multiplier", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[13];
                }
            }
            else if ((Random.value < 0.25))
            {
                int R = Random.Range(1, 6);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/RubySS/" + (tg + 1));
                    SetStats("common", "RubySS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[5];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/AmethystSS/" + (tg + 1));
                    SetStats("common", "AmethystSS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[6];

                }
                else if (R == 3)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/EmeraldS/" + (tg + 1));
                    SetStats("common", "EmeraldS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[7];

                }
                else if (R == 4)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/SaphireS/" + (tg + 1));
                    SetStats("common", "SaphireS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[8];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "common/TopazS/" + (tg + 1));
                    SetStats("common", "TopazS", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[9];

                }
            }
            else if ((Random.value < 0.01))
            {
                int R = Random.Range(1, 4);
                if (R == 1)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Chronos/" + (tg + 1));
                    SetStats("Legendary", "Chronos", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[14];

                }
                else if (R == 2)
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Void/" + (tg + 1));
                    SetStats("Legendary", "Void", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[15];

                }
                else
                {
                    PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Transfiguration/" + (tg + 1));
                    SetStats("Legendary", "Transfiguration", (tg + 1));
                    tg++;
                    mainMenuPanel.mmp.shinyDepositImg[i - 1].sprite = mainMenuPanel.mmp.gemSprite[16];

                }
                //CheckSelectedGems(i);
            }
        }
        PlayerPrefs.SetInt("totalgems", PlayerPrefs.GetInt("totalgems") + 3);
        Container.c.gems();
    }
    public void buyButtonLegendaryGemStone(int price, string gem)
    {
        if (price <= PlayerPrefs.GetInt("totalaura", 0))
        {
            ObtainedLegendaryGemStone();
            PlayerPrefs.SetInt("totalaura", PlayerPrefs.GetInt("totalaura", 0) - price);
        }
    }
    public void ObtainedLegendaryGemStone()
    {
        mainMenuPanel.mmp.obtainedItemPanel.SetActive(true);
        mainMenuPanel.mmp.bagOfDebrisGameObject.SetActive(false);
        mainMenuPanel.mmp.largeDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyDepositGameObject.SetActive(false);
        mainMenuPanel.mmp.shinyRockGameObject.SetActive(false);
        mainMenuPanel.mmp.legandaryGemStoneGameObject.SetActive(true);
        ObtainedItemText.text = "Legendary GemStone";
        int tg = PlayerPrefs.GetInt("totalgems");
        int R = Random.Range(1, 4);
        if (R == 1)
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Chronos/" + (tg + 1));
            SetStats("Legendary", "Chronos", (tg + 1));
            mainMenuPanel.mmp.largeGemStoneImg.sprite = mainMenuPanel.mmp.gemSprite[14];

        }
        else if (R == 2)
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Void/" + (tg + 1));
            SetStats("Legendary", "Void", (tg + 1));
            mainMenuPanel.mmp.largeGemStoneImg.sprite = mainMenuPanel.mmp.gemSprite[15];

        }
        else
        {
            PlayerPrefs.SetString("Gem" + (tg + 1), "Legendary/Transfiguration/" + (tg + 1));
            SetStats("Legendary", "Transfiguration", (tg + 1));
            mainMenuPanel.mmp.largeGemStoneImg.sprite = mainMenuPanel.mmp.gemSprite[16];

        }
        PlayerPrefs.SetInt("totalgems", PlayerPrefs.GetInt("totalgems") + 1);
        Container.c.gems();
    }

    public void SetStats(string type, string name, int number)
    {
        if (type == "common")
        {
            int R = Random.Range(1, 5);
            if (R == 1)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "moreaura");
            }
            if (R == 2)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "AdditionalTimelimit");
            }
            if (R == 3)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "Crystallization");
            }
            if (R == 4)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "Additionalpoint");
            }
            //Random Stat
        }
        if (type == "Rare" || type == "Legendary")
        {
            int R = Random.Range(1, 5);
            if (R == 1)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "moreaura/AdditionalTimelimit/Crystallization");
            }
            if (R == 2)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "moreaura/AdditionalTimelimit/Additionalpoint");
            }
            if (R == 3)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "moreaura/Crystallization/Additionalpoint");
            }
            if (R == 4)
            {
                PlayerPrefs.SetString(type + "/" + name + "/" + number, "AdditionalTimelimit/Crystallization/Additionalpoint");
            }
            //Random Stat
        }
    }
}


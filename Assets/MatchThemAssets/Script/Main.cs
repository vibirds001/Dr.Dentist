using Holoville.HOTween;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
///  This class is the main entry point of the game it should be attached to a gameobject and be instanciate in the scene
/// Author : Pondomaniac Games
/// </summary>
public class Main : MonoBehaviour
{

    public GameObject _indicator;//The indicator to know the selected tile
    public GameObject[,] _arrayOfShapes;//The main array that contain all games tiles
    public string shapeNumList;      //The main array that contain all integers or index of games tiles
    private GameObject _currentIndicator;//The current indicator to replace and destroy each time the player change the selection
    private GameObject _FirstObject;//The first object selected
    private GameObject _SecondObject;//The second object selected
    public GameObject[] _listOfGems;//The list of tiles we cant to see in the game you can remplace them in unity's inspector and choose all what you want
    public Sprite[] gemsImages;
    public GameObject _emptyGameobject;//After destroying object they are replaced with this one so we will replace them after with new ones
    public GameObject _particleEffect;//The object we want to use in the effect of shining stars 
    public GameObject _particleEffectWhenMatch;//The gameobject of the effect when the objects are matching
    public GameObject _particleEffectWhenMatchGrid;//The gameobject of the effect when the objects are matching
    public GameObject _particleEffectWhenMatchCross;//The gameobject of the effect when the objects are matching
    public GameObject _particleEffectWhenMatchAllType;//The gameobject of the effect when the objects are matching
    public GameObject _particleEffectWhenMatchALit;//The gameobject of the effect when the objects are matching
    //public GameObject teeths;//The gameobject of the effect when the objects are matching

    public bool _canTransitDiagonally = false;//Indicate if we can switch diagonally
    public int _scoreIncrement;//The amount of point to increment each time we find matching tiles
    public int _scoreTotal;//The score 
    private int _AuraTotal = 0;//The aura


    private ArrayList _currentParticleEffets = new ArrayList();//the array that will contain all the matching particle that we will destroy after
    public AudioClip MatchSound;//the sound effect when matched tiles are found
    public int _gridWidth;//the grid number of cell horizontally
    public int _gridHeight;//the grid number of cell vertically
    //inside class
    private Vector2 _firstPressPos;
    private Vector2 _secondPressPos;
    private Vector2 _currentSwipe;
    public GameObject ObtainedItems;
    //NEW CODE
    public Text timerText;
    public Text comboStreakTimerText;
    public Text goalText;
    public TextMeshProUGUI Polishedtext;
    public TextMeshProUGUI TimeSpirittext;
    public TextMeshProUGUI Luckytext;
    public GameObject divider;
    public float timerCount;
    float timeRemaining;
    private float goalCount;
    int levelCount = 1;
    public bool GameStart = true;
    public bool touchToStart = false;
    public bool isFreeze = false;
    public bool selectedGem = false;
    public GameObject loseLevel;

    public GameObject ScoreText;
    public GameObject pauseScoreText;
    public GameObject pauseTimerText;
    public GameObject pauseScoreGO;
    public GameObject pauseTimerGO;
    public GameObject pausePanel;

    private float initialTimeForFiveSecond = 5f;
    private float combotimeRemainingForFiveSecond; // Initial time for the timer
    float combominutesForFiveSecond;
    float combosecondsForFiveSeconds;

    private float initialTimeForFifteenSecond = 15f;
    private float combotimeRemainingForFifteenSecond; // Initial time for the timer
    float combominutesForFifteenSecond;
    float combosecondsForFifteenSeconds;

    private float initialTimeForTenSecond = 10f;
    private float combotimeRemainingForTenSecond; // Initial time for the timer
    float combominutesForTenSecond;
    float combosecondsForTenSeconds;

    public int personNumber;

    private MainMenu _mainMenu;

    private bool isTimePaused = false;

    public GameObject sfxOn;
    public GameObject sfxOff;
    public GameObject comboGameObject;

    public GameObject musicOn;
    public GameObject musicOff;

    public GameObject countdownGO;
    public GameObject BackButton;
    public GameObject PauseButton;

    public GameObject MakeMatchTutorial;
    public GameObject MakeComboTutorial;
   


    public static int timeBase;

    float minutes = 0;
    float seconds = 0;

    bool isStarted = false;
    bool isMakeMatchTutorial = true;
    bool iSMakeComboTutorial = false;
    bool istutorialMoveEnd = false;
    int tutorialState = 0;
    bool isCoundownFinish = false;
    bool isPause = false;

    string statsInGame;

    bool LShapeX = false;
    bool LShapeY = false;

    public static Main instance;

    
    // Use this for initialization
    private void Awake()
    {
        instance = this;

        //if (Application.isMobilePlatform)
        //{
        //    Application.runInBackground = true;
        //}
    }

    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            string name = PlayerPrefs.GetString("Selectedgem" + i);
            string[] n = name.Split("/");
            giveStats(n[0], n[1], int.Parse(n[2]));
        }


        int randomPrice = Random.Range(Persons.instance.minPrice, Persons.instance.maxPrice);
        goalCount = randomPrice;
        

        comboGameObject.SetActive(false);
        ObtainedItems.SetActive(true);
        _mainMenu = GetComponent<MainMenu>();
        BackButton.SetActive(true);
        PauseButton.SetActive(true);
        //SkipButton.SetActive(false);
        MakeMatchTutorial.SetActive(false);
        MakeComboTutorial.SetActive(false);
        //PlayerPrefs.SetInt("totalaura", _scoreTotal);
        _AuraTotal = PlayerPrefs.GetInt("Aura", 0);

        _arrayOfShapes = new GameObject[_gridWidth, _gridHeight];
        if (PlayerPrefs.GetInt("Level", 1) > 1)
        {
            levelCount = PlayerPrefs.GetInt("Level", 1);


            //float randomPrice = Random.Range(Persons.instance.minPrice, Persons.instance.maxPrice);
            //goalCount = randomPrice;
            



            if (PlayerPrefs.GetString("Game") == "Load" && PlayerPrefs.GetInt("Save") > 0)
            {
                _scoreTotal = PlayerPrefs.GetInt("Score", 0);

            }
            else
            {
                _scoreTotal = 0;
            }
        }


        //Creating the gems from the list of gems passed in parameter
        if (PlayerPrefs.GetString("Game") == "Load" && PlayerPrefs.GetInt("Save") > 0 && SaveGame.ReadString(Application.persistentDataPath + "/test.txt") != null)
        {
            LoadGame();
            //  SaveGame.DeleteSavedFile();
        }
        else if (PlayerPrefs.GetString("GameMode") == "Tutorial")
        {
            LoadGame(1);
            SetEnvironemnt();
            MakeMatchTutorial.SetActive(true);
            MakeComboTutorial.SetActive(false);


            UpdateColliederAllTiles(false, 80);
            UpdateColliederRange(10, 10, 4);
            UpdateColliederRange(8, 10, 5);
        }
        else
        {
            for (int i = 0; i <= _gridWidth - 1; i++)
            {
                for (int j = 0; j <= _gridHeight - 1; j++)
                {
                    int randNum = UnityEngine.Random.Range(0, _listOfGems.Length);
                    GameObject go = Instantiate(_listOfGems[randNum], new Vector3(i, j, 0), transform.rotation);
                    //print(go.name + " " + randNum);
                    gemsInUse(randNum, go);
                    _arrayOfShapes[i, j] = go;
                }
            }
            SaveGame.DeleteSavedFile();
        }

        //Adding the star effect to the gems and call the DoShapeEffect continuously
        InvokeRepeating("DoShapeEffect", 1f, 0.21F);
        if (PlayerPrefs.GetString("GameMode") == "TimeAttack")
        {
            if (PlayerPrefs.GetString("Game") == "Load" && PlayerPrefs.GetInt("Save") > 0)
            {
                Debug.Log("Time remaining" + timerCount);
                timeRemaining = PlayerPrefs.GetInt("TimeRemaining", (int)timerCount);
                _scoreTotal = PlayerPrefs.GetInt("Score", 0);
                timeRemaining = timeRemaining + additionalTime;
            }
            else
            {
                timeRemaining = timerCount + additionalTime;
            }
            timerText.enabled = true;
            goalText.enabled = true;
            //LevelText.SetActive(false);
            divider.SetActive(true);
            pauseScoreGO.SetActive(true);
            pauseTimerGO.SetActive(true);

        }
        else if (PlayerPrefs.GetString("GameMode") == "Classic")
        {
            if (PlayerPrefs.GetString("Game") == "Load" && PlayerPrefs.GetInt("Save") > 0)
            {
                timeRemaining = PlayerPrefs.GetInt("TimeRemaining", (int)timerCount);

                _scoreTotal = PlayerPrefs.GetInt("Score", 0);
                timeRemaining = timeRemaining + additionalTime;

            }
            else
            {
                timeRemaining = timerCount + additionalTime;
            }
            timerText.enabled = true;
            goalText.enabled = false;
           //LevelText.SetActive(false);
            divider.SetActive(true);
            pauseScoreGO.SetActive(true);
            pauseTimerGO.SetActive(true);

        }

        // Update the UI text to display the current total aura count
        Polishedtext.text = PlayerPrefs.GetInt("ThePolished", 0).ToString();
        TimeSpirittext.text = PlayerPrefs.GetInt("TimeSpirit", 0).ToString();
        Luckytext.text = PlayerPrefs.GetInt("Lucky", 0).ToString();

    }
    private void UpdateCollider()
    {

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                GameObject go = _arrayOfShapes[i, j];
                if (j >= _gridHeight - 2)
                {
                    go.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 80);
                    go.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 80);

                    go.GetComponent<BoxCollider2D>().enabled = false;
                }
                else if (j != 0)
                {
                    go.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    go.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    go.GetComponent<BoxCollider2D>().enabled = true;
                }
                _arrayOfShapes[i, j] = go;
            }
        }
    }
    void UpdateColliederAllTiles(bool status, byte alpha = 255)
    {
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                GameObject go = _arrayOfShapes[i, j];
                go.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
                go.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
                go.GetComponent<BoxCollider2D>().enabled = status;

            }
        }
    }
    void UpdateColliederAllTiles_Survival(bool status, byte alpha = 255)
    {
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight - 2; j++)
            {
                GameObject go = _arrayOfShapes[i, j];
                go.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
                go.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);

                go.GetComponent<BoxCollider2D>().enabled = status;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {


        if (iSMakeComboTutorial == true && PlayerPrefs.GetString("GameMode") == "Tutorial")
        {

            MakeMatchTutorial.SetActive(false);
            MakeComboTutorial.SetActive(true);
            UpdateColliederAllTiles(false, 80);
            UpdateColliederRange(2, 2, 4);
            UpdateColliederRange(0, 2, 3);

        }
        else if (istutorialMoveEnd == true && PlayerPrefs.GetString("GameMode") == "Tutorial")
        {

            MakeMatchTutorial.SetActive(false);
            MakeComboTutorial.SetActive(false);
            UpdateColliederAllTiles(true, 255);
        }

        if ((PlayerPrefs.GetString("GameMode") == "Survival") && (PlayerPrefs.GetString("Game") == "Load") && PlayerPrefs.GetInt("Save") > 0 && (isCoundownFinish == true))
        {
            UpdateCollider();
        }
        else if (PlayerPrefs.GetString("GameMode") == "Survival" && PlayerPrefs.GetString("Game") == "")
        {
            UpdateCollider();
        }
        if (touchToStart == false)
        {

            //    _scoreTotal = 0;
        }
        else if (PlayerPrefs.GetString("GameMode") == "Classic" && PlayerPrefs.GetString("Game") == "")
        {

            if (touchToStart)
            {
                if (!isFreeze)
                {
                    timeRemaining -= Time.deltaTime;
                }
            }



            else
            {
                if (PlayerPrefs.GetString("Game") == "Load" && PlayerPrefs.GetInt("Save") > 0)
                {
                    timeRemaining = PlayerPrefs.GetInt("TimeRemaining", (int)timerCount);
                }
                else
                {
                    timeRemaining = timerCount;
                }

                //timeRemaining = timerCount;
            }

            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);
            if (timeRemaining > 0)
            {
                timerText.text = "Timer  " + minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            else if (GameStart)
            {
                Time.timeScale = 0f;
                loseLevel.SetActive(true);
                //save aura

                // Retrieve the existing total aura from PlayerPrefs
                int previousTotalAura = PlayerPrefs.GetInt("totalaura", 0);

                // Add the current score to the existing total aura
                int updatedTotalAura = previousTotalAura + _scoreTotal;
                updatedTotalAura = updatedTotalAura + Mathf.RoundToInt(updatedTotalAura * increment);

                int additionalAura = crystallizationCount * 1000;
                updatedTotalAura += additionalAura;

                PlayerPrefs.SetInt("totalaura", updatedTotalAura);


                //GetComponent<MainMenu>().aura();

                // Save changes to PlayerPrefs
                PlayerPrefs.Save();

                GameStart = false;
                SoundManager.instance.Play_LEVEL_FAILED_Sound();
                UpdateColliederAllTiles(false, 80);
            }
        }
        if (touchToStart == false)
        {

            //    _scoreTotal = 0;
        }
        if (PlayerPrefs.GetString("GameMode") == "TimeAttack")
        {

            if (touchToStart)
            {
                if (!isFreeze)
                {
                    timeRemaining -= Time.deltaTime;
                }
            }
            else
            {
                if (PlayerPrefs.GetString("Game") == "Load" && PlayerPrefs.GetInt("Save") > 0)
                {
                    timeRemaining = PlayerPrefs.GetInt("TimeRemaining", (int)timerCount);
                }
                else
                {
                    timeRemaining = timerCount;
                }

                //timeRemaining = timerCount;
            }

            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);
            if (timeRemaining > 0)
            {
                timerText.text = "Timer  " + minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            else if (GameStart)
            {
                loseLevel.SetActive(true);
                GameStart = false;
                //save aura

                // Retrieve the existing total aura from PlayerPrefs
                int previousTotalAura = PlayerPrefs.GetInt("totalaura", 0);

                // Add the current score to the existing total aura
                int updatedTotalAura = previousTotalAura + _scoreTotal;
                updatedTotalAura = updatedTotalAura + Mathf.RoundToInt(updatedTotalAura * increment);

                int additionalAura = crystallizationCount * 1000;
                updatedTotalAura += additionalAura;

                PlayerPrefs.SetInt("totalaura", updatedTotalAura);

                //GetComponent<MainMenu>().aura();

                // Save changes to PlayerPrefs
                PlayerPrefs.Save();
                SoundManager.instance.Play_LEVEL_FAILED_Sound();
                UpdateColliederAllTiles(false, 80);
            }

            goalText.text = "$: " + goalCount.ToString();
            if (_scoreTotal >= goalCount)
            {
                SoundManager.instance.Play_LEVEL_COMPLETE_Sound();
                //_scoreTotal = 0;

                int randomPrice = Random.Range(Persons.instance.minPrice, Persons.instance.maxPrice);
                goalCount = randomPrice;
                
                
                Persons.instance.person[personNumber-1].person.SetActive(false);
                personNumber++;
                Persons.instance.person[personNumber - 1].person.SetActive(true);

                timeRemaining = timerCount;
                levelCount++;
                //PlayerPrefs.SetInt("Level", levelCount);
            }
        }
        bool shouldTransit = false;
        var direction = Direction.NONE;
        if (isPause == false)
        {
            direction = Swipe();
        }
        //    print("Direction : " + direction);
        if (direction != Direction.NONE && direction != Direction.STATIONARY)
        {
            //Detecting if the player clicked on the left mouse button and also if there is no animation playing
            if (HOTween.GetTweenInfos() == null)
            {

                Destroy(_currentIndicator);
                //The 3 following lines is to get the clicked GameObject and getting the RaycastHit2D that will help us know the clicked object
                //Ray ray   = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(_firstPressPos), Vector2.zero);
                Debug.Log(_firstPressPos);
                if (hit.transform != null)
                {  //To know if the user already selected a tile or not yet

                    if (_FirstObject == null)

                    {
                        _FirstObject = hit.transform.gameObject;
                        if (direction != Direction.STATIONARY)
                        {
                            Vector3 hit2Position = hit.transform.position;
                            switch (direction)
                            {
                                case Direction.UP:
                                    hit2Position.y++; break;
                                case Direction.DOWN:
                                    hit2Position.y--; break;
                                case Direction.LEFT:
                                    hit2Position.x--; break;
                                case Direction.RIGHT:
                                    hit2Position.x++; break;

                            }

                            RaycastHit2D hit2 = Physics2D.Raycast(hit2Position, Vector2.zero);
                            if (hit2.transform != null)
                            {
                                _SecondObject = hit2.transform.gameObject;
                                shouldTransit = true;
                            }
                        }
                    }
                    else
                    {
                        _SecondObject = hit.transform.gameObject;
                        shouldTransit = true;
                    }
                    // temporary commented
                    _currentIndicator = GameObject.Instantiate(_indicator, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, -1), transform.rotation) as GameObject;


                    //If the user select the second tile we will swap the two tile and animate them
                    if (shouldTransit)
                    {
                        //Getting the position between the 2 tiles
                        var distance = _FirstObject.transform.position - _SecondObject.transform.position;
                        //Testing if the 2 tiles are next to each others otherwise we will not swap them 
                        if (Mathf.Abs(distance.x) <= 1 && Mathf.Abs(distance.y) <= 1)
                        {   //If we dont want the player to swap diagonally
                            if (!_canTransitDiagonally)
                            {
                                if (distance.x != 0 && distance.y != 0)
                                {
                                    Destroy(_currentIndicator);
                                    _FirstObject = null;
                                    _SecondObject = null;
                                    return;
                                }
                            }
                            //Animate the transition
                            DoSwapMotion(_FirstObject.transform, _SecondObject.transform);
                            //Swap the object in array
                            DoSwapTile(_FirstObject, _SecondObject, ref _arrayOfShapes);


                        }
                        else
                        {
                            _FirstObject = null;
                            _SecondObject = null;

                        }
                        Destroy(_currentIndicator);

                    }

                }

            }
        }
        //If no animation is playing
        if (HOTween.GetTweenInfos() == null)
        {

            var Matches = FindMatch(_arrayOfShapes);
            //If we find a matched tiles
            if (Matches.Count > 0)
            {
                //Update Timer
                if (PlayerPrefs.GetString("GameMode") == "TimeAttack")
                {
                    CalculateTimeAddition();
                }
                if (touchToStart)
                {
                    int extra = 0;
                    string[] gemsForExtraPoint = pointGems.Split("/");
                    foreach (GameObject item in Matches)
                    {
                        for (int i = 0; i < gemsForExtraPoint.Length; i++)
                        {
                            if (item.name == gemsForExtraPoint[i])
                            {
                                extra++;
                            }
                        }
                    }
                    print("extra " + extra);
                    CalculateScore(Matches.Count, extra);

                }
                // Additionalpoint(GemManager.gm.gemName);

                string gemName = "AA";
                string gemType = "gg";
                bool lit = false;

                if (_FirstObject != null)
                {
                    gemName = _FirstObject.GetComponent<Tile>().GemName;

                    gemType = _FirstObject.GetComponent<Tile>().GemType;
                    lit = _FirstObject.GetComponent<Tile>().GemLit;
                }
                if (_SecondObject != null)
                {
                    gemName = _FirstObject.GetComponent<Tile>().GemName;

                }
                int startingX = 0; // Initialize prevI for each outer loop iteration
                int startingY = 0; // Initialize prevJ for each inner loop iteration
                if (Matches.Contains(_FirstObject))
                {
                    startingX = (int)_FirstObject.transform.position.x;
                    startingY = (int)_FirstObject.transform.position.y;
                }
                else if (Matches.Contains(_SecondObject))
                {
                    startingX = (int)_SecondObject.transform.position.x;
                    startingY = (int)_SecondObject.transform.position.y;
                }
                foreach (GameObject item in Matches)
                {
                    if (item.transform.position.x != startingX)
                    {
                        //it is L shape
                        //print("LShape in x");
                        LShapeX = true;
                    }
                }
                foreach (GameObject item in Matches)
                {
                    if (item.transform.position.y != startingY)
                    {
                        //print("LShape in y");
                        //it is L shape
                        LShapeX = true;
                    }
                }

                if (gemType == "1stTier")
                {
                    if (Matches.Count == 4 || Matches.Count == 5)
                    {

                        DestroyforCommonGem();
                    }

                    if ((LShapeX == true) && (LShapeY == true))
                    {
                        DestroyforCommonGem();

                    }

                }

                if (lit == true)
                {
                    if (Matches.Count == 3 || Matches.Count == 4 || Matches.Count == 5)
                    {
                        DestroyforCommonGem();
                    }
                    else if (lit != true)
                    {
                        var destroy = _particleEffectWhenMatchALit;
                        Destroy(destroy);
                    }
                }
                if (gemType == "2ndTier")
                {
                    if (Matches.Count == 4)
                    {
                        DestroyforCommonGem();


                    }
                    if ((LShapeX == true) && (LShapeY == true))
                    {
                        DestroyforCommonGemFiveMatches();
                    }

                }
                if (gemType == "2ndTier")
                {
                    if (Matches.Count == 5)
                    {
                        if (gemName == "HawleyRetainer")
                        {
                            DestroyCommonGemForSpecial("HawleyRetainer");
                        }

                    }
                    if (Matches.Count == 5)
                    {
                        if (gemName == "MolarBands")
                        {
                            DestroyCommonGemForSpecial("MolarBands");
                        }

                    }
                    if (Matches.Count == 5)
                    {
                        if (gemName == "WaterPick")
                        {
                            DestroyCommonGemForSpecial("WaterPick");
                        }

                    }
                    if (Matches.Count == 5)
                    {
                        if (gemName == "Elastics")
                        {
                            DestroyCommonGemForSpecial("Elastics");
                        }

                    }
                    if (Matches.Count == 5)
                    {
                        if (gemName == "ToothX-Rays")
                        {
                            DestroyCommonGemForSpecial("ToothX-Rays");
                        }

                    }
                }
                if (gemName == "Expander")
                {
                    if (Matches.Count == 5)
                    {
                        TemporalGemTimeAdditionFiveMatches();
                    }
                    if (Matches.Count == 4)
                    {
                        TemporalGemTimeAddition();
                    }
                    if ((LShapeX == true) && (LShapeY == true))
                    {
                        TemporalGemTimeAdditionLMatches();
                    }

                }
                if (gemName == "PlasticRetainer")
                {
                    if (Matches.Count == 4)
                    {
                        DestroyforSalamandarGem();
                    }
                    if ((LShapeX == true) && (LShapeY == true))
                    {
                        SalamanderForLGems();
                    }
                    if (Matches.Count == 5)
                    {
                        SalamanderForFiveGems();
                    }
                    //

                }
                if (gemName == "3DPrinter")
                {
                    if (Matches.Count == 4)
                    {
                        DestroyforCommonGem();
                    }
                    if ((LShapeX == true) && (LShapeY == true))
                    {
                        DestroyforCommonGemFiveMatches();
                    }
                    if (Matches.Count == 5)
                    {
                        if (gemName == "3DPrinter")
                        {
                            DestroyCommonGemForSpecial("3DPrinter");
                        }
                    }
                }
                if (gemName == "WhiteningTray")
                {
                    if (Matches.Count == 4)
                    {
                        comboStreakFiveSecond();
                    }
                    if (Matches.Count == 5)
                    {
                        comboStreakFifteenSecond();
                    }
                    if ((LShapeY == true) && (LShapeX == true))
                    {
                        comboStreakTenSecond();
                    }
                }
                if (gemName == "MetalBraces")
                {
                    if (Matches.Count == 5)
                    {
                        ChoronusGemEffectForFive();
                    }
                    if ((LShapeY == true) && (LShapeX == true))
                    {
                        ChoronusGemEffectForLShape();
                    }
                }
                if (gemName == "Aligners")
                {
                    if (Matches.Count == 5)
                        ClearBoardVoid();
                }
                if (gemName == "Whitening")
                {
                    if (Matches.Count == 4)
                    {
                        TransfigurationForFiveGems();
                    }
                    if ((LShapeX == true) && (LShapeY == true))
                    {
                        TransfigurationForLShape();
                    }
                    if (Matches.Count == 5)
                    {
                        RandomizeAllGems();
                    }

                }




                foreach (GameObject go in Matches)
                {
                    //Playing the matching sound
                    SoundManager.instance.Play_MATCH_TILE_Sound();
                    //GetComponent<AudioSource>().PlayOneShot(MatchSound);
                    //Creating and destroying the effect of matching
                    gemName = go.GetComponent<Tile>().GemName;
                    var destroyingParticle = GameObject.Instantiate(_particleEffectWhenMatch as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                    Destroy(destroyingParticle, 1f);
                    //Replace the matching tile with an empty one
                    _arrayOfShapes[(int)go.transform.position.x, (int)go.transform.position.y] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                    //Destroy the ancient matching tiles
                    Destroy(go, 0.1f);
                }
                _FirstObject = null;
                _SecondObject = null;
                //Moving the tiles down to replace the empty ones
                DoEmptyDown(ref _arrayOfShapes);
            }
            //If no matching tiles are found remake the tiles at their places
            else if (_FirstObject != null
                     && _SecondObject != null
                     )
            {
                //Animate the tiles
                DoSwapMotion(_FirstObject.transform, _SecondObject.transform);
                //Swap the tiles in the array
                DoSwapTile(_FirstObject, _SecondObject, ref _arrayOfShapes);
                _FirstObject = null;
                _SecondObject = null;

            }
        }
        //Update the score
        //LevelText.GetComponent<Text>().text = "Level : " + levelCount.ToString();
        ScoreText.GetComponent<Text>().text = "Coins : " + _scoreTotal.ToString();

        //  (GetComponent(typeof(TextMesh)) as TextMesh).text = "     LEVEL: " + levelCount + "   SCORE: " + _scoreTotal.ToString();
    }
    private void CalculateScore(int matchCount, int extraPoints)
    {
        if (PlayerPrefs.GetString("GameMode") == "Tutorial")
        {
            if (isMakeMatchTutorial)
            {
                isMakeMatchTutorial = false;
                iSMakeComboTutorial = true;
                istutorialMoveEnd = false;
            }
            else if (iSMakeComboTutorial)
            {
                isMakeMatchTutorial = false;
                iSMakeComboTutorial = false;
                istutorialMoveEnd = true;
            }
            //else if (istutorialMoveEnd)
            //{
            //    isMakeMatchTutorial = false;
            //    iSMakeComboTutorial = false;
            //    istutorialMoveEnd = false;
            //}
        }

        _scoreTotal += matchCount * _scoreIncrement + extraPoints;
        //int subScoreTotal = 0;
        //for (int i = 4; i <= matchCount; i++)
        //{
        //    float multiply = 1;
        //    for (int j = 0; j < i - 3; j++)
        //    {
        //        multiply = multiply * 1.25f;

        //    }
        //    subScoreTotal = (int)(subScoreTotal + 50 * (multiply));

        //}
        //_scoreTotal = _scoreTotal + subScoreTotal;
        //int modOfScore = _scoreTotal % 5;
        //if (modOfScore < 3)
        //{
        //    _scoreTotal = _scoreTotal - modOfScore;
        //}
        if (combotimeRemainingForFiveSecond > 0)
        {
            _scoreTotal += matchCount * 2;
        }
        else if (combotimeRemainingForTenSecond > 0)
        {
            _scoreTotal += matchCount * 2;
        }
        else if (combotimeRemainingForFifteenSecond > 0)
        {
            _scoreTotal += matchCount * 2;
        }
        else if (statsAdditionalpoint == true)
        {
            _scoreTotal = _scoreTotal + 1;
        }

        else if (_scoreTotal >= 1000)
        {

        }
        teeth.t.CleanTeeth();
        //else
        //{
        //    _scoreTotal = _scoreTotal - modOfScore + 5;
        //}
    }
    private void CalculateTimeAddition()
    {
        float timeAddition = 3 - (timeBase * 0.1f);
        if (timeAddition < 1)
        {
            timeAddition = 1;
        }
        timeRemaining = timeRemaining + timeAddition;
        timeBase++;


        //Update the score
        //  _scoreTotal += Matches.Count * _scoreIncrement;

    }
    // Find Match-3 Tile
    private ArrayList FindMatch(GameObject[,] cells)
    {//creating an arraylist to store the matching tiles
        ArrayList stack = new ArrayList();
        //Checking the vertical tiles
        int upperBoundLimitizer = 0;
        if (PlayerPrefs.GetString("GameMode") == "Survival")
        {
            upperBoundLimitizer = 2;
        }
        for (var x = 0; x <= cells.GetUpperBound(0); x++)
        {
            for (var y = 0; y <= cells.GetUpperBound(1) - upperBoundLimitizer; y++)
            {
                var thiscell = cells[x, y];
                //If it's an empty tile continue
                if (thiscell.name == "Empty(Clone)") continue;
                int matchCount = 0;
                int y2 = cells.GetUpperBound(1) - upperBoundLimitizer;
                int y1;
                //Getting the number of tiles of the same kind
                for (y1 = y + 1; y1 <= y2; y1++)
                {
                    if (cells[x, y1].name == "Empty(Clone)" || thiscell.name != cells[x, y1].name) break;
                    matchCount++;
                }
                //If we found more than 2 tiles close we add them in the array of matching tiles
                if (matchCount >= 2)
                {
                    y1 = Mathf.Min(cells.GetUpperBound(1), y1 - 1);
                    for (var y3 = y; y3 <= y1; y3++)
                    {
                        if (!stack.Contains(cells[x, y3]))
                        {
                            stack.Add(cells[x, y3]);
                        }
                    }
                }
            }
        }
        //Checking the horizontal tiles , in the following loops we will use the same concept as the previous ones
        for (var y = 0; y <= cells.GetUpperBound(1) - upperBoundLimitizer; y++)
        {
            for (var x = 0; x <= cells.GetUpperBound(0); x++)
            {
                var thiscell = cells[x, y];
                if (thiscell.name == "Empty(Clone)") continue;
                int matchCount = 0;
                int x2 = cells.GetUpperBound(0);
                int x1;
                for (x1 = x + 1; x1 <= x2; x1++)
                {
                    if (cells[x1, y].name == "Empty(Clone)" || thiscell.name != cells[x1, y].name) break;
                    matchCount++;
                }
                if (matchCount >= 2)
                {
                    x1 = Mathf.Min(cells.GetUpperBound(0), x1 - 1);
                    for (var x3 = x; x3 <= x1; x3++)
                    {
                        if (!stack.Contains(cells[x3, y]))
                        {
                            stack.Add(cells[x3, y]);
                        }
                    }
                }
            }
        }
        return stack;
    }


    public void CountAura(int totalAura)
    {
        int aura = PlayerPrefs.GetInt("Aura", totalAura);
        aura = _scoreTotal;
        // _mainMenu.AuraText.text = ScoreText.GetComponent<Text>().text;

    }



    private int checkAvailableMatches(GameObject[,] cells)
    {
        ArrayList stack = new ArrayList();
        int numberOfMatches = 0;
        for (var x = 0; x <= cells.GetUpperBound(0); x++)
        {
            for (var y = 0; y <= cells.GetUpperBound(1) - 2; y++)
            {
                var thiscell = cells[x, y];
                //If it's an empty tile continue
                if (thiscell.name == "Empty(Clone)") continue;
                int matchCount = 0;
                int y2 = cells.GetUpperBound(1);
                int y1;
                int matchIndex = -1;

                for (y1 = y + 1; y1 <= y + 2; y1++)
                {
                    if (cells[x, y1].name == "Empty(Clone)" || thiscell.name != cells[x, y1].name) break;
                    {
                        matchCount++;
                        matchIndex = y1;
                    }
                }
                if (matchIndex < y1 && matchCount != 0 && matchIndex != -1)
                {
                    if (x != cells.GetUpperBound(0))
                    {
                        if (cells[x + 1, y1].name == "Empty(Clone)" || thiscell.name != cells[x + 1, y1].name) break;
                        {
                            numberOfMatches++;
                        }
                    }
                    if (x != 0)
                    {

                        if (cells[x - 1, y1].name == "Empty(Clone)" || thiscell.name != cells[x - 1, y1].name) break;
                        {
                            numberOfMatches++;
                        }
                    }
                }
                else if (matchIndex > y1 && matchCount != 0 && matchIndex != -1)
                {
                    if (cells[x + 1, y1 - 1].name == "Empty(Clone)" || thiscell.name != cells[x + 1, y1 - 1].name) break;
                    {
                        numberOfMatches++;
                    }
                    if (cells[x - 1, y1 - 1].name == "Empty(Clone)" || thiscell.name != cells[x - 1, y1 - 1].name) break;
                    {
                        numberOfMatches++;
                    }

                }

            }
        }

        for (var y = 0; y <= cells.GetUpperBound(1); y++)
        {
            for (var x = 0; x <= cells.GetUpperBound(0) - 2; x++)
            {
                var thiscell = cells[x, y];
                //If it's an empty tile continue
                if (thiscell.name == "Empty(Clone)") continue;
                int matchCount = 0;
                int x2 = cells.GetUpperBound(0);
                int x1;
                int matchIndex = -1;

                for (x1 = x + 1; x1 <= x + 2; x1++)
                {
                    if (cells[x1, y].name == "Empty(Clone)" || thiscell.name != cells[x1, y].name) break;
                    {
                        matchCount++;
                        matchIndex = x1;
                    }
                }
                if (matchIndex < x1 && matchCount != 0 && matchIndex != -1)
                {
                    if (y != cells.GetUpperBound(1))
                    {
                        if (cells[x1, y + 1].name == "Empty(Clone)" || thiscell.name != cells[x1, y + 1].name) break;
                        {
                            numberOfMatches++;
                        }
                    }
                    if (y != 0)
                    {

                        if (cells[x1, y - 1].name == "Empty(Clone)" || thiscell.name != cells[x1, y - 1].name) break;
                        {
                            numberOfMatches++;

                        }
                    }
                }
                else if (matchIndex > x1 && matchCount != 0 && matchIndex != -1)
                {
                    if (cells[x1 - 1, y + 1].name == "Empty(Clone)" || thiscell.name != cells[x1 - 1, y + 1].name) break;
                    {
                        numberOfMatches++;

                    }
                    if (cells[x1 - 1, y - 1].name == "Empty(Clone)" || thiscell.name != cells[x1 - 1, y - 1].name) break;
                    {
                        numberOfMatches++;

                    }

                }

            }
        }

        return numberOfMatches;
    }
    // Swap Motion Animation, to animate the switching arrays
    void DoSwapMotion(Transform a, Transform b)
    {
        Vector3 posA = a.localPosition;
        Vector3 posB = b.localPosition;
        TweenParms parms = new TweenParms().Prop("localPosition", posB).Ease(EaseType.EaseOutQuart);
        HOTween.To(a, 0.25f, parms).WaitForCompletion();
        parms = new TweenParms().Prop("localPosition", posA).Ease(EaseType.EaseOutQuart);
        HOTween.To(b, 0.25f, parms).WaitForCompletion();
    }


    // Swap Two Tile, it swaps the position of two objects in the grid array
    void DoSwapTile(GameObject a, GameObject b, ref GameObject[,] cells)
    {
        GameObject cell = cells[(int)a.transform.position.x, (int)a.transform.position.y];
        cells[(int)a.transform.position.x, (int)a.transform.position.y] = cells[(int)b.transform.position.x, (int)b.transform.position.y];
        cells[(int)b.transform.position.x, (int)b.transform.position.y] = cell;
    }

    // Do Empty Tile Move Down
    private void DoEmptyDown(ref GameObject[,] cells)
    {   //replace the empty tiles witthe ones above
        for (int x = 0; x <= cells.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= cells.GetUpperBound(1); y++)
            {

                var thisCell = cells[x, y];
                if (thisCell.name == "Empty(Clone)")
                {

                    for (int y2 = y; y2 <= cells.GetUpperBound(1); y2++)
                    {
                        if (cells[x, y2].name != "Empty(Clone)")
                        {
                            cells[x, y] = cells[x, y2];
                            cells[x, y2] = thisCell;
                            break;
                        }

                    }

                }

            }
        }
        //Instantiate new tiles to replace the ones destroyed
        for (int x = 0; x <= cells.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= cells.GetUpperBound(1); y++)
            {
                if (cells[x, y].name == "Empty(Clone)")
                {
                    Destroy(cells[x, y]);
                    int randNum = UnityEngine.Random.Range(0, _listOfGems.Length);
                    cells[x, y] = GameObject.Instantiate(_listOfGems[randNum] as GameObject, new Vector3(x, cells.GetUpperBound(1) + 2, 0), transform.rotation) as GameObject;
                    gemsInUse(randNum, cells[x, y]);
                }
            }
        }

        for (int x = 0; x <= cells.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= cells.GetUpperBound(1); y++)
            {

                TweenParms parms = new TweenParms().Prop("position", new Vector3(x, y, -1)).Ease(EaseType.EaseOutQuart);
                HOTween.To(cells[x, y].transform, .4f, parms);
            }
        }



    }
    //Instantiate the star objects
    void DoShapeEffect()
    {
        StartCoroutine(runAnim());
        foreach (GameObject row in _currentParticleEffets)
            Destroy(row);
        for (int i = 0; i <= 2; i++)
        {
            _currentParticleEffets.Add(GameObject.Instantiate(_particleEffect, new Vector3(UnityEngine.Random.Range(0, _arrayOfShapes.GetUpperBound(0) - 2), UnityEngine.Random.Range(0, _arrayOfShapes.GetUpperBound(1) - 2), -1), new Quaternion(0, 0, UnityEngine.Random.Range(0, 1000f), 100)) as GameObject);


        }
    }
    IEnumerator runAnim()
    {
        for (int i = 0; i <= 2; i++)
        {
            int row = UnityEngine.Random.Range(0, _arrayOfShapes.GetUpperBound(0));
            int col = UnityEngine.Random.Range(0, _arrayOfShapes.GetUpperBound(1) - 2);
            // _arrayOfShapes[row, col].GetComponent<Animator>().enabled = true;

            yield return new WaitForSeconds(1);
            //_arrayOfShapes[row, col].GetComponent<Animator>().enabled = false;
        }
    }

    enum Direction
    {
        NONE,
        STATIONARY,
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    private Direction Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchToStart = true;
            //save began touch 2d point
            _firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _currentIndicator = GameObject.Instantiate(_indicator, new Vector3(_firstPressPos.x, _firstPressPos.y, -1), transform.rotation) as GameObject;

        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            _secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            _currentSwipe = new Vector2(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);
            //print("SwipePosition"+_currentSwipe);

            //normalize the 2d vector
            _currentSwipe.Normalize();

            //swipe upwards
            if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
                return Direction.UP;
            }
            //swipe down
            if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
                return Direction.DOWN;
            }
            //swipe left
            if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                return Direction.LEFT;
            }
            //swipe right
            if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                return Direction.RIGHT;
            }
            return Direction.STATIONARY;
        }
        return Direction.NONE;
    }

    public void OpenPausePanel()
    {
        //teeths.SetActive(false);
        isPause = true;
        string fileData = SaveGame.ReadString(Application.persistentDataPath + "/test.txt");
        if (fileData == null)
        {
            SaveMyGame();
        }
        else if (fileData != null)
        {
            SaveGame.DeleteSavedFile();
            SaveMyGame();
        }
        ObtainedItems.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pauseScoreText.GetComponent<Text>().text = _scoreTotal.ToString();
        pauseTimerText.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
        SoundManager.instance.Play_BUTTON_CLICK_Sound();


    }
    public void ClosePausePanel()
    {
        //teeths.SetActive(true);
        ObtainedItems.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        isPause = false;

    }
    IEnumerator addDelay()
    {

        yield return new WaitForSeconds(0.5f);

    }

    public void Music_on()
    {
        MusicManager.instance.OnClick_Music_Button_ON();
    }
    public void Music_off()
    {
        MusicManager.instance.OnClick_Music_Button_OFF();
    }
    public void SFX_on()
    {
        SoundManager.instance.OnClick_SFX_Button_ON();
    }
    public void SFX_off()
    {
        SoundManager.instance.OnClick_SFX_Button_OFF();
    }


    void Set_SOUND_ICON_STATUS()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            // SFX OFF
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else
        {
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);            // SFX ON


        }

        if (PlayerPrefs.GetInt("MUSIC", 1) == 0)
        {
            // MUSIC OFF
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
        else
        {
            // MUSIC ON
            musicOff.SetActive(false);
            musicOn.SetActive(true);
        }

    }

    public void SaveMyGame()
    {
        shapeNumList = "";
        for (int i = 0; i < _gridWidth; i++)
        {
            string temp = "";
            for (int j = 0; j < _gridHeight; j++)
            {

                temp += _arrayOfShapes[i, j].gameObject.GetComponent<Tile>().TileNumber.ToString();
                if (j < _gridHeight - 1)
                {
                    temp += ".";
                }
            }
            shapeNumList += temp;
            if (i < _gridWidth - 1)
                shapeNumList += ",";
        }
        SaveGame.WriteString(shapeNumList);
        PlayerPrefs.SetInt("Score", _scoreTotal);
        if (PlayerPrefs.GetString("GameMode") == "TimeAttack")
        {
            PlayerPrefs.SetInt("Save", 1);
            PlayerPrefs.SetInt("TimeRemaining", (int)timeRemaining);
        }
        else if (PlayerPrefs.GetString("GameMode") == "Survival")
        {
            PlayerPrefs.SetInt("Save", 2);
        }
    }


    IEnumerator RunCountdown()
    {
        UpdateColliederAllTiles(false, 80);
        countdownGO.SetActive(true);
        yield return new WaitForSeconds(3.2f);
        countdownGO.SetActive(false);
        UpdateColliederAllTiles(true, 255);
        isCoundownFinish = true;
        touchToStart = true;
        SaveGame.DeleteSavedFile();

    }

    public void LoadGame(int type = 2)
    {
        // Type = 1  for tutoria;
        // type = for load saved game
        string fileString = "";
        if (type == 1)
        {
            // Resources.Load("Tutorial.txt");
            fileString = "4.3.0.3.3.2.2.3.1.3.2.3,4.1.0.3.4.3.0.3.0.4.3.0,0.2.3.0.2.3.1.2.0.1.4.1,0.0.2.0.1.4.1.1.4.2.3.4,2.1.0.4.1.4.2.2.1.3.1.3,2.1.4.2.3.1.2.0.1.1.0.0,1.3.3.1.4.2.3.0.4.4.2.1,0.3.1.4.3.0.1.1.4.3.4.0";
            //  fileString = SaveGame.ReadString(Application.persistentDataPath + "/Tutorial.txt" );

        }
        else if (type == 2)
        {

            fileString = SaveGame.ReadString(Application.persistentDataPath + "/test.txt");
        }
        string[] rowOfIndex = fileString.Split(',');

        for (int i = 0; i <= _gridWidth - 1; i++)
        {

            string[] colOfIndex = rowOfIndex[i].Split('.');
            for (int j = 0; j <= _gridHeight - 1; j++)
            {
                int ind = Convert.ToInt32(colOfIndex[j]);
                var gameObject = GameObject.Instantiate(_listOfGems[ind] as GameObject, new Vector3(i, j, 0), transform.rotation) as GameObject;
                _arrayOfShapes[i, j] = gameObject;
            }
        }
        if (type == 2)
        {
            SaveGame.DeleteSavedFile();
            StartCoroutine(RunCountdown());
        }
        //if (type == 1)
        //{
        //    SaveGame.DeleteSavedFile();
        //}
    }
    void SetEnvironemnt()
    {
        //comboStreakTimerText.enabled = false;
        timerText.enabled = false;
        goalText.enabled = false;
        // ScoreText.SetActive(false);
        divider.SetActive(false);
        //LevelText.SetActive(false);
        BackButton.SetActive(false);
        PauseButton.SetActive(false);
        pauseScoreGO.SetActive(false);
        pauseTimerGO.SetActive(false);
       //SkipButton.SetActive(true);
    }
    void UpdateColliederRange(int start, int end, int col)
    {
        for (int i = start; i <= end; i++)
        {
            GameObject go = _arrayOfShapes[col, i];
            go.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            go.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

            go.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void gemsInUse(int number, GameObject gem)
    {
        string name = PlayerPrefs.GetString("Selectedgem" + (number + 1));
        string[] n = name.Split("/");
        gem.name = n[1];
        gem.GetComponent<Tile>().GemName = n[1];
        gem.GetComponent<Tile>().GemNumber = n[2];
        gem.GetComponent<Tile>().GemType = n[0];

        //gem.GetComponent<SpriteRenderer>().sprite = null;
        if (n[1].Equals("ToothBrush"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[0];
        }
        else if (n[1].Equals("Toothpaste"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[1];
        }
        else if (n[1].Equals("Floss"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[2];
        }
        else if (n[1].Equals("MouthWash"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[3];
        }
        else if (n[1].Equals("TongueScraper"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[4];
        }
        else if (n[1].Equals("HawleyRetainer"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[5];
        }
        else if (n[1].Equals("MolarBands"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[6];
        }
        else if (n[1].Equals("WaterPick"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[7];
        }
        else if (n[1].Equals("Elastics"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[8];
        }
        else if (n[1].Equals("ToothX-Rays"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[9];
        }
        else if (n[1].Equals("Expander"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[10];
        }
        else if (n[1].Equals("PlasticRetainer"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[11];
        }
        else if (n[1].Equals("3DPrinter"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[12];
        }
        else if (n[1].Equals("WhiteningTray"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[13];
        }
        else if (n[1].Equals("3DDentalScanner"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[14];
        }
        else if (n[1].Equals("MetalBraces"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[15];
        }
        else if (n[1].Equals("Aligners"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[16];
        }
        else if (n[1].Equals("Whitening"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[17];
        }
        else if (n[1].Equals("ToothColoredBraces"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[18];
        }
        else if (n[1].Equals("LingualMetalRetainer"))
        {
            gem.GetComponent<SpriteRenderer>().sprite = gemsImages[19];
        }
    }
    public void DestroyforCommonGem()
    {

        //Debug.Log("GemName: " + Tile.tile.GemName);
        var Matches = FindMatch(_arrayOfShapes);
        int posX = 0, posY = 0;
        bool check = false;

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                if (_FirstObject == _arrayOfShapes[i, j])
                {
                    print(i + "+" + j);
                    posX = i;
                    posY = j;
                    check = true;
                    // Optionally, perform additional actions or effects here

                    // Break out of the loop since the explosion is handled
                    break;
                }
            }
        }

        if (check)
        {
            // Calculate the bounds of the explosion
            int minX = Mathf.Max(posX - 1, 0);
            int maxX = Mathf.Min(posX + 1, _gridWidth - 1);
            int minY = Mathf.Max(posY - 1, 0);
            int maxY = Mathf.Min(posY + 1, _gridHeight - 1);

            // Loop through the explosion area and destroy the objects
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    // Check if the indices are within the bounds of the grid
                    GameObject go = _arrayOfShapes[x, y].gameObject;
                    if (!Matches.Contains(go) /*&& go != _FirstObject && go != _SecondObject*/)
                    {
                        // print(x + "+" + y);
                        var destroyingParticleGrid = GameObject.Instantiate(_particleEffectWhenMatchGrid as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                        Destroy(destroyingParticleGrid, 1f);
                        _arrayOfShapes[x, y] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                        // Destroy the object at (x, y)


                        Destroy(go);
                    }
                }
            }
        }
    }

    public void DestroyforSalamandarGem()
    {

        //Debug.Log("GemName: " + Tile.tile.GemName);
        var Matches = FindMatch(_arrayOfShapes);
        int posX = 0, posY = 0;
        bool check = false;

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                if (_FirstObject == _arrayOfShapes[i, j])
                {
                    print(i + "+" + j);
                    posX = i;
                    posY = j;
                    check = true;
                    // Optionally, perform additional actions or effects here

                    // Break out of the loop since the explosion is handled
                    break;
                }
            }
        }

        if (check)
        {

            // Calculate the bounds of the explosion
            int minX = Mathf.Max(posX - 1, 0);
            int maxX = Mathf.Min(posX + 2, _gridWidth - 1);  // Increase the explosion width to 2
            int minY = Mathf.Max(posY - 1, 0);
            int maxY = Mathf.Min(posY + 2, _gridHeight - 1); // Increase the explosion height to 2



            //print(minX + "+" + minY);
            //print(maxX + "+" + maxY);
            // Loop through the explosion area and destroy the objects
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    // Check if the indices are within the bounds of the grid
                    GameObject go = _arrayOfShapes[x, y].gameObject;
                    if (!Matches.Contains(go) /*&& go != _FirstObject && go != _SecondObject*/)
                    {

                        // print(x + "+" + y);
                        var destroyingParticle = GameObject.Instantiate(_particleEffectWhenMatch as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                        Destroy(destroyingParticle, 1f);
                        _arrayOfShapes[x, y] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                        // Destroy the object at (x, y)
                        //print(go.gameObject.name);

                        Destroy(go);

                    }
                }
            }
        }

    }
    public void ClearBoardVoid()
    {
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                GameObject go = _arrayOfShapes[i, j].gameObject;
                var destroyingParticle = GameObject.Instantiate(_particleEffectWhenMatch as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                Destroy(destroyingParticle, 1f);
                _arrayOfShapes[i, j] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                // Destroy the object at (x, y)

                Destroy(go);

            }
        }
    }
    private bool isPaused = true;

    private void ChoronusGemEffectForLShape()
    {
        StartCoroutine(StartPauseTimeDuration());
    }
    private IEnumerator StartPauseTimeDuration()
    {
        isFreeze = true;

        yield return new WaitForSeconds(10f);

        isFreeze = false;
    }
    private void ChoronusGemEffectForFive()
    {
        StartCoroutine(StartPauseTimeDurationForFive());
    }
    private IEnumerator StartPauseTimeDurationForFive()
    {
        isFreeze = true;

        yield return new WaitForSeconds(25f);

        isFreeze = false;
    }


    private void TemporalGemTimeAddition()
    {
        if (isTimePaused)
        {
            return;
        }

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                timeRemaining = timeRemaining + 0.04f;


            }
        }
    }
    private void TemporalGemTimeAdditionFiveMatches()
    {
        if (isTimePaused)
        {
            return;
        }

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                timeRemaining = timeRemaining + 0.09f;


            }
        }
    }
    private void TemporalGemTimeAdditionLMatches()
    {
        if (isTimePaused)
        {
            return;
        }

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                timeRemaining = timeRemaining + 0.06f;


            }
        }
    }
    public void DestroyforCommonGemFiveMatches()
    {

        //Debug.Log("GemName: " + Tile.tile.GemName);
        var Matches = FindMatch(_arrayOfShapes);
        int posX = 0, posY = 0;
        bool check = false;

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {

                if (_FirstObject == _arrayOfShapes[i, j])
                {
                    print(i + "+" + j);
                    posX = i;
                    posY = j;
                    check = true;
                    // Optionally, perform additional actions or effects here

                    // Break out of the loop since the explosion is handled
                    break;
                }
            }
        }

        if (check)
        {
            // Loop through the vertical line of the plus shape (0 to 9 in y-axis)
            for (int y = 0; y < _gridHeight; y++)
            {
                // Check if the indices are within the bounds of the grid
                if (posX >= 0 && posX < _gridWidth && y >= 0 && y < _gridHeight)
                {
                    GameObject go = _arrayOfShapes[posX, y].gameObject;

                    if (!Matches.Contains(go) /*&& go != _FirstObject && go != _SecondObject*/)
                    {
                        // print(posX + "+" + y);
                        var destroyingParticleCross = GameObject.Instantiate(_particleEffectWhenMatchCross as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                        Destroy(destroyingParticleCross, 1f);
                        _arrayOfShapes[posX, y] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                        // Destroy the object at (posX, y)
                        print("fh" + go.gameObject.name);

                        Destroy(go);
                    }
                }
            }

            // Loop through the horizontal line of the plus shape (0 to 7 in x-axis)
            for (int x = 0; x < _gridWidth; x++)
            {
                // Check if the indices are within the bounds of the grid
                if (x >= 0 && x < _gridWidth && posY >= 0 && posY < _gridHeight)
                {
                    GameObject go = _arrayOfShapes[x, posY].gameObject;

                    if (!Matches.Contains(go) /*&& go != _FirstObject && go != _SecondObject*/)
                    {
                        // print(x + "+" + posY);
                        var destroyingParticle = GameObject.Instantiate(_particleEffectWhenMatchCross as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                        Destroy(destroyingParticle, 1f);
                        _arrayOfShapes[x, posY] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                        // Destroy the object at (x, posY)
                        print("fh" + go.gameObject.name);

                        Destroy(go);
                    }
                }
            }
        }
    }


    private void DestroyCommonGemForSpecial(string gemName)
    {
        string gemType;
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                GameObject go = _arrayOfShapes[i, j].gameObject;
                gemType = go.GetComponent<Tile>().GemType;
                if (gemType == "2ndTier" && gemName == go.GetComponent<Tile>().GemName)
                {
                    var destroyingParticleallType = GameObject.Instantiate(_particleEffectWhenMatchAllType as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
                    Destroy(destroyingParticleallType, 1f);
                    _arrayOfShapes[i, j] = GameObject.Instantiate(_emptyGameobject, new Vector3((int)go.transform.position.x, (int)go.transform.position.y, -1), transform.rotation) as GameObject;
                    // Destroy the object at (x, y)
                    //print(go.gameObject.name);

                    Destroy(go);
                }
            }
        }
    }

    private void SalamanderForFiveGems()
    {
        // Create a list to store all grid positions
        List<Vector2Int> allPositions = new List<Vector2Int>();

        // Populate the list with all grid positions
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                allPositions.Add(new Vector2Int(i, j));
            }
        }

        // Randomly shuffle the list
        allPositions = allPositions.OrderBy(pos => Random.value).ToList();

        // Set GemLit to true for the first three positions in the shuffled list
        for (int count = 0; count < 3 && count < allPositions.Count; count++)
        {


            Vector2Int randomPosition = allPositions[count];
            GameObject go = _arrayOfShapes[randomPosition.x, randomPosition.y].gameObject;
            go.GetComponent<Tile>().GemLit = true;

            var destroyingParticleLit = GameObject.Instantiate(_particleEffectWhenMatchALit as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
            destroyingParticleLit.transform.SetParent(go.transform);
            //Destroy(destroyingParticleLit, 1f);
        }
    }
    private void SalamanderForLGems()
    {
        // Create a list to store all grid positions
        List<Vector2Int> allPositions = new List<Vector2Int>();

        // Populate the list with all grid positions
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                allPositions.Add(new Vector2Int(i, j));
            }
        }

        // Randomly shuffle the list
        allPositions = allPositions.OrderBy(pos => Random.value).ToList();

        // Set GemLit to true for the first three positions in the shuffled list
        for (int count = 0; count < 10 && count < allPositions.Count; count++)
        {
            Vector2Int randomPosition = allPositions[count];
            GameObject go = _arrayOfShapes[randomPosition.x, randomPosition.y].gameObject;
            go.GetComponent<Tile>().GemLit = true;
            var destroyingParticleLit = GameObject.Instantiate(_particleEffectWhenMatchALit as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
            destroyingParticleLit.transform.SetParent(go.transform);
            //Destroy(destroyingParticleLit, 1f);

        }
    }
    public void comboStreakTenSecond()
    {
        // Enable/disable UI elements as needed
        //comboStreakTimerText.enabled = true;
        comboGameObject.SetActive(true);
        combotimeRemainingForTenSecond = initialTimeForTenSecond;

        StartCoroutine(StartComboStreakTimerTenSecond());
    }

    private IEnumerator StartComboStreakTimerTenSecond()
    {
        while (combotimeRemainingForTenSecond > 0)
        {

            combominutesForTenSecond = Mathf.FloorToInt(combotimeRemainingForTenSecond / 60);
            combosecondsForTenSeconds = Mathf.FloorToInt(combotimeRemainingForTenSecond % 60);

            //comboStreakTimerText.text = "Combo streak" + combominutes.ToString("00") + ":" + comboseconds.ToString("00");
            comboStreakTimerText.text = "Combo streak " + combominutesForTenSecond.ToString("00") + ":" + combosecondsForTenSeconds.ToString("00");

            yield return new WaitForSeconds(1f);

            combotimeRemainingForTenSecond -= 1f;
        }

        // Timer has reached 0, do any necessary actions here
        comboStreakTimerText.text = "Combo streak 00:00";
        comboGameObject.SetActive(false);
    }
    public void comboStreakFifteenSecond()
    {
        // Enable/disable UI elements as needed
        //comboStreakTimerText.enabled = true;
        comboGameObject.SetActive(true);
        combotimeRemainingForFifteenSecond = initialTimeForFifteenSecond;

        StartCoroutine(StartComboStreakTimerFifteenSecond());
    }

    private IEnumerator StartComboStreakTimerFifteenSecond()
    {
        while (combotimeRemainingForFifteenSecond > 0)
        {

            combominutesForFifteenSecond = Mathf.FloorToInt(combotimeRemainingForFifteenSecond / 60);
            combosecondsForFifteenSeconds = Mathf.FloorToInt(combotimeRemainingForFifteenSecond % 60);


            comboStreakTimerText.text = "Combo streak " + combominutesForFifteenSecond.ToString("00") + ":" + combosecondsForFifteenSeconds.ToString("00");

            yield return new WaitForSeconds(1f);

            combotimeRemainingForFifteenSecond -= 1f;
        }

        // Timer has reached 0, do any necessary actions here
        comboStreakTimerText.text = "Combo streak 00:00";
        comboGameObject.SetActive(false);
    }

    public void comboStreakFiveSecond()
    {
        // Enable/disable UI elements as needed
        //comboStreakTimerText.enabled = true;
        comboGameObject.SetActive(true);
        combotimeRemainingForFiveSecond = initialTimeForFiveSecond;

        StartCoroutine(StartComboStreakTimerFiveSecond());
    }

    private IEnumerator StartComboStreakTimerFiveSecond()
    {
        while (combotimeRemainingForFiveSecond > 0)
        {

            combominutesForFiveSecond = Mathf.FloorToInt(combotimeRemainingForFiveSecond / 60);
            combosecondsForFiveSeconds = Mathf.FloorToInt(combotimeRemainingForFiveSecond % 60);

            //comboStreakTimerText.text = "Combo streak" + combominutes.ToString("00") + ":" + comboseconds.ToString("00");
            comboStreakTimerText.text = "Combo streak " + combominutesForFiveSecond.ToString("00") + ":" + combosecondsForFiveSeconds.ToString("00");

            yield return new WaitForSeconds(1f);

            combotimeRemainingForFiveSecond -= 1f;
        }

        // Timer has reached 0, do any necessary actions here
        comboStreakTimerText.text = "Combo streak 00:00";
        comboGameObject.SetActive(false);
    }
    private void TransfigurationForFourGems()
    {
        // Create a list to store all grid positions
        List<Vector2Int> allPositions = new List<Vector2Int>();

        // Populate the list with all grid positions
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                allPositions.Add(new Vector2Int(i, j));
            }
        }

        // Randomly shuffle the list
        allPositions = allPositions.OrderBy(pos => Random.value).ToList();

        //Gem Select
        string selectedGemName = RandomizeInTheDeck();
        print("Selected Gem Name: " + selectedGemName);


        // Set GemLit to true for the first three positions in the shuffled list
        for (int count = 0; count < 3 && count < allPositions.Count; count++)
        {

            Vector2Int randomPosition = allPositions[count];
            GameObject go = _arrayOfShapes[randomPosition.x, randomPosition.y].gameObject;

            SetGemSprite(go, selectedGemName, go);


            go.GetComponent<Tile>().GemLit = true;


            var destroyingParticleLit = GameObject.Instantiate(_particleEffectWhenMatchALit as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
            Destroy(destroyingParticleLit, 10f);


        }

    }
    private void TransfigurationForFiveGems()
    {
        // Create a list to store all grid positions
        List<Vector2Int> allPositions = new List<Vector2Int>();

        // Populate the list with all grid positions
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                allPositions.Add(new Vector2Int(i, j));
            }
        }

        // Randomly shuffle the list
        allPositions = allPositions.OrderBy(pos => Random.value).ToList();

        //Gem Select
        string selectedGemName = RandomizeInTheDeck();
        print("Selected Gem Name: " + selectedGemName);


        // Set GemLit to true for the first three positions in the shuffled list
        for (int count = 0; count < 3 && count < allPositions.Count; count++)
        {

            Vector2Int randomPosition = allPositions[count];
            GameObject go = _arrayOfShapes[randomPosition.x, randomPosition.y].gameObject;

            SetGemSprite(go, selectedGemName, go);


            go.GetComponent<Tile>().GemLit = true;


            var destroyingParticleLit = GameObject.Instantiate(_particleEffectWhenMatchALit as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
            Destroy(destroyingParticleLit, 10f);


        }

    }
    private void TransfigurationForLShape()
    {
        // Create a list to store all grid positions
        List<Vector2Int> allPositions = new List<Vector2Int>();

        // Populate the list with all grid positions
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                allPositions.Add(new Vector2Int(i, j));
            }
        }

        // Randomly shuffle the list
        allPositions = allPositions.OrderBy(pos => Random.value).ToList();

        //Gem Select
        string selectedGemName = RandomizeInTheDeck();
        print("Selected Gem Name: " + selectedGemName);


        // Set GemLit to true for the first three positions in the shuffled list
        for (int count = 0; count < 8 && count < allPositions.Count; count++)
        {

            Vector2Int randomPosition = allPositions[count];
            GameObject go = _arrayOfShapes[randomPosition.x, randomPosition.y].gameObject;

            SetGemSprite(go, selectedGemName, go);


            go.GetComponent<Tile>().GemLit = true;


            var destroyingParticleLit = GameObject.Instantiate(_particleEffectWhenMatchALit as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
            Destroy(destroyingParticleLit, 10f);


        }

    }
    private void SetGemSprite(GameObject gemObject, string gemName, GameObject gem)
    {
        foreach (Sprite item in gemsImages)
        {
            if (item.name == gemName)
            {
                gemObject.GetComponent<SpriteRenderer>().sprite = item;
                gemObject.name = gemName;
                gem.GetComponent<Tile>().GemName = gemObject.GetComponent<SpriteRenderer>().sprite.name;
                if (item.name == "ToothBrush" || item.name == "Toothpaste" || item.name == "Floss" || item.name == "MouthWash" || item.name == "TongueScraper")
                {
                    if (item.name == "ToothBrush")
                    {
                        gem.GetComponent<Tile>().TileNumber = 1;
                    }
                    else if (item.name == "Toothpaste")
                    {
                        gem.GetComponent<Tile>().TileNumber = 4;
                    }
                    else if (item.name == "Floss")
                    {
                        gem.GetComponent<Tile>().TileNumber = 0;
                    }
                    else if (item.name == "MouthWash")
                    {
                        gem.GetComponent<Tile>().TileNumber = 3;
                    }
                    else if (item.name == "TongueScraper")
                    {
                        gem.GetComponent<Tile>().TileNumber = 2;
                    }
                    gem.GetComponent<Tile>().GemType = "1stTier";
                }
                else if (item.name == "HawleyRetainer" || item.name == "MolarBands" || item.name == "WaterPick" || item.name == "Elastics" || item.name == "ToothX-Rays")
                {
                    gem.GetComponent<Tile>().GemType = "2ndTier";
                }
                else if (item.name == "Expander" || item.name == "PlasticRetainer" || item.name == "3DPrinter" || item.name == "WhiteningTray" || item.name == "3DDentalScanner")
                {
                    gem.GetComponent<Tile>().GemType = "3rdTier";
                }
                else if (item.name == "MetalBraces" || item.name == "Aligners" || item.name == "Whitening" || item.name == "ToothColoredBraces" || item.name == "LingualMetalRetainer")
                {
                    gem.GetComponent<Tile>().GemType = "4thTier";
                }

            }
        }
    }
    public string RandomizeInTheDeck()
    {

        int a = Random.Range(1, 6);
        string name = PlayerPrefs.GetString("Selectedgem" + a);
        string[] n = name.Split("/");
        return n[1];

    }

    private void RandomizeAllGems()
    {
        // Create a list to store all grid positions
        List<Vector2Int> allPositions = new List<Vector2Int>();

        // Populate the list with all grid positions
        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                allPositions.Add(new Vector2Int(i, j));
            }
        }

        // Create an array to store different gem names
        string[] selectedGemNames = new string[64];

        // Gem Select for each position in the sequence
        for (int count = 0; count < 64 && count < allPositions.Count; count++)
        {
            // Get a different gem name for each iteration
            selectedGemNames[count] = RandomizeInTheDeck();
        }

        // Set GemLit to true for the first three positions in the sequential order
        for (int count = 0; count < 64 && count < allPositions.Count; count++)
        {
            Vector2Int sequentialPosition = allPositions[count];
            GameObject go = _arrayOfShapes[sequentialPosition.x, sequentialPosition.y].gameObject;

            SetGemSprite(go, selectedGemNames[count], go);

            go.GetComponent<Tile>().GemLit = true;

            var destroyingParticleLit = GameObject.Instantiate(_particleEffectWhenMatchALit as GameObject, new Vector3(go.transform.position.x, go.transform.position.y, -2), transform.rotation) as GameObject;
            Destroy(destroyingParticleLit, 10f);
        }

    }
    public void giveStats(string type, string name, int number)
    {
        string stats = PlayerPrefs.GetString(type + "/" + name + "/" + number, "");

        if (stats == "moreaura")
        {
            moreAura();
        }
        else if (stats == "AdditionalTimelimit")
        {
            AdditionalTimeLimit();
        }
        else if (stats == "Crystallization")
        {
            Crystallization();
        }
        else if (stats == "Additionalpoint")
        {
            Additionalpoint(name);
        }
        if (stats == "moreaura/AdditionalTimelimit/Crystallization")
        {
            moreAura();
            AdditionalTimeLimit();
            Crystallization();
        }
        else if (stats == "moreaura/AdditionalTimelimit/Additionalpoint")
        {
            moreAura();
            AdditionalTimeLimit();
            Additionalpoint(name);

        }
        else if (stats == "moreaura/Crystallization/Additionalpoint")
        {
            moreAura();
            Crystallization();
            Additionalpoint(name);
        }
        else if (stats == "AdditionalTimelimit/Crystallization/Additionalpoint")
        {
            AdditionalTimeLimit();
            Crystallization();
            Additionalpoint(name);
        }
    }
    private float increment;
    private float auraIncrease;
    private int percentage;
    private void moreAura()
    {
        percentage = Random.Range(1, 6);
        increment += percentage / 100;

    }
    private float additionalTime = 0;
    public void AdditionalTimeLimit()
    {
        additionalTime += Random.Range(1f, 4f);
        print(additionalTime);
    }
    private int crystallizationCount = 0;
    public void Crystallization()
    {
        crystallizationCount++;
    }
    public bool statsAdditionalpoint = false;
    public string pointGems = "";
    public void Additionalpoint(string gemName)
    {
        print(gemName);
        pointGems += gemName + "/";
        statsAdditionalpoint = true;
    }


#if UNITY_IOS || UNITY_EDITOR
    private void OnApplicationFocus(bool focus)
    {
        //OpenPausePanel();
        //print("Background app IOS : "+ focus);
        //if(focus)
        //{
        //    ClosePausePanel();
        //}
        //else
        //{

        //    OpenPausePanel();
        //}
    }
#endif
#if UNITY_ANDROID || UNITY_EDITOR
    void OnApplicationPause(bool pause)
    {
        OpenPausePanel();
        //print("Background app Android : "+ pause);
        //if(pause)
        //{
        //    ClosePausePanel();
        //}
        //else
        //{
        //    OpenPausePanel();
        //}
    }
#endif



}
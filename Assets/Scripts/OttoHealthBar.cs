using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OttoHealthBar : MonoBehaviour
{
    public GameObject Otto;
    public Image currentHappy;
    public Image currentClean;
    public Image currentHunger;

    public Text HappyText;
    public Text CleanText;
    public Text HungryText;

    private float happyness = 100;
    private float hygiene = 100;
    private float hunger = 100;
    private float max = 100;

    public Button Feed;
    public Button Clean;
    public Button Play;
    public Button Home;

    public Button Photo;
    public Button TalkToOtto;


    public GameObject GameOverPanel;
    public GameObject QuitPanel;

    private Animator ottoAnim;


    // Start is called before the first frame update
    void Start()
    {
        ottoAnim = Otto.GetComponent<Animator>();

        UpdateHappyBar();
        UpdateHungerBar();
        UpdateHygieneBar();

        Update();
    }

    // Update is called once per frame
    void Update()
    {
        //This deplishes happiness over time
        happyness -= 0.15f * Time.deltaTime;
        if(happyness < 0){
        	happyness = 0;
        }

        //This deplishes hunger over time
        hunger -= 0.2f * Time.deltaTime;
        if(hunger < 0){
        	hunger = 0;
        }

        //This deplishes hygiene over time
        hygiene -= 0.1f * Time.deltaTime;
        if(hygiene < 0){
        	hygiene = 0;
        }

        UpdateHappyBar();
        UpdateHungerBar();
        UpdateHygieneBar();

        GameOver();
    }

    private void UpdateHungerBar(){
    	float ratio = hunger / max;
    	currentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
    	HungryText.text = (ratio * 100).ToString("0") + "%";
    }

    private void UpdateHappyBar(){
    	float ratio = happyness / max;
    	currentHappy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    	HappyText.text = (ratio * 100).ToString("0") + "%";
    }

    private void UpdateHygieneBar(){
    	float ratio = hygiene / max;
    	currentClean.rectTransform.localScale = new Vector3(ratio, 1, 1);
    	CleanText.text = (ratio * 100).ToString("0") + "%";
    }

    public void FeedThePet(){
        hunger += 10;
    	if (hunger > max){
    		hunger = max;
    	}

    	UpdateHungerBar();
    }
 

    public void PlayWithThePet(){
        happyness += 20;     
    	if (happyness > max){
    		happyness = max;
    	}
    	UpdateHappyBar();
    	
    }

    public void CleanThePet(){
        hygiene += (max - hygiene);
    	if (hygiene > max){
    		hygiene = max;
    	}
    	UpdateHygieneBar();
    	
    }

    void GameOver(){
        if (happyness == 0){
            if (hygiene == 0){
                if (hunger == 0){
                    Feed.gameObject.SetActive(false);
                    Clean.gameObject.SetActive(false);
                    Play.gameObject.SetActive(false);
                    Home.gameObject.SetActive(false);
                    TalkToOtto.gameObject.SetActive(false);
                    Photo.gameObject.SetActive(false);
                    GameOverPanel.gameObject.SetActive(true);
                    Otto.gameObject.SetActive(false);
                }
            }
        }
    }

    public void starHappy(){
    	ottoAnim.SetTrigger("IsHappy");
    }

    public void startPlay(){
    	ottoAnim.Play("BlowKiss");
    }

    public void startDance(){
    	ottoAnim.SetBool("IsDancing",true);
    }

    public void PlayAgain(string scene){
        SceneManager.LoadScene(scene);
    }

    public void ShowQuitPanel(){
        QuitPanel.gameObject.SetActive(true);
        Otto.gameObject.SetActive(false);
    }

    public void HideQuitPanel(){
        QuitPanel.gameObject.SetActive(false);
        Otto.gameObject.SetActive(true);
    }
}

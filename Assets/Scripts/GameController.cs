using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    public Animator CrossFade;

    public void quit(){
    	Application.Quit();
    }

    public void changeScene(string scene){
        StartCoroutine(LoadSceneWithAnim());
        SceneManager.LoadScene(scene);
    }

    IEnumerator LoadSceneWithAnim()
    {
        if (CrossFade != null)
        {
            CrossFade.SetTrigger("Start");

            yield return new WaitForSeconds(1.5f);
        }
    }

    public void RateApp()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.zentanamusicltd.zenlandar");
    }

    public void loadYoutubeScenes(int count)
    {
        PlayerPrefs.SetInt("link", count);
        SceneManager.LoadScene("1.MantraYouTube");
    }
    public void QuitGame()
    {


        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        if (Main.instance.GameStart == true)
        {
            string fileData = SaveGame.ReadString(Application.persistentDataPath + "/test.txt");
            if (fileData == null)
            {
                Main.instance.SaveMyGame();
            }
            else if (fileData != null)
            {
                SaveGame.DeleteSavedFile();
                Main.instance.SaveMyGame();
            }
            //Main.instance.SaveMyGame();
        }
        else
        {
            PlayerPrefs.SetInt("Save", 0);
        }

        StartCoroutine(loadMenuScene());
      
    }

    IEnumerator loadMenuScene()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(0);

    }


    public void SkipTutorial()
    {
        SoundManager.instance.Play_BUTTON_CLICK_Sound();
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(0);
    }
}

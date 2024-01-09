using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRandomAClip : MonoBehaviour
{
	private AudioSource a_source;
    public AudioClip[] a_clips;

    public GameObject playButton;
    public GameObject Aura1;
    public GameObject Aura2;
    public GameObject CountdownPanel;

    [SerializeField] float startTime = 86400f;
    [SerializeField] Text timerText;

    float timer = 0f;

    void Start(){
    	a_source = gameObject.AddComponent<AudioSource>();
    }

   public void playRandom()
     {
         int clipPick = Random.Range(0, a_clips.Length);
         GetComponent<AudioSource>().clip = a_clips[clipPick];
         GetComponent<AudioSource>().Play();

         playButton.gameObject.SetActive(false);
         Aura1.gameObject.SetActive(false);
         Aura2.gameObject.SetActive(false);

         // Invoke("showCountdownPanel", 5);
         // StartCoroutine(Timer());
         // Invoke("activatePlayButton", 86400);
         Invoke("activatePlayButton", 6);
     }

     private void showCountdownPanel(){
     	CountdownPanel.gameObject.SetActive(true);
     }

     public void activatePlayButton(){
     	 playButton.gameObject.SetActive(true);
         Aura1.gameObject.SetActive(true);
         Aura2.gameObject.SetActive(true);
         CountdownPanel.gameObject.SetActive(false);
     }


    private IEnumerator Timer(){
    	timer = startTime;

    	do {
    		timer -= Time.deltaTime;
    		FormatText();
    		yield return null;
    	}
    	while (timer > 0);
    }

    private void FormatText(){
    	int hours = (int)(timer / 3600) % 24;
    	int minutes = (int)(timer / 60) % 60;
    	int seconds = (int)(timer % 60);

    	timerText.text = "";
    	if (hours > 0){timerText.text += hours + "h ";}
    	if (minutes > 0){timerText.text += minutes + "m ";}
    	if (seconds > 0){timerText.text += seconds + "s ";}
    }


}

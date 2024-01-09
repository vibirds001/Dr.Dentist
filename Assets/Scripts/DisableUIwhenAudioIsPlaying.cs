using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableUIwhenAudioIsPlaying : MonoBehaviour
{
	private AudioSource a_source;
	private AudioClip a_clip;
	public Button Mantra1;
	public Button Mantra2;
	public Button Mantra3;
	public Button Mantra4;
	public Button Mantra5;

    // Start is called before the first frame update
    void Start()
    {
        a_source = GetComponent<AudioSource>();
    }

    public void DeactivateAllButtons(){

    		    Mantra1.interactable = false;    	
				Mantra2.interactable = false;    	
				Mantra3.interactable = false;    	
				Mantra4.interactable = false;    	
				Mantra5.interactable = false;

				Invoke("ActivateAllButtons", 5);		   	
    }

    void ActivateAllButtons(){
        		Mantra1.interactable = true;    	
				Mantra2.interactable = true;    	
				Mantra3.interactable = true;    	
				Mantra4.interactable = true;    	
				Mantra5.interactable = true;  
    }

    public void stopAudio(){
        a_source.Stop();
    }
}

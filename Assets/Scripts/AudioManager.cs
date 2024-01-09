using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void stopAudio(){
    	audioSource.Stop();
    }

    public void playAudio(){
    	audioSource.Play();
    }
}

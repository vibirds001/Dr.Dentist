using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OttoRandomTalk : MonoBehaviour
{
	 public AudioClip[] audioClips;
     public AudioSource audioSource;
     public AudioListener audioListener;
 
     // Start is called before the first frame update
     void Start()
     {
         audioListener = GetComponent<AudioListener>();
         audioSource = gameObject.GetComponent<AudioSource>();
         PlayRandom();
     }

     void PlayRandom()
     {
         audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
         audioSource.Play();
     }
}

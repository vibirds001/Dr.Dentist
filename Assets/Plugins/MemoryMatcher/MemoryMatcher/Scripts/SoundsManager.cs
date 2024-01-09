using UnityEngine;
using System.Collections;

// Sounds Manager Class for the Game Logic object
public class SoundsManager : MonoBehaviour 
{



	public AudioClip CardMatchSound;
	public AudioClip CardBadMatchSound;
	public AudioClip GameOver;

	AudioSource audioSource; 


	Hashtable sounds;

	void Awake()
	{
		sounds = new Hashtable();
		sounds.Add("CardmatchGood", CardMatchSound);
		sounds.Add("CardmatchBad", CardBadMatchSound);
		sounds.Add("GameOver", GameOver);

		audioSource = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void PlaySound(string which)
	{
		if( sounds.ContainsKey( which) && audioSource != null)
		{
			audioSource.clip = sounds[which] as AudioClip;
			audioSource.Play();
		}
	}
}

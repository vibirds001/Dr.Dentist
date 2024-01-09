using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioArray : MonoBehaviour
{

	private AudioSource a_source;
	public AudioClip[] a_clip;

    // Start is called before the first frame update
    void Start()
    {
        a_source = GetComponent<AudioSource>();
    }

    
}

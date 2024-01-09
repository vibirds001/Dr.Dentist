using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{

	private Animator anim;
	private AudioSource a_source;
	public GameObject ottoTalkIntro;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        a_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        talkingAnimation();
    }

    public void talkingAnimation(){
    	if(!a_source.isPlaying){
        	anim.SetBool("isTalking", false);
        }
        else {
        	anim.SetBool("isTalking", true);
        }
    }

    public void stopAudio(){
        a_source.Stop();
    }
}

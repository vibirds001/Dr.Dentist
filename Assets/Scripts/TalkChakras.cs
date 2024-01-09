using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkChakras : MonoBehaviour
{
	
	[SerializeField]
	private AudioClip chakra1, chakra2, chakra3, chakra4, chakra5, chakra6, chakra7;
	private AudioSource a_source;
	private Animator anim;
	public GameObject ottoTalkChakras;

    // Start is called before the first frame update
    void Start()
    {
        anim = ottoTalkChakras.GetComponent<Animator>();
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

    public void PlayChakra1(){
    	a_source.PlayOneShot(chakra1);
    }

    public void PlayChakra2(){
    	a_source.PlayOneShot(chakra2);
    }

    public void PlayChakra3(){
    	a_source.PlayOneShot(chakra3);
    }

    public void PlayChakra4(){
    	a_source.PlayOneShot(chakra4);
    }

    public void PlayChakra5(){
    	a_source.PlayOneShot(chakra5);
    }

    public void PlayChakra6(){
    	a_source.PlayOneShot(chakra6);
    }

    public void PlayChakra7(){
        a_source.PlayOneShot(chakra7);
    }

    public void stopAudio(){
    	a_source.Stop();
    }
}

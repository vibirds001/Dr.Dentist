using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
	Animator anim;
    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
    }

    public void showMainMenu(){
    	anim.Play("Open");
    }

    public void hideMainMenu(){
    	anim.Play("Closed");
    }
}

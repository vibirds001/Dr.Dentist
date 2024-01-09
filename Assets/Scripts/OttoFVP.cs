using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttoFVP : MonoBehaviour
{
    public GameObject OttoOverTheRocks;
    public GameObject OttoAtZentree;
    public GameObject OttoPagoda000;
    public GameObject OttoPagoda001;
    public GameObject OttoBuddha01;
    public GameObject OttoBuddha02;

    public void ActivateOttoOverTheRocks(){
    	OttoOverTheRocks.SetActive(true);
    	OttoBuddha02.SetActive(false);
    	Invoke("ActivateOttoAtZentree", 6);
    }

    private void ActivateOttoAtZentree(){
    	OttoAtZentree.SetActive(true);
    	OttoOverTheRocks.SetActive(false);
    	Invoke("ActivateOttoPagoda000", 6);
    }

    private void ActivateOttoPagoda000(){
    	OttoPagoda000.SetActive(true);
    	OttoAtZentree.SetActive(false);
    	Invoke("ActivateOttoPagoda001", 6);
	}

    private void ActivateOttoPagoda001(){
    	OttoPagoda001.SetActive(true);
    	OttoPagoda000.SetActive(false);
    	Invoke("ActivateOttoBuddha01", 6);
    }

    private void ActivateOttoBuddha01(){
    	OttoBuddha01.SetActive(true);
    	OttoPagoda001.SetActive(false);
    	Invoke("ActivateOttoBuddha02", 6);
    }

    private void ActivateOttoBuddha02(){
    	OttoBuddha02.SetActive(true);
    	OttoBuddha01.SetActive(false);
    	Invoke("ActivateOttoOverTheRocks", 6);
    }

}

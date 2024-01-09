using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnableDisable : MonoBehaviour
{
	//public GameObject BlueGlasses;
	public static bool disabled = false;

    public void toggleOnOff(GameObject gameObject){
    	if(disabled){
    		gameObject.SetActive(!gameObject.activeInHierarchy);
    	} else {
    		gameObject.SetActive(true);
    	}
    }
}

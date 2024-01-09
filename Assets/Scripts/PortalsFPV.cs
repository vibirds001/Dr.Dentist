using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PortalsFPV : MonoBehaviour
{
	public GameObject QuestionPanel;

    public void OnMouseDown(){
    	QuestionPanel.SetActive(true);
    }
}

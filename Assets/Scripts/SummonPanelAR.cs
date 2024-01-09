using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPanelAR : MonoBehaviour
{
    public GameObject SummonPanel;

    public void closeSummonPanel(){
    	SummonPanel.gameObject.SetActive(false);
    }
}

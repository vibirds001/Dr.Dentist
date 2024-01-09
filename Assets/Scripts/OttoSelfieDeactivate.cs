using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttoSelfieDeactivate : MonoBehaviour
{
    public GameObject Otto_BlowKiss;
    public GameObject Otto_Dancing;
    public GameObject Otto_Floating;

    public void DeactivateOttoSelfie()
    {
    	Otto_Floating.SetActive(false);
    	Otto_Dancing.SetActive(false);
    	Otto_BlowKiss.SetActive(false);
    }
}

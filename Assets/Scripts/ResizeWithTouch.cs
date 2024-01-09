using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWithTouch : MonoBehaviour
{
    float initialFingersDistance;
	Vector3 initialScale ;
 
	void Update(){
    int fingersOnScreen = 0;
 
        //You need two fingers on screen to pinch.
        if(fingersOnScreen == 2){
 
            //First set the initial distance between fingers so you can compare.
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
                initialFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                initialScale = transform.localScale;
            }
            else{
                float currentFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
         
               float scaleFactor  = currentFingersDistance / initialFingersDistance;
         
                transform.localScale = initialScale * scaleFactor;
            }
        }
    }
}

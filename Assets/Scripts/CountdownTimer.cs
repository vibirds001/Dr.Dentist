﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float startTime = 0f;
    [SerializeField] Text timerText;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer(){
    	timer = startTime;

    	do {
    		timer -= Time.deltaTime;
    		FormatText();
    		yield return null;
    	}
    	while (timer > 0);
    }

    private void FormatText(){
    	int hours = (int)(timer / 3600) % 24;
    	int minutes = (int)(timer / 60) % 60;
    	int seconds = (int)(timer % 60);

    	timerText.text = "";
    	if (hours > 0){timerText.text += hours + "h ";}
    	if (minutes > 0){timerText.text += minutes + "m ";}
    	if (seconds > 0){timerText.text += seconds + "s ";}
    }

}

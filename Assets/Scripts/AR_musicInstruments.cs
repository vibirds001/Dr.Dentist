using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_musicInstruments : MonoBehaviour
{
    public GameObject Glasses;
	public GameObject Microphone;
	public GameObject Headphones;
	public GameObject Keyboard;
	public GameObject DrumKit;

	public void ActivateGlasses(){
		GameObject tempGlasses = Instantiate(Glasses, transform);
		tempGlasses.transform.position = new Vector3(0, 0, 0);
		tempGlasses.transform.parent = null;
		
		tempGlasses.SetActive(true);

		Invoke("DeactivateGlasses", 5); 
	}

	private void DeactivateGlasses(){
     	Glasses.SetActive(false);
     }

    public void ActivateMicrophone(){
		GameObject tempMic = Instantiate(Microphone, transform);
		tempMic.transform.position = new Vector3(0, 0, 0);
		tempMic.transform.parent = null;
		
		tempMic.SetActive(true);

		Invoke("DeactivateMicrophone", 5); 
	}

	private void DeactivateMicrophone(){
     	Microphone.SetActive(false);
     }

    public void ActivateHeadphones(){
		GameObject tempHeadphones = Instantiate(Headphones, transform);
		tempHeadphones.transform.position = new Vector3(0, 0, 0);
		tempHeadphones.transform.parent = null;
		
		tempHeadphones.SetActive(true);

		Invoke("DeactivateHeadphones", 5); 
	}

	private void DeactivateHeadphones(){
     	Headphones.SetActive(false);
     }

    public void ActivateKeyboard(){
		GameObject tempKeyboard = Instantiate(Keyboard, transform);
		tempKeyboard.transform.position = new Vector3(0, 0, 0);
		tempKeyboard.transform.parent = null;
		
		tempKeyboard.SetActive(true);

		Invoke("DeactivateKeyboard", 5); 
	}

	private void DeactivateKeyboard(){
     	Keyboard.SetActive(false);
     }

    public void ActivateDrumKit(){
		GameObject tempDrumKit = Instantiate(DrumKit, transform);
		tempDrumKit.transform.position = new Vector3(0, 0, 0);
		tempDrumKit.transform.parent = null;
		
		tempDrumKit.SetActive(true);

		Invoke("stopParticles5", 5); 
	}

	private void DeactivateDrumKit(){
     	DrumKit.SetActive(false);
     }
}

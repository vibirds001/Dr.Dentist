using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChakraPanel : MonoBehaviour
{
	public GameObject rootChakraPanel;
	public GameObject sacralChakraPanel;
	public GameObject solarChakraPanel;
	public GameObject heartChakraPanel;
	public GameObject throatChakraPanel;
	public GameObject thirdeyeChakraPanel;
	public GameObject crownChakraPanel;

    public GameObject magicRootChakra;
    public GameObject magicSacralChakra;
    public GameObject magicSolarPlexusChakra;
    public GameObject magicHeartChakra;
    public GameObject magicThroatChakra;
    public GameObject magicThirdEyeChakra;
    public GameObject magicCrownChakra;

	public GameObject otto_Panel;
	public GameObject otto_Static;
	public GameObject icons;
	public GameObject backButton;
	public GameObject heading;
    public GameObject chakraTestButtonLocked;
    public GameObject chakraTestButtonUnlocked;

    public GameObject auraEffectScenario;

    public void closeRootChakraPanel(){
    	rootChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicRootChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }

    public void closeSacralChakraPanel(){
    	sacralChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicSacralChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }

    public void closeSolarChakraPanel(){
    	solarChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicSolarPlexusChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }

    public void closeHeartChakraPanel(){
    	heartChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicHeartChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }

    public void closeThroatChakraPanel(){
    	throatChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicThroatChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }

    public void closeThirdEyeChakraPanel(){
    	thirdeyeChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicThirdEyeChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }

    public void closeCrownChakraPanel(){
    	crownChakraPanel.SetActive(false);
    	icons.SetActive(true);
    	heading.SetActive(true);
        backButton.SetActive(true);
        otto_Panel.SetActive(false);
        otto_Static.SetActive(true);
        otto_Static.GetComponent<AudioSource>().Stop();
        magicCrownChakra.SetActive(false);
        auraEffectScenario.SetActive(true);
        chakraTestButtonLocked.SetActive(true);
        chakraTestButtonUnlocked.SetActive(true);
    }
}

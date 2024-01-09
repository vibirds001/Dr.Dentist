using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChakraScreenManager : MonoBehaviour
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


    public void openRootChakraPanel(){
    	rootChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicRootChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

    public void openSacralChakraPanel(){
    	sacralChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicSacralChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

    public void openSolarChakraPanel(){
    	solarChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicSolarPlexusChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

    public void openHeartChakraPanel(){
    	heartChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicHeartChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

    public void openThroatChakraPanel(){
    	throatChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicThroatChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

    public void openThirdEyeChakraPanel(){
    	thirdeyeChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicThirdEyeChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

    public void openCrownChakraPanel(){
    	crownChakraPanel.SetActive(true);
    	icons.SetActive(false);
    	heading.SetActive(false);
        backButton.SetActive(false);
        otto_Panel.SetActive(true);
        otto_Static.SetActive(false);
        magicCrownChakra.SetActive(true);
        auraEffectScenario.SetActive(false);
        chakraTestButtonLocked.SetActive(false);
        chakraTestButtonUnlocked.SetActive(false);
    }

}

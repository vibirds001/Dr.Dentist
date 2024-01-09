using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableARbuttons : MonoBehaviour
{
	private AudioSource a_source;
	private AudioClip a_clip;

	public Button OttoSays1;
	public Button OttoSays2;
	public Button OttoSays3;
	public Button OttoSays4;
	public Button OttoSays5;
	public Button OttoSays6;
	public Button OttoSays7;
	public Button OttoSays8;
	public Button OttoSays9;
	public Button OttoSays10;

	public Button OttoLove1;
	public Button OttoLove2;
	public Button OttoLove3;
	public Button OttoLove4;
	public Button OttoLove5;
	public Button OttoLove6;
	public Button OttoLove7;
	public Button OttoLove8;
	public Button OttoLove9;
	public Button OttoLove10;

	public Button OttoHero1;
	public Button OttoHero2;
	public Button OttoHero3;
	public Button OttoHero4;
	public Button OttoHero5;
	public Button OttoHero6;
	public Button OttoHero7;
	public Button OttoHero8;
	public Button OttoHero9;
	public Button OttoHero10;

	public Button OttoZen1;
	public Button OttoZen2;
	public Button OttoZen3;
	public Button OttoZen4;
	public Button OttoZen5;
	public Button OttoZen6;
	public Button OttoZen7;
	public Button OttoZen8;
	public Button OttoZen9;
	public Button OttoZen10;

	public Button BlowKissEffect1;
	public Button BlowKissEffect2;
	public Button BlowKissEffect3;
	public Button BlowKissEffect4;
	public Button BlowKissEffect5;
	public Button BlowKissEffect6;
	public Button BlowKissEffect7;
	public Button BlowKissEffect8;
	public Button BlowKissEffect9;
	public Button BlowKissEffect10;

	public Button Accessories1;
	public Button Accessories2;
	public Button Accessories3;
	public Button Accessories4;
	public Button Accessories5;
	public Button Accessories6;
	public Button Accessories7;
	public Button Accessories8;
	public Button Accessories9;
	public Button Accessories10;

	public Button Action1;
	public Button Action2;
	public Button Action3;
	public Button Action4;
	public Button Action5;
	public Button Action6;
	public Button Action7;
	public Button Action8;
	public Button Action9;
	public Button Action10;

	public Button Music1;
	public Button Music2;
	public Button Music3;
	public Button Music4;
	public Button Music5;

	// Start is called before the first frame update
	void Start()
	{
		a_source = GetComponent<AudioSource>();
	}

	public void DeactivateOttoSaysButtons()
	{
		OttoSays1.interactable = false;
		OttoSays2.interactable = false;
		OttoSays3.interactable = false;
		OttoSays4.interactable = false;
		OttoSays5.interactable = false;
		OttoSays6.interactable = false;
		OttoSays7.interactable = false;
		OttoSays8.interactable = false;
		OttoSays9.interactable = false;
		OttoSays10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateOttoSaysButtons", 5);
		}
	}

	void ActivateOttoSaysButtons()
	{
		OttoSays1.interactable = true;
		OttoSays2.interactable = true;
		OttoSays3.interactable = true;
		OttoSays4.interactable = true;
		OttoSays5.interactable = true;
		OttoSays6.interactable = true;
		OttoSays7.interactable = true;
		OttoSays8.interactable = true;
		OttoSays9.interactable = true;
		OttoSays10.interactable = true;
	}

	public void DeactivateOttoLoveButtons()
	{
		OttoLove1.interactable = false;
		OttoLove2.interactable = false;
		OttoLove3.interactable = false;
		OttoLove4.interactable = false;
		OttoLove5.interactable = false;
		OttoLove6.interactable = false;
		OttoLove7.interactable = false;
		OttoLove8.interactable = false;
		OttoLove9.interactable = false;
		OttoLove10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateOttoLoveButtons", 5);
		}
	}

	void ActivateOttoLoveButtons()
	{
		OttoLove1.interactable = true;
		OttoLove2.interactable = true;
		OttoLove3.interactable = true;
		OttoLove4.interactable = true;
		OttoLove5.interactable = true;
		OttoLove6.interactable = true;
		OttoLove7.interactable = true;
		OttoLove8.interactable = true;
		OttoLove9.interactable = true;
		OttoLove10.interactable = true;
	}

	public void DeactivateOttoHeroButtons()
	{
		OttoHero1.interactable = false;
		OttoHero2.interactable = false;
		OttoHero3.interactable = false;
		OttoHero4.interactable = false;
		OttoHero5.interactable = false;
		OttoHero6.interactable = false;
		OttoHero7.interactable = false;
		OttoHero8.interactable = false;
		OttoHero9.interactable = false;
		OttoHero10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateOttoHeroButtons", 4);
		}
	}

	void ActivateOttoHeroButtons()
	{
		OttoHero1.interactable = true;
		OttoHero2.interactable = true;
		OttoHero3.interactable = true;
		OttoHero4.interactable = true;
		OttoHero5.interactable = true;
		OttoHero6.interactable = true;
		OttoHero7.interactable = true;
		OttoHero8.interactable = true;
		OttoHero9.interactable = true;
		OttoHero10.interactable = true;
	}

	public void DeactivateOttoZenButtons()
	{
		OttoZen1.interactable = false;
		OttoZen2.interactable = false;
		OttoZen3.interactable = false;
		OttoZen4.interactable = false;
		OttoZen5.interactable = false;
		OttoZen6.interactable = false;
		OttoZen7.interactable = false;
		OttoZen8.interactable = false;
		OttoZen9.interactable = false;
		OttoZen10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateOttoZenButtons", 4);
		}
	}

	void ActivateOttoZenButtons()
	{
		OttoZen1.interactable = true;
		OttoZen2.interactable = true;
		OttoZen3.interactable = true;
		OttoZen4.interactable = true;
		OttoZen5.interactable = true;
		OttoZen6.interactable = true;
		OttoZen7.interactable = true;
		OttoZen8.interactable = true;
		OttoZen9.interactable = true;
		OttoZen10.interactable = true;
	}

	public void DeactivateLoveEffectsButtons()
	{
		BlowKissEffect1.interactable = false;
		BlowKissEffect2.interactable = false;
		BlowKissEffect3.interactable = false;
		BlowKissEffect4.interactable = false;
		BlowKissEffect5.interactable = false;
		BlowKissEffect6.interactable = false;
		BlowKissEffect7.interactable = false;
		BlowKissEffect8.interactable = false;
		BlowKissEffect9.interactable = false;
		BlowKissEffect10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateLoveEffectsButtons", 2);
		}
	}

	void ActivateLoveEffectsButtons()
	{
		BlowKissEffect1.interactable = true;
		BlowKissEffect2.interactable = true;
		BlowKissEffect3.interactable = true;
		BlowKissEffect4.interactable = true;
		BlowKissEffect5.interactable = true;
		BlowKissEffect6.interactable = true;
		BlowKissEffect7.interactable = true;
		BlowKissEffect8.interactable = true;
		BlowKissEffect9.interactable = true;
		BlowKissEffect10.interactable = true;
	}

	public void DeactivateAccessoriesButtons()
	{
		Accessories1.interactable = false;
		Accessories2.interactable = false;
		Accessories3.interactable = false;
		Accessories4.interactable = false;
		Accessories5.interactable = false;
		Accessories6.interactable = false;
		Accessories7.interactable = false;
		Accessories8.interactable = false;
		Accessories9.interactable = false;
		Accessories10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateAccessoriesButtons", 5);
		}
	}

	void ActivateAccessoriesButtons()
	{
		Accessories1.interactable = true;
		Accessories2.interactable = true;
		Accessories3.interactable = true;
		Accessories4.interactable = true;
		Accessories5.interactable = true;
		Accessories6.interactable = true;
		Accessories7.interactable = true;
		Accessories8.interactable = true;
		Accessories9.interactable = true;
		Accessories10.interactable = true;
	}

	public void DeactivateActionsButtons()
	{
		Action1.interactable = false;
		Action2.interactable = false;
		Action3.interactable = false;
		Action4.interactable = false;
		Action5.interactable = false;
		Action6.interactable = false;
		Action7.interactable = false;
		Action8.interactable = false;
		Action9.interactable = false;
		Action10.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateActionsButtons", 5);
		}
	}

	void ActivateActionsButtons()
	{
		Action1.interactable = true;
		Action2.interactable = true;
		Action3.interactable = true;
		Action4.interactable = true;
		Action5.interactable = true;
		Action6.interactable = true;
		Action7.interactable = true;
		Action8.interactable = true;
		Action9.interactable = true;
		Action10.interactable = true;
	}

	public void DeactivateMusicButtons()
	{
		Music1.interactable = false;
		Music2.interactable = false;
		Music3.interactable = false;
		Music4.interactable = false;
		Music5.interactable = false;
		if (PlayerPrefs.GetInt("MoneyAmount", 0) > 10)
		{
			Invoke("ActivateMusicButtons", 7);
		}
	}

	void ActivateMusicButtons()
	{
		Music1.interactable = true;
		Music2.interactable = true;
		Music3.interactable = true;
		Music4.interactable = true;
		Music5.interactable = true;
	}
}
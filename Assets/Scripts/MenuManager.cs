using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public SwitchMenu CurrentMenu;

	public void Start(){
		ShowMenu(CurrentMenu);
	}

	public void ShowMenu(SwitchMenu menu){
		if (CurrentMenu != null)
			CurrentMenu.IsOpen = false;

		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	}
}

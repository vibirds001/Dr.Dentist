using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finishpoints : MonoBehaviour {

	private int idLevel;
	public Text infoStar;
	public Text infoLevel;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	private int Finnish;
	private int correct;

	public FinishSound sd;
	public GameSound gm;

	// Use this for initialization
	void Start () {

		idLevel = PlayerPrefs.GetInt("idLevel");

		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);


		Finnish = PlayerPrefs.GetInt("FinishTemp"+idLevel.ToString());
		correct = PlayerPrefs.GetInt("correctTemp"+idLevel.ToString());

		infoStar.text = Finnish.ToString();
		// infoLevel.text = "Total number of Yeses " + correct.ToString ();

		if (Finnish == 100) 
		{
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
			infoLevel.text = "You are connected to the chakra center!";

		}

		else if (Finnish >= 70) 
		{
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (false);
			infoLevel.text = "You have a good understanding of this chakra power!";

		}

		else if (Finnish >= 50) 
		{
			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);
			infoLevel.text = "You have the possibility to use this center but you do not completely understand its function!";

		}

		else if (Finnish == 0) 
		{
			star1.SetActive (false);
			star2.SetActive (false);
			star3.SetActive (false);
			infoLevel.text = "You have little understanding of this chakra’s full potential!";

		}
	
	}
	public void Replay()
	{
		Application.LoadLevel ("L" + idLevel.ToString ());
		sd.FiniSound.Stop ();
	}


	public void Menu(){
		Application.LoadLevel("Menu");
		sd.FiniSound.Stop ();
	}

	public void Level(){
		Application.LoadLevel("LevelTable");
		sd.FiniSound.Stop ();
	}
}

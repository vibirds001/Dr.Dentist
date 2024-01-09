using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTable : MonoBehaviour {

	public Button Play;
	public Text txtselectLevel;
	public GameObject infoLevel;
	public Text txtinfoLevel;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public string[] Level;
	public int numberQuestions;
	private int idLevel;
	private int Finnish;
	private int correct;



	// Use this for initialization
	void Start () {
		
		idLevel = 0;
		txtselectLevel.text = Level [idLevel];
		txtinfoLevel.text = "Correct answers X of X questions";
		infoLevel.SetActive (false);
		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);
		Play.interactable = false;


		Finnish = PlayerPrefs.GetInt("FinishTemp"+idLevel.ToString());
		correct = PlayerPrefs.GetInt("correctTemp"+idLevel.ToString());

		// infoLevel.text = "Total number of Yeses " + correct.ToString ();
	}


	public void SelectLevel(int i){
		
		idLevel = i;
		PlayerPrefs.SetInt ("idLevel", idLevel);
		txtselectLevel.text = Level[idLevel];

		int Finish = PlayerPrefs.GetInt ("FinishTemp"+idLevel.ToString ());
		int corrects = PlayerPrefs.GetInt ("correctTemp"+idLevel.ToString ());

		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);


		if (Finnish == 100) 
		{
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
			txtinfoLevel.text = "You are connected to the chakra center!";

		}

		else if (Finnish >= 70) 
		{
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (false);
			txtinfoLevel.text = "You have a good understanding of this chakra power!";

		}

		else if (Finnish >= 50) 
		{
			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);
			txtinfoLevel.text = "You have the possibility to use this center but you do not completely understand its function!";

		}

		else if (Finnish == 0) 
		{
			star1.SetActive (false);
			star2.SetActive (false);
			star3.SetActive (false);
			txtinfoLevel.text = "You have little understanding of this chakra’s full potential!";

		}


		txtinfoLevel.text = "You have little understanding of this chakra’s full potential!";
		infoLevel.SetActive (true);
		Play.interactable = true;
	}

	public void Levels(){
		
		Application.LoadLevel ("L"+idLevel.ToString());
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlaySceneLogic : MonoBehaviour 
{

	public GameObject PlayingCardPrefab;	// Hookup in the editor! Card prefab
	public Transform CardContainer;			// Holder for the cards;

	public Transform MainMenu;				// Main game menu.
	public Transform GameOverPanel;			// Game Over view

	public GameObject buttonRestart;        // Restart button;
	public GameObject[] texts;

	public float FlipDelay = 0.5f;			// Time to wait before flipping cards back over that don't match

	public Text TimerText;
	public Text AttemptsText;

	// Hooked up in the game over panel; normally
	// this would get handled in the panel itself
	public Text GameOverTimerText;
	public Text GameOverAttemptsText;

	public LevelDifficulty[] difficultyLevels;

	PlayingCard currentCard;
	PlayingCard secondCard;

	bool selectedLocked = false;
	IEnumerator currentCardOperation; // Handle to card operations

	SpriteCollection spriteCollection;

	int attempts = 0;
	float startTime;

	bool gameRunning = false;


	// Use this for initialization
	void Start () 
	{
		spriteCollection = GetComponent<SpriteCollection>();


		PlayAgain(); // Restarts the game loop

	}

	Sprite[] getShuffledValues(int cardcount)
	{
		
		Sprite[] sprites = spriteCollection.GetRandomSprites( cardcount / 2);
		if(sprites == null) return null;

		Sprite[] outvalues = new Sprite[cardcount];
		for(int cnt = 0; cnt < cardcount; cnt += 2)
		{
			outvalues[cnt] = sprites[cnt/2];
			outvalues[cnt + 1] = sprites[cnt/2];
		}
			

		// Fisher-Yates Shuffle
		System.Random r = new System.Random();
		for(int n = cardcount-1; n > 0; --n)
		{
			int k = r.Next(n+1);
			Sprite tempSpr = outvalues[n];
			outvalues[n] = outvalues[k];
			outvalues[k] = tempSpr;
		}

		return outvalues;

	}

	// void ShowAd(){
	// 	GameObject.FindObjectOfType<EasyAds> ().ShowInterstitialAd ();
	// }

	// called by Play Again button on the game over panel
	// also called at game start - basically sets the game
	// in a "start" state
	public void PlayAgain()
	{
		// ShowAd();

		gameRunning = false;
		while( CardContainer.childCount > 0 )
		{
			Transform child = CardContainer.GetChild( 0 );
			child.SetParent( null );
			Destroy( child.gameObject );
		}

		GameOverPanel.gameObject.SetActive(false);
		MainMenu.gameObject.SetActive(true);
		buttonRestart.gameObject.SetActive(false);
		texts[0].SetActive(false);
		texts[1].SetActive(false);

		// Reset game data
		attempts = 0;
		startTime = 0;
		TimerText.text = "00:00";
		AttemptsText.text  = "0";
	}

	// called by button presses on the main menu panel
	public void PlayGame(string difficulty)
	{

		LevelDifficulty level = null;
		for(int cnt = 0; cnt < difficultyLevels.Length; cnt ++)
		{
			if(difficultyLevels[cnt].LevelName == difficulty)
			{
				level  = difficultyLevels[cnt];
				break;
			}
		}

		if(level != null)
		{
			MainMenu.gameObject.SetActive(false);
			DrawGameBoard(level.Width,level.Height, level);	
			gameRunning = true;
		}
		else
		{
			Debug.Log("Difficulty level not found: " + difficulty);
		}

	}
		

	// Draw the game board;  width * height must be divisible by 2 or there will
	// be an inappropriate amount of cards to match
	public void DrawGameBoard(int width, int height, LevelDifficulty level)
	{

		int totalCards = (width * height) ;
		if(totalCards % 2 != 0)
		{
			Debug.Log("Total Card count must be even!");
			return;
		}
		if( (totalCards/2) > spriteCollection.count)
		{
			Debug.Log("Total Card count must be less than the number of available sprites * 2!");
			return;
		}

		// Grab some shuffled values (sprites)
		Sprite[] sprites = getShuffledValues(totalCards);

		if(sprites == null)
		{
			Debug.Log("Total Cards exceeds shuffleable values! Reduce the size of the game board");
			return;
		}

		Vector3 newScale = level.CardScale;

		// FIXED VALUES BASED ON 100 PPU, 140x190 sprites
		float unitsWide = 1.4f * newScale.x;
		float unitsTall = 1.9f* newScale.y;
		float unitsSpacing = 0.1f;
			

		// Start offsets based on width/height; depending on card dimensions and spacing
		// these will change in order to keep them centered-ish
		float xstart = -( ((width-1) * 0.5f * unitsWide) + (width-1) * 0.5f * unitsSpacing  ) ;
		float ystart = -( ((height-1) * 0.5f * unitsTall) + (height-1) * 0.5f * unitsSpacing  + level.PadTop) ;

		// Index into our shuffled card values.
		int cardndx = 0;

		// Use the prefab's default rotation when instantiating a card
		Quaternion rot = PlayingCardPrefab.transform.localRotation;


		float yloc = ystart;

		for(int ycnt = 0; ycnt < height; ycnt++)
		{
			
			float xloc = xstart;

			for(int xcnt = 0; xcnt < width; xcnt ++)
			{
				Vector3 location = new Vector3(xloc, yloc, 0);
				GameObject card = Instantiate(PlayingCardPrefab, location, rot) as GameObject;
				card.transform.localScale = newScale;
				card.transform.SetParent(CardContainer);

				PlayingCard pc = card.GetComponent<PlayingCard>();
				pc.selectCallback = onSelectCard;

				pc.matchSprite = sprites[cardndx];
				cardndx += 1;

				xloc += unitsWide + unitsSpacing;
			}
			yloc += unitsTall + unitsSpacing;
		}

		startTime = Time.time;
		buttonRestart.gameObject.SetActive(true);
		texts[0].SetActive(true);
		texts[1].SetActive(true);

	}

	//
	// onSelectedCard - handler function, called by the playing card
	//  
	public void onSelectCard(PlayingCard selectedCard)
	{
		if(selectedLocked)
		{
			
			if(currentCardOperation != null)
				currentCardOperation.MoveNext();
				
			return;
		}

		if(currentCard == null)
		{
			currentCard = selectedCard;
			currentCard.show(true);
		}
		else
		{
			// Current Card is selected Card; flip it back over
			if(selectedCard == currentCard)
			{
				currentCard.show(false);
				currentCard = null;
			}
			else
			{
				selectedCard.show(true);
				secondCard = selectedCard;
				selectedLocked = true;

				updateAttempts();
				// Its a match! YAY!
				if(currentCard.IsMatch(selectedCard))
				{
					
					StartCoroutine("DestroyMatch");
				}
				// DOH! No match, hide both
				else
				{
					currentCardOperation = HideBoth();
					StartCoroutine(currentCardOperation);

				}
			}
			// Check is done, so unselect the current card

		}

	}

	// Bad match
	IEnumerator HideBoth()
	{
		
		yield return new WaitForSeconds(0.2f);
		gameObject.SendMessage("PlaySound", "CardmatchBad");

		yield return new WaitForSeconds(FlipDelay);
		selectedLocked = false;


		currentCard.show(false);
		secondCard.show(false);

		currentCard = null;
		secondCard = null;
		currentCardOperation = null;
	}	

	IEnumerator DestroyMatch()
	{
		
		currentCard.DestroyCard();
		secondCard.DestroyCard();

		selectedLocked = false;
		currentCard = null;
		secondCard = null;

		if(CardContainer.childCount == 0)
		{
			gameRunning = false;
			// Show the game over panel after short delay
			Invoke("ShowGameOverPanel", 0.75f);
		}

		yield return new WaitForSeconds(0.2f);
		gameObject.SendMessage("PlaySound", "CardmatchGood");

	
	}

	void ShowGameOverPanel()
	{
		GameOverAttemptsText.text = AttemptsText.text;
		GameOverTimerText.text = TimerText.text;
		GameOverPanel.gameObject.SetActive(true);

	}


	void updateAttempts()
	{
		attempts ++;
		AttemptsText.text = attempts.ToString();
	}

	string getTimeString()
	{
		float currTime = Time.time - startTime;
		float sec = Mathf.Round(currTime % 60);
		string secstr = sec.ToString();
		if(sec < 10)
			secstr = string.Format("0{0}", sec);
		int min = Mathf.RoundToInt( (currTime / 60) );

		return string.Format("{0}:{1}", min, secstr);

	}
	// Update is called once per frame
	void Update () 
	{
		if( gameRunning )
		{
			TimerText.text = getTimeString();
		}
	}
}

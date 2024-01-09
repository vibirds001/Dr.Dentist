using UnityEngine;

/* Class to represent the playing card
 * -- These are "memory/concetrate" style cards, so they do not
 *    have a suite. They simply have a little picture on them that
 *    must be matched with another card
 */
public class PlayingCard : MonoBehaviour 
{

	static Vector3 FaceShow = new Vector3(0,0,0);
	static Vector3 FaceHide = new Vector3(0,180,0);


	public delegate void CardSelectDelegate(PlayingCard selectedCard);

	public CardSelectDelegate selectCallback;


	SpriteRenderer ImageToMatch; //  renderer of child object to render when the player is viewing the card



	float startFlipTime;
	bool isFlipping = false;
	bool isShow;
	Vector3 newRot;
	Vector3 startRot;

	AudioSource audioFlipSound;

	void Awake()
	{

		audioFlipSound = GetComponent<AudioSource>();
		// Set the image to match renderer
		Transform child = transform.Find("ImageToMatch");
		if(child != null)
			ImageToMatch = child.GetComponent<SpriteRenderer>();

		if(ImageToMatch == null)
		{
			Debug.Log("Playing card requires Image To Match child object with a sprite renderer!");
		}

	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isFlipping)
		{
			float nowtime = (Time.time - startFlipTime) / 0.2f;
			Vector3 rot = Vector3.Lerp( startRot, newRot, nowtime);
			transform.localRotation = Quaternion.Euler(rot);
			if(nowtime > 1.0f)
			{
				// No longer flipping, destination reached;
				// Force rotation to destination
				isFlipping = false;
				transform.localRotation = Quaternion.Euler(newRot);
				GetComponent<BoxCollider2D>().enabled = true;

			}

		}
	}


	public void HideCard()
	{
		show(false);
	}

	public void show(bool doShow)
	{
		startFlipTime = Time.time;

		if (doShow)
		{
			startRot = FaceHide;
			newRot = FaceShow;
		}
		else
		{
			startRot = FaceShow;
			newRot = FaceHide;
		}


		GetComponent<BoxCollider2D>().enabled = false;
		isFlipping = true;
	}

	// card value getter : use the match image sprite name; if no
	// If no match image is set, then return null
	public string cardValue
	{
		get
		{ 
			if(ImageToMatch != null)
				return ImageToMatch.sprite.name;
			return null;
		}
	}

	// Set the matchable sprite
	public Sprite matchSprite
	{
		set
		{
			if(ImageToMatch != null) ImageToMatch.sprite = value;	
		}
	}

	// Does this card match the card passed in?
	// passed in card card must have a value (ImageToMatchSet)
	// this card must also have ImageToMatch set
	// Both cards must have identical sprite names
	public bool IsMatch(PlayingCard pc)
	{
		string pcname = pc.cardValue;
		if(ImageToMatch != null && ! string.IsNullOrEmpty(pcname))
			return (ImageToMatch.sprite.name.CompareTo(pcname) == 0);
		
		return false;
	}

	// This card was matched. It will be destroyed soon
	public void DestroyCard()
	{
		transform.SetParent(null); // remove it from the container;
		// Dont let this get clicked anymore
		GetComponent<BoxCollider2D>().enabled = false;
		Destroy(gameObject,0.5f);
	}

	void OnMouseDown()
	{
		
		if(isFlipping) return; 

		// Play card flip sound
		if(audioFlipSound != null)
			audioFlipSound.Play();

		if(selectCallback != null)	selectCallback(this);
	}

}
